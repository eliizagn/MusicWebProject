//создание певцов
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;

namespace MusicWebProject.Pages.Albums
{
    public class CreateAlbum : PageModel
    {

        private MusicDbContext _musicDbContext;

        public CreateAlbum (MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }
        [BindProperty]
        public Album Album {  get; set; }
        // атрибут - настройки для сущности [BindProperty] 
        // типы http запросов (post get put delete patch)
        public IActionResult OnPost() 
        {
            _musicDbContext.Add(Album);
            _musicDbContext.SaveChanges();
            return RedirectToPage("/Albums/Index");
        }
    }
}


