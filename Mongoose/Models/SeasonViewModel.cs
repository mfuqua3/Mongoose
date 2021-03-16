using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mongoose.Models
{
    public class SeasonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int SeriesId { get; set; }
        [Required]
        [Range(1, ushort.MaxValue, ErrorMessage = "Season number must be provided")]
        public ushort SeasonNumber { get; set; }
        public string IconPath { get; set; }
        public List<EpisodeViewModel> Episodes { get; set; }
    }
}