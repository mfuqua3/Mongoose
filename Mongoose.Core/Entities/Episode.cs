using System;

namespace Mongoose.Core.Entities
{
    public class Episode
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint SeasonId { get; set; }
        public Season Season { get; set; }
        public string FilePath { get; set; }
        public string IconPath { get; set; }
    }
}