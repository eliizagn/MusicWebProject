using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;

namespace MusicWebProject.Pages.Songs
{
    public class CreateSongs : PageModel
    {

        private MusicDbContext _musicDbContext;

        public CreateSongs(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }
        [BindProperty]
        public Song Song { get; set; }
        public IActionResult OnPost()
        {
            _musicDbContext.Add(Song);
            _musicDbContext.SaveChanges();
            return RedirectToPage("/Songs/Index");
        }
    }
}