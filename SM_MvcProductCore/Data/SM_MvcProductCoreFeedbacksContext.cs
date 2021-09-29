using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SM_MvcProductCore.Models;

namespace SM_MvcProductCore.Data
{
    public class SM_MvcProductCoreFeedbacksContext : DbContext
    {
        public SM_MvcProductCoreFeedbacksContext (DbContextOptions<SM_MvcProductCoreFeedbacksContext> options)
            : base(options)
        {
        }

        public DbSet<SM_MvcProductCore.Models.Feedback> Feedback { get; set; }
    }
}
