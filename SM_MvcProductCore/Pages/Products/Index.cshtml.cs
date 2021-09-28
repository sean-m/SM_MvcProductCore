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
    public class IndexModel : PageModel
    {
        private readonly SM_MvcProductCore.Models.AdventureWorksLT2016Context _context;

        public IndexModel(SM_MvcProductCore.Models.AdventureWorksLT2016Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductModel).ToListAsync();
        }
    }
}
