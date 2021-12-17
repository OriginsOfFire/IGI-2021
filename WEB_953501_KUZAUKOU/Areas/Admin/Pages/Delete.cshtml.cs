using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_953501_KUZAUKOU.Data;
using WEB_953501_KUZAUKOU.Entities;

namespace WEB_953501_KUZAUKOU.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WEB_953501_KUZAUKOU.Data.ApplicationDbContext _context;

        public DeleteModel(WEB_953501_KUZAUKOU.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guitar Guitar { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Guitar = await _context.Guitars
                .Include(g => g.Group).FirstOrDefaultAsync(m => m.GuitarId == id);

            if (Guitar == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Guitar = await _context.Guitars.FindAsync(id);

            if (Guitar != null)
            {
                _context.Guitars.Remove(Guitar);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
