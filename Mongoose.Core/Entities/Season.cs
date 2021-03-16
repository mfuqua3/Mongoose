using System.Collections.Generic;

namespace Mongoose.Core.Entities
{
    public class Season
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint SeriesId { get; set; }
        public Series Series { get; set; }
        public List<Episode> Episodes { get; set; }
        public ushort SeasonNumber { get; set; }
        public string IconPath { get; set; }
    }
}