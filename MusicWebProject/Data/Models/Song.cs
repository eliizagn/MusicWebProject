﻿using MusicWebProject.Data.Models.Common;

namespace MusicWebProject.Data.Models
{
    public class Song : BaseEntity
    {
        public required string Name { get; set; }
        public required DateOnly SongYear {  get; set; }
        public int AlbumId { get; set; }
        public required Album Album { get; set; }

        public int SingerId { get; set; }
        public required Singer Singer { get; set; }

        public int GenreId { get; set; }
        public required Genre Genre { get; set; }
    }
}
