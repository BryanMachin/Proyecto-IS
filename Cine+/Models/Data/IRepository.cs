using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;

namespace Cine_.Models.Data
{
    public interface IRepository
    {
        IQueryable<Movie> Movies { get; }

        IQueryable<Client> Clients { get; }

        void SaveMovie(Movie movie);

        Movie DeleteMovie(Guid id);

        void SaveClient(Client client);

        Client DeleteClient(Guid id);
    }
}
