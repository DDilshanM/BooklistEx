using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BooklistEx.Model;

namespace BooklistEx.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public CreateModel(ApplicationDBContext db)
        {
            _db = db;

        }
        [BindProperty] 
        
        public Book Book { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync(); /*push data database*/
                return RedirectToPage("Index");

            }
            else
            {
                return Page();
            }

        }
    }
}
