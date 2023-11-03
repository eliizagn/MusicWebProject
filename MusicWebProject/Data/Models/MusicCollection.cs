using MusicWebProject.Data.Models.Common;

namespace MusicWebProject.Data.Models
{
    public class MusicCollection : BaseEntity
    {
        public required string Name { get; set; }
        public required List<Song> Songs { get; set; }
        public required Genre Genre { get; set; }
    }
}
