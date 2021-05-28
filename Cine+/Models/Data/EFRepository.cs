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

        public IQueryable<Client> Clients => context.Clients;




        public Movie DeleteMovie(Guid id)
        {
            Movie movie = context.Movies.FirstOrDefault(m => m.MovieID == id);

            if (movie != null)
            {
                context.Movies.Remove(movie);
                context.SaveChanges();
            }
            return movie;
        }

        public void SaveMovie(Movie movie)
        {
            if (movie.MovieID.CompareTo(Guid.Empty) == 0)
            {
                context.Movies.Add(movie);
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


        public Client DeleteClient(Guid id)
        {
            Client client = context.Clients.FirstOrDefault(m => m.ClientID == id);

            if (client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }
            return client;
        }

        public void SaveClient(Client client)
        {
            if (client.ClientID.CompareTo(Guid.Empty) == 0)
            {
                context.Clients.Add(client);
            }
            else
            {
                Client bdClient = context.Clients.FirstOrDefault(m => m.ClientID == client.ClientID) ;

                bdClient.Name = client.Name;
                bdClient.LastName = client.LastName;
                bdClient.IdentityNumber = client.IdentityNumber;
                
            }

            context.SaveChanges();
        }


    }
}
