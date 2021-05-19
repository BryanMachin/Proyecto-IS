using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;

namespace Cine_.Models.Data
{
    public class EFRepository: IRepository
    {
        private ApplicationDbContext context;

        public EFRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Movie> Movies => context.Movies;

        public Movie DeleteMovie(Guid id)
        {
            Movie movie = context.Movies.FirstOrDefault(m => m.MovieID == id);

            if (movie != null)
            {
                context.Remove(movie);
                context.SaveChanges();
            }
            return movie;
        }

        public void SaveMovie(Movie movie)
        {
            if (movie.MovieID.CompareTo(Guid.Empty) == 0)
            {
                context.Add(movie);
            }
            else 
            {
                Movie bdMovie = context.Movies.FirstOrDefault(m => m.MovieID == movie.MovieID);

                bdMovie.Title = movie.Title;
                bdMovie.Nationality = movie.Nationality;
                bdMovie.Rating = movie.Rating;
                bdMovie.Synopsis = movie.Synopsis;
            }
            
            context.SaveChanges();
        }


    }
}
