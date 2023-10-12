using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Database.Entities
{
    [Table("Tickets")]
    public class TicketEntity
    {
        public int SessionId { get; set; }

        public MovieSessionEntity Session { get; set; }

        public string SeatNumber { get; set; }

        public bool IsAvailable { get; set; }
    }
}
