using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivitesAndWeather.EfCore
{
    [Table("Activities")]
    public class Activity
    {
        [Key, Required]
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }

        public string? City { get; set; }

        public string? Venue { get; set; }
    }
}
