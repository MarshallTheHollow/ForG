using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GRate.ViewModel; 
using GRate.Models; 
using Microsoft.AspNetCore.Authorization;

namespace GRate.Controllers
{
    public class GameController : Controller
    {
        private ApplicationContext _context;
        public GameController(ApplicationContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Register(string message, string errmessage)
        {
            ViewBag.message = message;
            ViewBag.errmessage = errmessage;
            ViewBag.Genre = _context.Genres;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(GameRegisterModel model)
        {
            if (ModelState.IsValid)
            {              
                Game game = await _context.Games.FirstOrDefaultAsync(g => g.GameName == model.GameName);
                if (game == null)
                {
                    game = new Game { GameName = model.GameName, CompanyName = model.CompanyName, GameDiscription = model.GameDiscription, GameReleaseTime = model.GameReleaseTime};
                    Genre GameGenre = await _context.Genres.FirstOrDefaultAsync(gen => gen.Name ==  model.Genre);
                    if (GameGenre != null)
                        game.Genre = GameGenre;

                    _context.Games.Add(game);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Register", "Game", new { message = "Done" });
                }
                else
                    ModelState.AddModelError("", "Некорректные данные");
            }
            return RedirectToAction("Register", "Game", new { errmessage = $"{model.Genre} " + $"{model.GameName} " + $"{model.CompanyName} " + $"{model.GameDiscription} " + $"{model.GameReleaseTime} " });
        }

        [Authorize(Roles = "admin")]
        public IActionResult RegisterGenre(string message, string errmessage)
        {
            ViewBag.message = message;
            ViewBag.errmessage = errmessage;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterGenre(GenreRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Genre genre = await _context.Genres.FirstOrDefaultAsync(gg => gg.Name == model.Name);
                if (genre == null)
                {
                    genre = new Genre { Name = model.Name};                   
                    _context.Genres.Add(genre);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("RegisterGenre", "Game", new { message = "Done" });
                }
                else
                    ModelState.AddModelError("", "Некорректные данные");
            }
            return RedirectToAction("RegisterGenre", "Game", new { errmessage = "Nop" });
        }
    }
}
