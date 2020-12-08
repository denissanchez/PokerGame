using PokerApp.Contracts;
using PokerApp.ViewModels;
using System.Linq;

namespace PokerApp.Strategies
{
    public class TrioStrategy : IMano
    {
        public string GetName()
        {
            return "Trio";
        }

        public int GetPuntaje()
        {
            return 500;
        }

        public bool Verificar(PlayerViewModel player)
        {
            var grupos = player.Cartas.GroupBy(o => o.Valor).ToList();

            if (grupos.Count == 3) {
                var gruposOrdenados = grupos.OrderByDescending(o => o.ToList().Count).ToList();

                if (gruposOrdenados[0].ToList().Count == 3 && gruposOrdenados[1].ToList().Count == gruposOrdenados[2].ToList().Count)
                    return true;
            }

            return false;
        }
    }
}
