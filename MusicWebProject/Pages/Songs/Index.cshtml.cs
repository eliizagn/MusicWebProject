using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;

namespace MusicWebProject.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private MusicDbContext _musicDbContext;

        public IndexModel(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        public List<Song> Songs { get; set; }
        public void OnGet()
        {
            Songs = _musicDbContext.Songs.ToList();
        }
    }
}
