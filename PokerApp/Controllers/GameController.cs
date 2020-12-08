using Microsoft.AspNetCore.Mvc;
using PokerApp.Contracts;
using PokerApp.ViewModels;
using System.Collections.Generic;

namespace PokerApp.Controllers
{
    public class GameController : Controller
    {
        private IDealer _dealer;

        public GameController(IDealer dealer)
        {
            _dealer = dealer;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Resultado(List<PlayerViewModel> players)
        {
            _dealer.RepartirCartas(players);
            _dealer.GetPlayersStrategies(players);

            var positionsTable = _dealer.MakePositionsTable(players);
            return View(positionsTable);
        }

    }
}
