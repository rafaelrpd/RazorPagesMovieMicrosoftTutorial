using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovieMicrosoftTutorial.Data;
using RazorPagesMovieMicrosoftTutorial.Models;

namespace RazorPagesMovieMicrosoftTutorial.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieMicrosoftTutorial.Data.RazorPagesMovieMicrosoftTutorialContext _context;

        public IndexModel(RazorPagesMovieMicrosoftTutorial.Data.RazorPagesMovieMicrosoftTutorialContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
