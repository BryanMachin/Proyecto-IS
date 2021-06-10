using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;
using Cine_.Models.Relations;

namespace Cine_.Models.Data
{
    public interface IRepository
    {
        IQueryable<Movie> Movies { get; }
        IQueryable<Client> Clients { get; }
        IQueryable<Genre> Genres { get; }
        IQueryable<DiscountType> DiscountTypes { get; }
        IQueryable<Room> Rooms { get; }
        IQueryable<Shift> Shifts { get; }
        IQueryable<SpecialDate> SpecialDates { get; }
        IQueryable<SpecialUser> SpecialUsers { get; }
        IQueryable<Presentation> Presentations { get; }



        void SaveMovie(Movie movie);
        Movie DeleteMovie(Guid id);

        void SaveClient(Client client);
        Client DeleteClient(Guid id);

        void SaveGenre(Genre genre);
        Genre DeleteGenre(Guid id);

        void SaveDiscountType(DiscountType discountType);
        DiscountType DeleteDiscountType(Guid id);

        void SaveRoom(Room room);
        Room DeleteRoom(Guid id);

        void SaveShift(Shift shift);
        Shift DeleteShift(Guid id);

        void SaveSpecialDate(SpecialDate specialDate);
        SpecialDate DeleteSpecialDate(Guid id);

        //void SaveSpecialUser(SpecialUser specialUser);
        //SpecialUser DeleteSpecialUser(Guid id);

        void SavePresentation(Presentation presentation);
        Presentation DeletePresentation(Guid MovieID, Guid RoomID, Guid ShiftID, DateTime Date);
    }
}
