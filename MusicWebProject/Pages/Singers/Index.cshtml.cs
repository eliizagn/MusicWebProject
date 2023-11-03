using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;

//стартовая страница для Singers

namespace MusicWebProject.Pages.Singers
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

        public List<Singer> Singers { get ; set; }

        //метод 
        public void OnGet()

        {
            if (SearchingString != null)
            {
                //Язык запросов LINQ - позволяет работать с коллекциями (таблица), Contains - метод, который позволяет сопоставить строчку ввода со строкой в таблице, х - это объект класса Singer??????
                Singers = _musicDbContext.Singers.Where(x => x.Name.Contains(SearchingString)).ToList();
            }
            else {
                Singers = _musicDbContext.Singers.ToList();
            }
        }
    }
}

