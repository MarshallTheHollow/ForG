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
        private AppGamesContext _gcontext;
        public GameController(AppGamesContext context)
        {
            _gcontext = context;
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
                Game game = await _gcontext.Games.FirstOrDefaultAsync(g => g.GameName == model.GameName);
                if (game == null)
                {
                    game = new Game { GameName = model.GameName, CompanyName = model.GameName, GameDiscription = model.GameDiscription, GameReleaseTime = model.GameReleaseTime, Image = model.Image };
                    Genre GameGenre = await _gcontext.Genres.FirstOrDefaultAsync(r => r.Name == model.Genre);
                    if (GameGenre != null)
                        game.Genre = GameGenre;

                    _gcontext.Games.Add(game);
                    await _gcontext.SaveChangesAsync();

                    return RedirectToAction("LK", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные данные");
            }
            return RedirectToAction("LK", "Home");
        }
    }
}
