using MusicWebProject.Data.Models.Common;
using System.Collections.ObjectModel;

namespace MusicWebProject.Data.Models
{
    public class Genre : BaseEntity
    {
        public required string Name { get; set; }
        public  List<Song>? Songs { get; set; }
        public  List<MusicCollection>? Collections { get; set; }
    }
}
