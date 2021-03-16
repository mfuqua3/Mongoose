using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mongoose.Models
{
    public class SeasonViewModel
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public uint SeriesId { get; set; }
        [Required]
        public ushort SeasonNumber { get; set; }
        public string IconPath { get; set; }
        public List<EpisodeViewModel> Episodes { get; set; }
    }
}