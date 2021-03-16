using System.ComponentModel.DataAnnotations;

namespace Mongoose.Models
{
    public class EpisodeViewModel
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        [Required]
        [Range(1, short.MaxValue, ErrorMessage = "An episode number must be provided")]
        public short EpisodeNumber { get; set; }
        [Required]
        public VideoInfoViewModel VideoInfo { get; set; }
    }
}