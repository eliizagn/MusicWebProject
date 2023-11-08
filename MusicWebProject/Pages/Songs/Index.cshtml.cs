using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;

namespace MusicWebProject.Pages.Songs
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

        public List<Song> Songs { get; set; }
        public void OnGet()
        {
            if (SearchingString != null)
            {
                //Язык запросов LINQ - позволяет работать с коллекциями (таблица), Contains - метод, который позволяет сопоставить строчку ввода со строкой в таблице, х - это объект класса Singer??????
                Songs = _musicDbContext.Songs.Where(x => x.Name.Contains(SearchingString))
                    .Include(x=> x.Album)
                    .Include(x => x.Singer)
                    .Include(x => x.Genre)
                    .ToList();
            }
            else
            {
                Songs = _musicDbContext.Songs
                    .Include(x => x.Album)
                    .Include(x => x.Singer)
                    .Include(x => x.Genre)
                    .ToList();
            }
        }
    }
}
