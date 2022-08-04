using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDBContext _db;

        public Category Category { get; set; }

        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        //** Moze se koristit i ime pored OnPost ex. OnPostCreate()
        public async Task<IActionResult> OnPost(Category category)
        {
            await _db.Category.AddAsync(category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
