using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WdprPretparkDenhaag.Areas.Identity.Data;
using WdprPretparkDenhaag.Models;
using Microsoft.AspNetCore.Http;

namespace WdprPretparkDenhaag.Controllers
{
    public class KaartController : Controller
    {
        private readonly WdprPretparkDenhaagIdentityDbContext _context;

        public KaartController(WdprPretparkDenhaagIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string attractieSearchString)
        {
            // haal de attracties op
            var attracties = from a in _context.Attracties
                select a;

            // haal de attracties op die voldoen aan de filter van de searchbar
            if (!string.IsNullOrEmpty(attractieSearchString))
            {
                attracties = attracties.Where(attractie => attractie.Naam.Contains(attractieSearchString));
            }

            ///haal alle planningitems op
            var planningItems = from p in _context.PlanningItems
                select p;

            // Haalt de planningsitems op die horen bij de betreffende planning
             planningItems = planningItems.Where(planningItem => planningItem.PlanningId == Guid.Parse("D7433101-C93D-47D9-AECB-B2537BBDC23A"));

            IEnumerable<PlanningItem> planningItem = _context.PlanningItems;

            // maak een kaartview model aan die mee wordt gestuurd naar de kaartview
            KaartViewModel kaartViewModel = new KaartViewModel();
            kaartViewModel.Attracties = await attracties.ToListAsync();
            kaartViewModel.Tijdsloten = await _context.Tijdsloten.ToListAsync();
            kaartViewModel.PlanningItems = planningItem;
          
            // stuur de kaartviewmodel door naar de view          
            return View(kaartViewModel);
        }

        
        public async Task<IActionResult> VoegToe()
        {            
            return  RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        public async Task<IActionResult> VoegToe(IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                // Haal de geselecteerde waarde uit de view
                string tijdslotId = form["TijdslotId"].ToString();
                string attractieId = form["AttractieId"].ToString(); 

                // maak een planning item aan
                PlanningItem planningItem = new PlanningItem();
                planningItem.Id = Guid.NewGuid();
                planningItem.AttractieId = Guid.Parse(attractieId);
                planningItem.TijdSlotId = Guid.Parse(tijdslotId);
                planningItem.PlanningId = Guid.Parse("D7433101-C93D-47D9-AECB-B2537BBDC23A");
                
                //voeg de planningitem toe
                _context.PlanningItems.Add(planningItem);

                //sla de planningitem op in de database
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }  
    }    
}