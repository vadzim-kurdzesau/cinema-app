using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Database.Entities
{
    [Table("CinemaHalls")]
    public class CinemaHallEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SeatEntity> Seats { get; set; }

        /// <summary>
        /// Movies currently shown in this hall.
        /// </summary>
        public IEnumerable<MovieEntity> Movies { get; set; }
    }
}
