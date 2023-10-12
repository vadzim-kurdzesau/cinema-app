using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Database.Entities
{
    [Table("Movies")]
    public class MovieEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public TimeSpan Lasts { get; set; }

        /// <summary>
        /// List of sessions where this movie is shown.
        /// </summary>
        public IEnumerable<MovieSessionEntity> Sessions { get; set; }
    }
}
