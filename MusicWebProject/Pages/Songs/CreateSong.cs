using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;

namespace MusicWebProject.Pages.Songs
{
    public class CreateSongs : PageModel
    {

        private MusicDbContext _musicDbContext;
        [BindProperty]
        public int AlbumId { get; set; }
        [BindProperty]
        public int SingerId { get; set; }
        [BindProperty]
        public int GenreId { get; set; }

        [BindProperty]
        public Song Song { get; set; }
        public CreateSongs(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }
        public List<SelectListItem> Albums { get; set; }
        public List<SelectListItem> Singers { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public void OnGet()
        {
            var allSongs = _musicDbContext.Albums;

            Albums = allSongs.Select(album => new SelectListItem
            {
                Value = album.Id.ToString(),
                Text = album.Name
            }).ToList();

            var allSingers = _musicDbContext.Singers;

            Singers = allSingers.Select(singer => new SelectListItem
            {
                Value = singer.Id.ToString(),
                Text = singer.Name
            }).ToList();

            var allGenres = _musicDbContext.Genres;

            Genres = allGenres.Select(genre => new SelectListItem
            {
                Value = genre.Id.ToString(),
                Text = genre.Name
            }).ToList();
        }
       

        public IActionResult OnPost()
        {
            Song.AlbumId = AlbumId;
            Song.SingerId = SingerId;
            Song.GenreId = GenreId;

            _musicDbContext.Add(Song);
            _musicDbContext.SaveChanges();
            return RedirectToPage("/Albums/Index");
        }
    }
}