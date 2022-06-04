using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WdprPretparkDenhaag.Areas.Identity.Data;
using WdprPretparkDenhaag.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace WdprPretparkDenhaag.Controllers
{
    public class KaartController : Controller
    {
        private readonly WdprPretparkDenhaagIdentityDbContext _context;

        private IHubContext<NotifyHub> _hubContext { get; }

        public KaartController(WdprPretparkDenhaagIdentityDbContext context, IHubContext<NotifyHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index(string attractieNaam)
        {
            // haal de attracties op
            var attracties = from a in _context.Attracties
                select a;

            // haal de attracties op die voldoen aan de filter van de searchbar
            if (!string.IsNullOrEmpty(attractieNaam))
            {
                attracties = attracties.Where(attractie => attractie.Naam.Contains(attractieNaam));
            }

            ///haal alle planningitems op
            var planningItems = from p in _context.PlanningItems
                select p;

            // Haalt de planningsitems op die horen bij de betreffende planning
            //  planningItems = planningItems.Where(planningItem => planningItem.PlanningId == Guid.Parse("D7433101-C93D-47D9-AECB-B2537BBDC23A"));
             planningItems = planningItems.Where(planningItem => planningItem.PlanningId == Guid.Parse("09AE98DA-F970-4C9A-BEF5-190949078BD8"));

            // IEnumerable<PlanningItem> planningItem = _context.PlanningItems;

            // maak een kaartview model aan die mee wordt gestuurd naar de kaartview
            KaartViewModel kaartViewModel = new KaartViewModel();
            kaartViewModel.Attracties = await attracties.ToListAsync();
            kaartViewModel.Tijdsloten = await _context.Tijdsloten.ToListAsync();
            kaartViewModel.PlanningItems = planningItems;
          
            // stuur de kaartviewmodel door naar de view          
            return View(kaartViewModel);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attractie = await _context.Attracties
                .SingleOrDefaultAsync(m => m.Id == id);
            if (attractie == null)
            {
                return NotFound();
            }

            return View(attractie);
        }

        // Maak booking
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> maakBooking(BookingViewmodel booking){
            Guid attractieId = Guid.Parse(booking.AttractieId);

            if(ModelState.IsValid){

                var attractie = _context.Attracties.SingleOrDefault(a => a.Id == attractieId );

                if((attractie.Reserveercapaciteit - attractie.Reservaties) == 0){
                    return BadRequest("Reservatie is Vol");
                }
// ---------------------------------------------------
                // Maak een planning item aan -> moet aangepast worden
                PlanningItem planningItem = new PlanningItem();
                planningItem.Id = Guid.NewGuid();
                planningItem.AttractieId = attractieId;
                planningItem.TijdSlotId = Guid.NewGuid();
                //planningItem.PlanningId = Guid.Parse("D7433101-C93D-47D9-AECB-B2537BBDC23A");
                planningItem.PlanningId = Guid.Parse("09AE98DA-F970-4C9A-BEF5-190949078BD8");

                _context.PlanningItems.Add(planningItem);
// --------------------------------------------------------

                // Update reservaties
                attractie.Reservaties = attractie.Reservaties + booking.AantalPlekken;
                var result = _context.Update(attractie).Entity;

                // save
                await _context.SaveChangesAsync();

                // realtime update
                int beschikbaarPlekken = attractie.Reserveercapaciteit - attractie.Reservaties;
                await _hubContext.Clients.All.SendAsync("ReceiveReservatie", beschikbaarPlekken);

                return Redirect("/kaart/index");
            }
            return Redirect("/kaart/details/"+ attractieId);
        }

        
        
        public IActionResult VoegToe()
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
                //planningItem.PlanningId = Guid.Parse("D7433101-C93D-47D9-AECB-B2537BBDC23A");
                planningItem.PlanningId = Guid.Parse("09AE98DA-F970-4C9A-BEF5-190949078BD8");
                
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