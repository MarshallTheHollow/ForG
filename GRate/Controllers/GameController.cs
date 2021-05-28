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
        public IActionResult Register()
        {
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
                    game = new Game { GameName = model.GameName, CompanyName = model.GameName, GameDiscription = model.GameDiscription, GameReleaseTime = model.GameReleaseTime, Image = model.Image };
                    Genre GameGenre = await _context.Genres.FirstOrDefaultAsync(r => r.Name == model.Genre);
                    if (GameGenre != null)
                        game.Genre = GameGenre;

                    _context.Games.Add(game);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("LK", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные данные");
            }
            return RedirectToAction("LK", "Home");
        }
    }
}
