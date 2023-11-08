using MusicWebProject.Data.Models.Common;

namespace MusicWebProject.Data.Models
{
    public class Album : BaseEntity
    {
        public required string Name { get; set; }

        public required int SingerId { get; set; }
        public required Singer Singer { get; set; }
    }
}
