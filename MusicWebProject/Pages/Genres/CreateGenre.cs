//создание певцов
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;

namespace MusicWebProject.Pages.Genres
{
    public class CreateGenre : PageModel
    {

        private MusicDbContext _musicDbContext;

        public CreateGenre(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }
        [BindProperty]
        public Genre Genre {  get; set; }
        // атрибут - настройки для сущности [BindProperty] 
        // типы http запросов (post get put delete patch)
        public IActionResult OnPost() 
        {
            _musicDbContext.Add(Genre);
            _musicDbContext.SaveChanges();
            return RedirectToPage("/Genres/Index");
        }
    }
}


