using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "17 Miracles",
                         ReleaseDate = DateTime.Parse("2011-1-11"),
                         Genre = "Drama",
                         Price = 7.99M
                     },

                     new Movie
                     {
                         Title = "Meet the Mormons",
                         ReleaseDate = DateTime.Parse("2014-3-13"),
                         Genre = "Drama",
                         Price = 8.99M
                     },

                     new Movie
                     {
                         Title = "The RM",
                         ReleaseDate = DateTime.Parse("2003-2-23"),
                         Genre = "Comedy",
                         Price = 9.99M
                     },

                   new Movie
                   {
                       Title = "The Best Two Years",
                       ReleaseDate = DateTime.Parse("2003-4-15"),
                       Genre = "Comedy",
                       Price = 3.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
