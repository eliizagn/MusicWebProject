using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;


namespace MusicWebProject.Pages.MusicCollections
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? SearchingString { get; set; }

        private MusicDbContext _musicDbContext;

        public IndexModel(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        public List<MusicCollection> MusicCollections { get; set; }


        //(x => x.Name.Contains(SearchingString) - лямбда выражение
        public void OnGet()
        {
            if (SearchingString != null)
            {
                MusicCollections = _musicDbContext.MusicCollections.Where(x => x.Name.Contains(SearchingString))
                     .Include(x => x.Genre)
                     .Include(x => x.Songs)
                     .ToList();
            }
            else {
                MusicCollections = _musicDbContext.MusicCollections
                     .Include(x => x.Genre)
                     .Include(x => x.Songs)
                     .ToList();
            }
        }
        public IActionResult OnPost(int id)
        {
            var musiccollection = _musicDbContext.MusicCollections.Find(id);
            if (musiccollection != null)
            {
                _musicDbContext.MusicCollections.Remove(musiccollection);
                _musicDbContext.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}

