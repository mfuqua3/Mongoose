using System.Collections.Generic;

namespace Mongoose.Core.Entities
{
    public class Series
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Season> Seasons { get; set; }
        public string IconPath { get; set; }
    }
}