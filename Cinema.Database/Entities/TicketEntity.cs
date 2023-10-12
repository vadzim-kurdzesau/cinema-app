using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Database.Entities
{
    [Table("Tickets")]
    public class TicketEntity
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public MovieEntity Movie { get; set; }

        public DateTime Starts { get; set; }

        public TimeSpan Lasts { get; set; }

        // Implicitly creates two shadow properties: SeatHallId and SeatNumber,
        // because both of them are part of a composite key
        public SeatEntity Seat { get; set; }

        public int? UserId { get; set; }

        /// <summary>
        /// Optional. The user who booked this ticket.
        /// </summary>
        public UserEntity? User { get; set; }

        [NotMapped]
        public bool IsBooked => UserId.HasValue;
    }
}
