using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Database.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<TicketEntity> Tickets { get; set; }
    }
}
