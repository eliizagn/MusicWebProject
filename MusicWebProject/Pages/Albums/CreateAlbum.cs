//создание певцов
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;

namespace MusicWebProject.Pages.Albums
{
    public class CreateAlbum : PageModel
    {

        private MusicDbContext _musicDbContext;
        public List<SelectListItem> Singers { get; set; }

        [BindProperty]
        public int SingerId { get; set; }

        [BindProperty]
        public Album Album { get; set; }

        // атрибут - настройки для сущности [BindProperty] 
        // типы http запросов (post get put delete patch)
        public CreateAlbum(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }
        public void OnGet()
        {

            var allSingers = _musicDbContext.Singers;

            Singers = allSingers.Select(singer => new SelectListItem
            {
                Value = singer.Id.ToString(),
                Text = singer.Name
            }).ToList();

        }
        
        
        public IActionResult OnPost() 
        {
            Album.SingerId = SingerId;
            _musicDbContext.Add(Album);
            _musicDbContext.SaveChanges();
            return RedirectToPage("/Albums/Index");
        }
    }
}


