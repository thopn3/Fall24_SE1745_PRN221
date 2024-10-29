using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP_NET_ModelValidation_FileUpload.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The length of name is from 3 to 20 characters")]
        [Display(Name = "Employee name")]
        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Year of birth is required")]
        [Display(Name = "Year of birth")]
        [Range(1960, 2000, ErrorMessage = "1960 - 2000")]
        public int? YearOfBirth { get; set; }
        public string? Images { get; set; }
    }
}
