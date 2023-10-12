using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Database.Entities
{
    [Table("Movies")]
    public class MovieEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public IEnumerable<TicketEntity> Tickets { get; set; }

        /// <summary>
        /// List of halls where this movie is shown.
        /// </summary>
        public IEnumerable<CinemaHallEntity> Halls { get; set; }
    }
}
