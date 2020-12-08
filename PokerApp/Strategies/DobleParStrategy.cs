using PokerApp.Contracts;
using PokerApp.ViewModels;
using System.Linq;

namespace PokerApp.Strategies
{
    public class DobleParStrategy : IMano
    {
        public string GetName()
        {
            return "Doble Par";
        }

        public int GetPuntaje()
        {
            return 400;
        }

        public bool Verificar(PlayerViewModel player)
        {
            var grupos = player.Cartas.GroupBy(o => o.Valor).ToList();

            if (grupos.Count == 3)
            {
                var gruposOrdenados = grupos.OrderByDescending(o => o.ToList().Count).ToList();

                if (gruposOrdenados[0].ToList().Count == gruposOrdenados[1].ToList().Count && gruposOrdenados[2].ToList().Count == 1)
                    return true;
            }

            return false;
        }
    }
}
