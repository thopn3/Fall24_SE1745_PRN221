using ASP_NET_Razor_WorkEF_SignalR.Hubs;
using ASP_NET_Razor_WorkEF_SignalR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Razor_WorkEF_SignalR.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly PRN221_DBSampleContext _context;
        private readonly IHubContext<SignalRServer> _hubContext;
        public CreateModel(PRN221_DBSampleContext context, IHubContext<SignalRServer> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnGet()
        {
            ViewData["Category"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
                return Page();

            await _context.Products.AddAsync(Product);
            await _context.SaveChangesAsync();

            // Bao cho Hub server ve su thay doi du lieu
            await _hubContext.Clients.All.SendAsync("ReloadData");

            return RedirectToPage("./Index");
        }
    }
}
