using System.ComponentModel.DataAnnotations.Schema;

namespace Mongoose.Core.Entities
{
    public class VideoInfo
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Film))]
        public int? FilmId { get; set; }
        public Film Film { get; set; }
        [ForeignKey(nameof(Episode))]
        public int? EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string IconPath { get; set; }
        public long Duration { get; set; }
    }
}