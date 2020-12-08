using PokerApp.Contracts;
using PokerApp.Models;
using PokerApp.Services;
using PokerApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PokerApp.Strategies
{
    public class UnParStrategy : IMano
    {
        public string GetName()
        {
            return "Un Par";
        }

        public int GetPuntaje()
        {
            return 300;
        }

        public bool Verificar(PlayerViewModel player)
        {
            var grupos = player.Cartas.GroupBy(o => o.Valor).ToList();

            if (grupos.Count == 4)
            {
                var gruposOrdenados = grupos.OrderByDescending(o => o.ToList().Count).ToList();

                if (gruposOrdenados[0].ToList().Count == 2)
                    return true;
            }

            return false;
        }
    }
}
