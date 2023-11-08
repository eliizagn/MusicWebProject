using MusicWebProject.Data.Models.Common;

namespace MusicWebProject.Data.Models;

public class Singer : BaseEntity
{
    // свойства пишутся с заглавной, ставим ? для значения NULL
    // классы, свойства, методы наз через большую
    public required string Name { get; set; }
    public required List<Album> Albums { get; set; }
    public required List<Song> Songs { get; set; }

}