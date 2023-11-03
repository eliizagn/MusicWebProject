using MusicWebProject.Data.Models.Common;
using System.Collections.ObjectModel;

namespace MusicWebProject.Data.Models
{
    public class Genre : BaseEntity
    {
        public required string Name { get; set; }
        public required List<Album> Albums { get; set; }
        public required List<MusicCollection> Collections { get; set; }
    }
}
