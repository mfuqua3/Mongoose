using System.ComponentModel.DataAnnotations;

namespace Mongoose.Models
{
    public class EpisodeViewModel
    {
        public uint Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public uint SeasonId { get; set; }
        public string IconPath { get; set; }
    }
}