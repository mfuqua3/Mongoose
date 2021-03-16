using System.Collections.Generic;

namespace Mongoose.Core.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SeriesId { get; set; }
        public Series Series { get; set; }
        public List<Episode> Episodes { get; set; }
        public ushort SeasonNumber { get; set; }
        public string IconPath { get; set; }
    }
}