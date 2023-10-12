using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Database.Entities
{
    [Table("MovieSessions")]
    public class MovieSessionEntity
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public MovieEntity Movie { get; set; }

        public string HallName { get; set; }

        public DateTime Starts { get; set; }

        public IEnumerable<TicketEntity> Tickets { get; set; }
    }
}
