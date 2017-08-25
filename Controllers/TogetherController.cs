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
    public class TogetherController : Controller
    {
        private WeddingPlannerContext _context;
 
        public TogetherController(WeddingPlannerContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("Single/{id}")]
        public IActionResult Single(int id){
            ViewBag.Individuals = _context.Guests.Where(u => u.WeddingId == id).Include(user => user.User).Include(wedding => wedding.Wedding).ToList();
            
            return View("TogetherWedding");
        }
        [HttpGet]
        [Route("Tlogout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "LoginRegister");
        }

        [HttpGet]
        [Route("GotoPlanner")]
        public IActionResult GotoPlanner(){
            int? getMyint = HttpContext.Session.GetInt32("id");
            return RedirectToAction("Dashboard", "Planner", new {id = (int)getMyint});
        }
    }
}
