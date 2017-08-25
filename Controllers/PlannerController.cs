using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class PlannerController : Controller
    {
        private WeddingPlannerContext _context;
 
        public PlannerController(WeddingPlannerContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("planner/{id}")]
        public IActionResult Dashboard(){
            ViewBag.WeddingSeason = _context.Weddings.Include(user => user.User).Include(guest => guest.Guests).ToList();
            ViewBag.GuestPeeps = _context.Guests.Include(u => u.User).Include(p => p.Wedding).ToList();
            ViewBag.MyPerson = _context.Users.Where(u => u.UserId == (int)HttpContext.Session.GetInt32("id")).Include(g=> g.Guests).Include(w => w.Wedding);
            ViewBag.MyID = (int)HttpContext.Session.GetInt32("id");

            return View("Dashboard");
        }
        [HttpGet]
        [Route("Dlogout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "LoginRegister");
        }
        
        [HttpGet]
        [Route("newWeddingPage")]
        public IActionResult NewWeddingPage(){
            return RedirectToAction("PlannerIndex", "MakeWedding");
        }

        [HttpGet]
        [Route("togetherWedding/{myWeddingId}")]
        public IActionResult TogetherWedding(int myWeddingId){
            return RedirectToAction("Single", "Together", new { id = myWeddingId});
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id){
            List<Guests> RemoveFirst = _context.Guests.Where(w => w.WeddingId == id).Include(p => p.Wedding).ToList();
            if(RemoveFirst != null){
                foreach(Guests item in RemoveFirst){
                    _context.Remove(item);
                }
            }
            Wedding RemoveSecond = _context.Weddings.SingleOrDefault(u => u.WeddingId == id);
            
            _context.Weddings.Remove(RemoveSecond);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        [Route("toggler/{id}")]
        public IActionResult Toggle(int id, string RSVP){
            System.Console.WriteLine("INSIDE TOGGGGGLER");
            System.Console.WriteLine("INSIDE TOGGGGGLER");
            System.Console.WriteLine("INSIDE TOGGGGGLER");
            System.Console.WriteLine("INSIDE TOGGGGGLER");
            System.Console.WriteLine("INSIDE TOGGGGGLER");
            System.Console.WriteLine("INSIDE TOGGGGGLER");
            System.Console.WriteLine("INSIDE TOGGGGGLER");
            Wedding singleWedding = _context.Weddings.SingleOrDefault( u => u.WeddingId == id);
            if(RSVP == "RSVP"){
                System.Console.WriteLine("Adding GUY");
                System.Console.WriteLine("Adding GUY");
                System.Console.WriteLine("Adding GUY");
                System.Console.WriteLine("Adding GUY");
                
                Guests newInstance = new Guests{
                    Action = RSVP,
                    WeddingId = singleWedding.WeddingId,
                    UserId = (int)HttpContext.Session.GetInt32("id"),
                    GCreated_At = DateTime.Now,
                    GUpdated_At = DateTime.Now,
                };
                _context.Add(newInstance);
            }
            else{
                
                List<Guests> myGuest = _context.Guests.Where(i => i.WeddingId == id).Where( p => p.UserId == (int)HttpContext.Session.GetInt32("id")).ToList();
                if(myGuest != null || myGuest.Count != 0){
                    System.Console.WriteLine("DELETING");
                    System.Console.WriteLine("DELETING");
                    System.Console.WriteLine("DELETING");
                    System.Console.WriteLine("DELETING");
                    System.Console.WriteLine("DELETING");
                    foreach(Guests item in myGuest){
                        _context.Remove(item);
                    }
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}