using MusicWebProject.Data.Models.Common;

namespace MusicWebProject.Data.Models
{
    public class MusicCollection : BaseEntity
    {
        public required string Name { get; set; }
        public required int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<Song> Songs { get; set; }
    }
}
