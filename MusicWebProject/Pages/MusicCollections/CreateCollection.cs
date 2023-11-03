//создание певцов
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using MusicWebProject.Data;
using MusicWebProject.Data.Models;

namespace MusicWebProject.Pages.MusicCollections
{
    public class CreateCollection : PageModel
    {

        private MusicDbContext _musicDbContext;

        public CreateCollection(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }
        [BindProperty]
        public MusicCollection Collection {  get; set; }

        public IActionResult OnPost() 
        {
            _musicDbContext.Add(Collection);
            _musicDbContext.SaveChanges();
            return RedirectToPage("/MusicCollections/Index");
        }
    }
}


