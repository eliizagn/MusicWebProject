//создание певцов
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;

namespace MusicWebProject.Pages.MusicCollections
{
    public class CreateCollection : PageModel
    {

        private MusicDbContext _musicDbContext;
        public List<SelectListItem> Songs { get; set; }
        public List<SelectListItem> Genres { get; set; }

        [BindProperty]
        public int SongId { get; set; }

        [BindProperty]
        public int GenreId { get; set; }

        [BindProperty]
        public MusicCollection Collection { get; set; }


        public CreateCollection(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }
        
        public void OnGet()
        {
            var allSongs = _musicDbContext.Songs;

            Songs = allSongs.Select(song => new SelectListItem
            {
                Value = song.Id.ToString(),
                Text = song.Name
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
            Collection.GenreId = GenreId;
            var song = _musicDbContext.Songs.FirstOrDefault(s => s.Id == SongId);
            Collection.Songs.Add(song); 
            _musicDbContext.Add(Collection);
            _musicDbContext.SaveChanges();
            return RedirectToPage("/MusicCollections/Index");
        }
    }
}


