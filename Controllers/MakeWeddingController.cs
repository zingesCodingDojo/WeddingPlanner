using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using System.Linq;

namespace WeddingPlanner.Controllers
{
    public class MakeWeddingController : Controller
    {
        private WeddingPlannerContext _context;
 
        public MakeWeddingController(WeddingPlannerContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("planner")]
        public IActionResult PlannerIndex(){
            ViewBag.Errors = new List<string>();
            return View("MakingWedding");
        }

        [HttpGet]
        [Route("Mlogout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "LoginRegister");
        }

        [HttpGet]
        [Route("plannerDashboard")]
        public IActionResult PlannerDashBoard(){
            int? getMyint = HttpContext.Session.GetInt32("id");
            return RedirectToAction("Dashboard", "Planner", new {id = (int)getMyint});
        }

        [HttpPost]
        [Route("createWedding")]
        public IActionResult CreateWedding(RegisterWeddingModel myWedding){
            ViewBag.Errors = new List<string>();
           
            if(ModelState.IsValid){
                System.Console.WriteLine("WEDDING WAS VALID!");
                System.Console.WriteLine("WEDDING WAS VALID!");
                System.Console.WriteLine("WEDDING WAS VALID!");
                System.Console.WriteLine("WEDDING WAS VALID!");
                if(myWedding.Date > DateTime.Now){
                    System.Console.WriteLine("WEDDING WAS VALID!");
                    System.Console.WriteLine("WEDDING DATE VALID!");
                    System.Console.WriteLine("WEDDING DATE VALID!");
                    System.Console.WriteLine("WEDDING DATE VALID!");
                    WeddingPlanner.Models.Wedding newWedding = new WeddingPlanner.Models.Wedding{
                        WedderOne = myWedding.WedderOne,
                        WedderTwo = myWedding.WedderTwo,
                        Date = myWedding.Date,
                        WeddingAddress = myWedding.WeddingAddress,
                        WedCreated_At = DateTime.Now,
                        WedUpdated_At = DateTime.Now,
                        Userid = (int)HttpContext.Session.GetInt32("id")

                    };
                    _context.Add(newWedding);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard", "Planner", new { id = (int)HttpContext.Session.GetInt32("id") });
                }
                ViewBag.BadDate = ("Date cannot be from the past");
            }
            else{
                ViewBag.Errors = ModelState.Values;
            }
            return View("MakingWedding");
        }
    }
}