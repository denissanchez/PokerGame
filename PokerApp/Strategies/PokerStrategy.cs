using PokerApp.Contracts;
using PokerApp.Models;
using PokerApp.ViewModels;
using System.Linq;

namespace PokerApp.Strategies
{
    public class PokerStrategy : IMano
    {
        public string GetName()
        {
            return "Poker";
        }

        public int GetPuntaje()
        {
            return 900;
        }

        public bool Verificar(PlayerViewModel player)
        {
            var grupos = player.Cartas.GroupBy(o => o.Valor).ToList();

            var flag = false;

            if (grupos.Count == 2) {
                if (grupos[0].ToList().Count == 4)
                    flag = true;
                else if (grupos[1].ToList().Count == 4)
                    flag = true;
            }

            return flag;
        }
    }
}
