using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovieMicrosoftTutorial.Models;

namespace RazorPagesMovieMicrosoftTutorial.Data
{
    public class RazorPagesMovieMicrosoftTutorialContext : DbContext
    {
        public RazorPagesMovieMicrosoftTutorialContext (DbContextOptions<RazorPagesMovieMicrosoftTutorialContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovieMicrosoftTutorial.Models.Movie>? Movie { get; set; }
    }
}
