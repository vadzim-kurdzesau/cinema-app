using System.ComponentModel.DataAnnotations;

namespace Cinema.WebApp.Models
{
    public class SessionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        public DateTime Starts { get; set; }

        public DateTime Ends { get; set; }
    }
}
