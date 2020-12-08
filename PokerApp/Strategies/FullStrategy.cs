using PokerApp.Contracts;
using PokerApp.Models;
using PokerApp.Services;
using PokerApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PokerApp.Strategies
{
    public class FullStrategy : IMano
    {
        public string GetName()
        {
            return "Full";
        }

        public int GetPuntaje()
        {
            return 800;
        }

        public bool Verificar(PlayerViewModel player)
        {
            var grupos = player.Cartas.GroupBy(o => o.Valor).ToList();

            var flag = false;

            if (grupos.Count == 2)
            {
                if (grupos[0].ToList().Count == 3 && grupos[1].ToList().Count == 2)
                    flag = true;
                else if (grupos[0].ToList().Count == 2 && grupos[1].ToList().Count == 3)
                    flag = true;
            }

            return flag;
        }
    }
}
