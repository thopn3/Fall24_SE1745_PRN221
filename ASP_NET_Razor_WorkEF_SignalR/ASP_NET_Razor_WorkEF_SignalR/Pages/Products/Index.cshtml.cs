using ASP_NET_Razor_WorkEF_SignalR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Razor_WorkEF_SignalR.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_DBSampleContext _context;
        public IndexModel(PRN221_DBSampleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Product> Products { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Products = await _context.Products.Include("Category").ToListAsync();
            return Page();
        }
    }
}
