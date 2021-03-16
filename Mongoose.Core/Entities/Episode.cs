using System;

namespace Mongoose.Core.Entities
{
    public class Episode
    {
        public int Id { get; set; }
        public short EpisodeNumber { get; set; }
        public VideoInfo VideoInfo { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}