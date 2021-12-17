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
using WEB_953501_KUZAUKOU.Data;
using WEB_953501_KUZAUKOU.Entities;

namespace WEB_953501_KUZAUKOU.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WEB_953501_KUZAUKOU.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(WEB_953501_KUZAUKOU.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
            ViewData["GuitarGroupId"] = new SelectList(_context.GuitarGroups, "GuitarGroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Guitar Guitar { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Guitars.Add(Guitar);
            await _context.SaveChangesAsync();

            if(Image != null)
            {
                var fileName = $"{Guitar.GuitarId}" + Path.GetExtension(Image.FileName);
                Guitar.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);

                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
