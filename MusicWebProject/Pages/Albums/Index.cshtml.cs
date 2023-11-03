using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;

//стартовая страница для Singers

namespace MusicWebProject.Pages.Albums
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? SearchingString { get; set; }

        private MusicDbContext _musicDbContext;

        //создать конструктор - передать входные параметры - присвоить значение поле на вход
        // конструктор всегда имеет название класса
        public IndexModel(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        public List<Album> Albums { get ; set; }

        //метод 
        public void OnGet()

        {
            if (SearchingString != null)
            {
                //Язык запросов LINQ - позволяет работать с коллекциями (таблица), Contains - метод, который позволяет сопоставить строчку ввода со строкой в таблице, х - это объект класса Singer??????
                Albums = _musicDbContext.Albums.Where(x => x.Name.Contains(SearchingString)).ToList();
            }
            else {
                Albums = _musicDbContext.Albums.ToList();
            }
        }
    }
}

