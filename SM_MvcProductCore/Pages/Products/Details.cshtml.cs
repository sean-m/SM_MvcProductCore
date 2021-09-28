using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SM_MvcProductCore.Models;

namespace SM_MvcProductCore.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly SM_MvcProductCore.Models.AdventureWorksLT2016Context _context;

        public DetailsModel(SM_MvcProductCore.Models.AdventureWorksLT2016Context context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductModel).FirstOrDefaultAsync(m => m.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
