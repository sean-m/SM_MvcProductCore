using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SM_MvcProductCore.Data;
using SM_MvcProductCore.Models;
using SM_MvcProductCore.Services;

namespace SM_MvcProductCore.Pages.Feedbacks
{
    public class IndexModel : PageModel
    {
        private readonly ICosmosDbService _context;

        public IndexModel(ICosmosDbService context)
        {
            _context = context;
        }

        public IEnumerable<Feedback> Feedback { get;set; }

        public async Task OnGetAsync()
        {
            Feedback = await _context.GetItemsAsync("select * from c");
        }
    }
}
