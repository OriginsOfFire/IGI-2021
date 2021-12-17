using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEB_953501_KUZAUKOU.Data;
using WEB_953501_KUZAUKOU.Entities;

namespace WEB_953501_KUZAUKOU.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly WEB_953501_KUZAUKOU.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public EditModel(WEB_953501_KUZAUKOU.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        [BindProperty]
        public Guitar Guitar { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }
    
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
            ViewData["GuitarGroupId"] = new SelectList(_context.GuitarGroups, "GuitarGroupId", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Image != null)
            {
                var fileName = $"{Guitar.GuitarId}" + Path.GetExtension(Image.FileName);
                Guitar.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images",
                fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
            }

            _context.Attach(Guitar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuitarExists(Guitar.GuitarId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GuitarExists(int id)
        {
            return _context.Guitars.Any(e => e.GuitarId == id);
        }
    }
}
