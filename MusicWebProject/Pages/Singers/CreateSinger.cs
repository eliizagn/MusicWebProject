//создание певцов
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;

namespace MusicWebProject.Pages.Singers
{
    public class CreateSinger : PageModel
    {

        private MusicDbContext _musicDbContext;

        public CreateSinger(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }
        [BindProperty]
        public Singer Singer {  get; set; }
        // атрибут - настройки для сущности [BindProperty] 
        // типы http запросов (post get put delete patch)
        public IActionResult OnPost() 
        {
            _musicDbContext.Add(Singer);
            _musicDbContext.SaveChanges();
            return RedirectToPage("/Singers/Index");
        }
    }
}


