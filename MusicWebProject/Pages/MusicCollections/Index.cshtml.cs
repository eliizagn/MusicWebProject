using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public List<MusicCollection> Collections { get ; set; }

        public void OnGet()

        {
            if (SearchingString != null)
            {
               
                Collections = _musicDbContext.MusicCollections.Where(x => x.Name.Contains(SearchingString)).ToList();
            }
            else {
                Collections = _musicDbContext.MusicCollections.ToList();
            }
        }
    }
}

