using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Database.Entities
{
    [Table("Seats")]
    public class SeatEntity
    {
        public int HallId { get; set; }

        public string Number { get; set; }

        public CinemaHallEntity Hall { get; set; }

        public bool IsAvailable { get; set; }
    }
}
