using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WdprPretparkDenhaag.Areas.Identity.Data;
using WdprPretparkDenhaag.Models;

namespace WdprPretparkDenhaag.Controllers
{
    public class KaartController : Controller
    {
        private readonly WdprPretparkDenhaagIdentityDbContext _context;

        public KaartController(WdprPretparkDenhaagIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<PlanningItem> planningItem = new List<PlanningItem>();

            KaartViewModel kaartViewModel = new KaartViewModel();
            kaartViewModel.Attracties = await _context.Attracties.ToListAsync();
            kaartViewModel.Tijdsloten = await _context.Tijdsloten.ToListAsync();
            kaartViewModel.PlanningItems = planningItem;
          
            return View(kaartViewModel);
        }
    }    
}