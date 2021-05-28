using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRate.Models
{
    public class ReviewContext : DbContext
    {
        public DbSet<GameReview> Review { get; set; }
        public ReviewContext(DbContextOptions<GameContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
