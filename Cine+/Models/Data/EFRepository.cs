using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;
using Cine_.Models.Relations;

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
        public IQueryable<Genre> Genres => context.Genres;
        public IQueryable<DiscountType> DiscountTypes => context.DiscountTypes;
        public IQueryable<Room> Rooms => context.Rooms;
        public IQueryable<Shift> Shifts => context.Shifts;
        public IQueryable<SpecialDate> SpecialDates => context.SpecialDates;
        public IQueryable<SpecialUser> SpecialUsers => context.SpecialUsers;
        public IQueryable<Presentation> Presentations => context.Presentations;


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
            movie.GenreName = context.Genres.FirstOrDefault(g => g.GenreID == movie.GenreID).Name;
            if (movie.MovieID.CompareTo(Guid.Empty) == 0)
            {
                context.Movies.Add(movie);
            }
            else 
            {
                Movie bdMovie = context.Movies.FirstOrDefault(m => m.MovieID == movie.MovieID);
                bdMovie.GenreName = movie.GenreName;
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
        
        public Genre DeleteGenre(Guid id)
        {
            Genre genre = context.Genres.FirstOrDefault(m => m.GenreID == id);

            if (genre != null)
            {
                context.Genres.Remove(genre);
                context.SaveChanges();
            }
            return genre;
        }
        public void SaveGenre(Genre genre)
        {
            if (genre.GenreID.CompareTo(Guid.Empty) == 0)
            {
                context.Genres.Add(genre);
            }
            else
            {
                Genre bdGenre = context.Genres.FirstOrDefault(m => m.GenreID == genre.GenreID);
                bdGenre.Name = genre.Name;

            }

            context.SaveChanges();
        }

        public DiscountType DeleteDiscountType(Guid id)
        {
            DiscountType discountType = context.DiscountTypes.FirstOrDefault(m => m.DiscountTypeID == id);

            if (discountType != null)
            {
                context.DiscountTypes.Remove(discountType);
                context.SaveChanges();
            }
            return discountType;
        }
        public void SaveDiscountType(DiscountType discountType)
        {
            if (discountType.DiscountTypeID.CompareTo(Guid.Empty) == 0)
            {
                context.DiscountTypes.Add(discountType);
            }
            else
            {
                DiscountType bdDiscountType = context.DiscountTypes.FirstOrDefault(m => m.DiscountTypeID == discountType.DiscountTypeID);
                bdDiscountType.Name = discountType.Name;
                bdDiscountType.DiscountRate = discountType.DiscountRate;
            }

            context.SaveChanges();
        }

        public Room DeleteRoom(Guid id)
        {
            Room room = context.Rooms.FirstOrDefault(m => m.RoomID == id);

            if (room != null)
            {
                context.Rooms.Remove(room);
                context.SaveChanges();
            }
            return room;
        }
        public void SaveRoom(Room room)
        {
            if (room.RoomID.CompareTo(Guid.Empty) == 0)
            {
                context.Rooms.Add(room);
            }
            else
            {
                Room bdRoom = context.Rooms.FirstOrDefault(m => m.RoomID == room.RoomID);
                bdRoom.Name = room.Name;
                bdRoom.Capacity = bdRoom.Capacity;
            }

            context.SaveChanges();
        }

        public Shift DeleteShift(Guid id)
        {
            Shift shift = context.Shifts.FirstOrDefault(m => m.ShiftID == id);

            if (shift != null)
            {
                context.Shifts.Remove(shift);
                context.SaveChanges();
            }
            return shift;
        }
        public void SaveShift(Shift shift)
        {
            if (shift.ShiftID.CompareTo(Guid.Empty) == 0)
            {
                context.Shifts.Add(shift);
            }
            else
            {
                Shift bdShift = context.Shifts.FirstOrDefault(m => m.ShiftID == shift.ShiftID);
                bdShift.Time = shift.Time;
                bdShift.Name = shift.Name;

            }

            context.SaveChanges();
        }

        public SpecialDate DeleteSpecialDate(Guid id)
        {
            SpecialDate specialDate = context.SpecialDates.FirstOrDefault(m => m.SpecialDateID == id);

            if (specialDate != null)
            {
                context.SpecialDates.Remove(specialDate);
                context.SaveChanges();
            }
            return specialDate;
        }
        public void SaveSpecialDate(SpecialDate specialDate)
        {
            if (specialDate.SpecialDateID.CompareTo(Guid.Empty) == 0)
            {
                context.SpecialDates.Add(specialDate);
            }
            else
            {
                SpecialDate bdSpecialDate = context.SpecialDates.FirstOrDefault(m => m.SpecialDateID == specialDate.SpecialDateID);
                bdSpecialDate.Name = specialDate.Name;
                bdSpecialDate.Date = specialDate.Date;
                bdSpecialDate.DiscountRate = specialDate.DiscountRate;
            }

            context.SaveChanges();
        }

        //public SpecialUser DeleteSpecialUser(Guid id)
        //{
        //    SpecialUser specialUser = context.SpecialUsers.FirstOrDefault(m => m.SpecialUserID == id);

        //    if (specialUser != null)
        //    {
        //        context.SpecialUsers.Remove(specialUser);
        //        context.SaveChanges();
        //    }
        //    return specialUser;
        //}
        //public void SaveSpecialUser(SpecialUser specialUser)
        //{
        //    if (specialUser.SpecialUserID.CompareTo(Guid.Empty) == 0)
        //    {
        //        context.SpecialUsers.Add(specialUser);
        //    }
        //    else
        //    {
        //        SpecialUser bdSpecialUser = context.SpecialUsers.FirstOrDefault(m => m.SpecialUserID == specialUser.SpecialUserID);
        //        bdSpecialUser. = genre.Name;

        //    }

        //    context.SaveChanges();
        //}
        public Presentation DeletePresentation(Guid MovieID, Guid RoomID, Guid ShiftID, DateTime Date)
        {
            Presentation presentation = context.Presentations.FirstOrDefault(p => 
            p.MovieID == MovieID 
            && p.RoomID == RoomID
            && p.ShiftID == ShiftID
            && p.Date == Date);

            if (presentation != null)
            {
                context.Presentations.Remove(presentation);
                context.SaveChanges();
            }
            return presentation;
        }
        public void SavePresentation(Presentation presentation)
        {
            context.Presentations.Add(presentation);
            context.SaveChanges();
        }

    }
}
