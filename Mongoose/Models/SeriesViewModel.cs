using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Mongoose.Core.Entities;

namespace Mongoose.Models
{
    public class SeriesViewModel
    {
        public uint Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SeasonViewModel> Seasons { get; set; }
        public string IconPath { get; set; }

    }
}