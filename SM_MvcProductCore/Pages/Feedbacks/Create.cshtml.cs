using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM_MvcProductCore.Data;
using SM_MvcProductCore.Models;
using SM_MvcProductCore.Services;

namespace SM_MvcProductCore.Pages.Feedbacks
{
    public class CreateModel : PageModel
    {
        private readonly ICosmosDbService _context;

        public CreateModel(ICosmosDbService context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Feedback Feedback { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Feedback.id = Guid.NewGuid().ToString();
            await _context.AddItemAsync(Feedback);

            return RedirectToPage("./Index");
        }
    }
}
