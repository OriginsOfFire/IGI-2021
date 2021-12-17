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
    public class IndexModel : PageModel
    {
        private readonly WEB_953501_KUZAUKOU.Data.ApplicationDbContext _context;

        public IndexModel(WEB_953501_KUZAUKOU.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Guitar> Guitar { get;set; }

        public async Task OnGetAsync()
        {
            Guitar = await _context.Guitars
                .Include(g => g.Group).ToListAsync();
        }
    }
}
