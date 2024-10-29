using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASP_NET_ModelValidation_FileUpload.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_ModelValidation_FileUpload.Pages.employee
{
	public class manageModel : PageModel
    {
        public string Message { set; get; }

        [BindProperty]
        public Employee EmployeeInfo { set; get; }

        public List<Employee> Employees { set; get; }

        public List<string> Images  {get; set; }

        [Required(ErrorMessage = "Please choose at least one file")]
        [DataType(DataType.Upload)]
        //[FileExtensions(Extensions ="png,jpeg,jpg,gif")]
        [Display(Name = "Choose file(s) to upload avatar")]
        [BindProperty]
        public IFormFile[] FileUploads { set; get; }

        private readonly PRN221_Lab2DBContext _context;
        public manageModel(PRN221_Lab2DBContext context)
        {
            Images = new List<string>();
            _context = context;
        }

        private async Task ReloadEmployeeList()
        {
            Employees = await _context.Employees.ToListAsync<Employee>();
        }

        public async Task<ActionResult> OnGetAsync()
        {
            await ReloadEmployeeList();
            return Page();
        }
        public async Task<ActionResult> OnPostAsync()
        {
            Employees = null;
            await ReloadEmployeeList();
            if (ModelState.IsValid)
            {
                Message = "Information is OK";
                ModelState.Clear();

                if (FileUploads != null)
                {
                    string[] images = new string[100];
                    foreach (var FileUpload in FileUploads)
                    {
                        var fileExtension = Path.GetExtension(FileUpload.FileName).ToLower();

                        if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png")
                        {
                            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                            var fileName = Path.GetFileName(FileUpload.FileName); 
                            images.Append(fileName);
                            var filePath = Path.Combine(uploadsFolder, fileName);

                            // Tạo thư mục nếu chưa tồn tại
                            if (!Directory.Exists(uploadsFolder))
                            {
                                Directory.CreateDirectory(uploadsFolder);
                            }

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await FileUpload.CopyToAsync(fileStream);
                            }

                            // Gán đường dẫn tới UploadedImagePath để hiển thị
                            Images.Add($"/images/{fileName}");
                        }
                    }
                    string imageString = string.Join(";", images);
                    _context.Employees.Add(new Employee { EmployeeName=EmployeeInfo.EmployeeName, EmployeeId=EmployeeInfo.EmployeeId, Email=EmployeeInfo.Email, YearOfBirth=EmployeeInfo.YearOfBirth, Images = imageString});
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                Message = "Error on input data.";
            }

            
            return Page();
        }
    }
}
