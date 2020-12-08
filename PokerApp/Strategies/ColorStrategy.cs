using PokerApp.Contracts;
using PokerApp.Models;
using PokerApp.Services;
using PokerApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PokerApp.Strategies
{
    public class ColorStrategy : IMano
    {
        public string GetName()
        {
            return "Color";
        }

        public int GetPuntaje()
        {
            return 700;
        }

        public bool Verificar(PlayerViewModel player)
        {
            var grupos = player.Cartas.GroupBy(o => o.Palo).ToList();
            return grupos.Count == 1;
        }
    }
}
