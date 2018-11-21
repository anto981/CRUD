using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace CRUD.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IList<User> Users { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            Users = await _db.Users.AsNoTracking().ToListAsync();
        }

        public async Task<ActionResult> OnPostDeleteAsync(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
