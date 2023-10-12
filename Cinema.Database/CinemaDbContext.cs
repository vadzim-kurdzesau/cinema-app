using Cinema.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cinema.Database
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<MovieEntity> Movies { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public CinemaDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Ticket entity
            modelBuilder.Entity<TicketEntity>()
                .HasKey(ticket => new { ticket.Id, ticket.MovieId });

            modelBuilder.Entity<TicketEntity>()
                .Property(ticket => ticket.Lasts)
                .HasConversion(new TimeSpanToTicksConverter());

            // Configure Seat entity
            modelBuilder.Entity<SeatEntity>()
                .HasKey(seat => new { seat.HallId, seat.Number });

            // Configure Cinema Hall entity relationships
            modelBuilder.Entity<CinemaHallEntity>()
                .HasMany(hall => hall.Seats)
                .WithOne(seat => seat.Hall)
                .HasForeignKey(seat => seat.HallId);

            modelBuilder.Entity<CinemaHallEntity>()
                .HasMany(hall => hall.Movies)
                .WithMany(movie => movie.Halls)
                .UsingEntity("Movies_In_Halls");

            // Configure Movie entity relationships
            modelBuilder.Entity<MovieEntity>()
                .HasMany(movie => movie.Tickets)
                .WithOne(ticket => ticket.Movie)
                .HasForeignKey(ticket => ticket.MovieId);

            // Configure User entity relationships
            modelBuilder.Entity<UserEntity>()
                .HasMany(user => user.Tickets)
                .WithOne(ticket => ticket.User)
                .HasForeignKey(ticket => ticket.UserId);
        }
    }
}