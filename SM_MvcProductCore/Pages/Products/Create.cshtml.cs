using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM_MvcProductCore.Models;

namespace SM_MvcProductCore.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly SM_MvcProductCore.Models.AdventureWorksLT2016Context _context;

        public CreateModel(SM_MvcProductCore.Models.AdventureWorksLT2016Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "Name");
        ViewData["ProductModelId"] = new SelectList(_context.ProductModels, "ProductModelId", "Name");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
