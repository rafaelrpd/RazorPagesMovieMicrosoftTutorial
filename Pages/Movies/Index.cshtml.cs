using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } = default!;
        public SelectList Genres { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; } = default!;

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
