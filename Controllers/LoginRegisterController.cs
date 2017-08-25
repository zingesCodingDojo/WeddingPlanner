using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using System.Linq;

namespace WeddingPlanner.Controllers
{
    public class LoginRegisterController : Controller
    {
        private WeddingPlannerContext _context;
 
        public LoginRegisterController(WeddingPlannerContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            ViewBag.Errors = new List<string>();
            ViewBag.LoginErrors = new List<string>();
            return View("Index");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel myNewModel){
            ViewBag.LoginErrors = new List<string>();
            if(ModelState.IsValid){
                //Ping database to check for email.
                if(_context.Users.SingleOrDefault(u => u.Email == myNewModel.Email) == null){
                    User newUser = new User{
                        FirstName = myNewModel.FirstName,
                        LastName = myNewModel.LastName,
                        Email = myNewModel.Email,
                        Password = myNewModel.Password,
                        UserCreated_At = DateTime.Now,
                        UserUpdated_At = DateTime.Now
                    };
                    System.Console.WriteLine("ADDING USER!!!");
                    System.Console.WriteLine("ADDING USER!!!");
                    System.Console.WriteLine("ADDING USER!!!");
                    System.Console.WriteLine("ADDING USER!!!");
                    System.Console.WriteLine("ADDING USER!!!");
                    _context.Add(newUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("id", (int)newUser.UserId);
                    return RedirectToAction("Dashboard", "Planner", new { id = newUser.UserId });
                }
                ViewBag.Errors = "Email is taken";
            }
            else{
                ViewBag.Errors = ModelState.Values;                
            }
            
            System.Console.WriteLine("ERROR ON USER!!!");
            System.Console.WriteLine("ERROR ON USER!!!");
            System.Console.WriteLine("ERROR ON USER!!!");
            System.Console.WriteLine("ERROR ON USER!!!");
            System.Console.WriteLine("ERROR ON USER!!!");
            System.Console.WriteLine("ERROR ON USER!!!");
            return View("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string Email, string Password){
            ViewBag.LoginErrors = new List<string>();
            ViewBag.Errors = new List<string>();
            if(Email == null){
                ViewBag.LoginErrors.Add("Email cannot be blank!");
            }
            if(Password == null){
                ViewBag.LoginErrors.Add("Password cannot be blank!");
            }
            else{
                User myUser = _context.Users.SingleOrDefault( u => u.Email == Email);
                if(myUser == null || myUser.Password != Password){
                    ViewBag.LoginErrors.Add("Invalid Email/Password Combination!");
                }
                else{
                    HttpContext.Session.SetInt32("id", (int)myUser.UserId);
                    return RedirectToAction("Dashboard", "Planner", new { id = myUser.UserId });
                }
            }
            return View("Index");
        }
    }
}
