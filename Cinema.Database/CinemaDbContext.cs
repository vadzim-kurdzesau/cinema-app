using Cinema.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cinema.Database
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<MovieEntity> Movies { get; set; }

        public CinemaDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Movie entity
            modelBuilder.Entity<MovieEntity>()
                .Property(movie => movie.Lasts)
                .HasConversion(new TimeSpanToTicksConverter());

            modelBuilder.Entity<MovieEntity>()
                .HasMany(movie => movie.Sessions)
                .WithOne(session => session.Movie)
                .HasForeignKey(session => session.MovieId);

            // Configure Movie Session entity
            modelBuilder.Entity<MovieSessionEntity>()
                .HasMany(session => session.Tickets)
                .WithOne(ticket => ticket.Session)
                .HasForeignKey(ticket => ticket.SessionId);

            // Configure Ticket entity
            modelBuilder.Entity<TicketEntity>()
                .HasKey(ticket => new { ticket.SessionId, ticket.SeatNumber });
        }
    }
}