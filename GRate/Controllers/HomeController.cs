using GRate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GRate.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _context;
        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {           
            return View();
        }

        [Authorize]
        public IActionResult LK(string message, string errmessage)
        {           
            ViewBag.message = message;
            ViewBag.errmessage = errmessage;
            ViewBag.role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;           
            return View();
        }

        [Authorize]
        public IActionResult Friends()
        {
            ViewBag.role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return View();
        }

        [Authorize]
        public IActionResult MyGames()
        {
            User user = _context.Users.FirstOrDefault(user => user.Login == User.Identity.Name);
            ViewBag.uId = user.Id;
            ViewBag.Review = _context.Review.ToArray();
            ViewBag.role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
