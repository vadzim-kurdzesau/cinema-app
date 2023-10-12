namespace Cinema.WebApp.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public int Lasts { get; set; }

        public IEnumerable<SessionViewModel> Sessions { get; set; }
    }
}
