using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WEB_953501_KUZAUKOU.Entities;
using WEB_953501_KUZAUKOU.Extensions;
using WEB_953501_KUZAUKOU.Models;
using WEB_953501_KUZAUKOU.Data;
using Microsoft.Extensions.Logging;

namespace WEB_953501_KUZAUKOU.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        private int _pageSize;

        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group,int pageNo = 1)
        {
            var guitarsFiltered = _context.Guitars.Where(d => !group.HasValue || d.GuitarGroupId == group.Value);
            ViewData["Groups"] = _context.GuitarGroups;
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Guitar>.GetModel(guitarsFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }

    }
}
