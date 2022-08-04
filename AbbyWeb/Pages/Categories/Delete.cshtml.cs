using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {

        private readonly ApplicationDBContext _db;

        //** BIND PROPERTY IT AUTOMATICALLY BINDS WITH UI AND IT'S POPULATED IN THE SAME OBJECT (CATEGORY)

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }

        //** Name can be used with OnPost ex. OnPostCreate()
        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = _db.Category.Find(Category.Id);
            if (categoryFromDb != null)
            {
                    _db.Category.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
