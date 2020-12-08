using PokerApp.Contracts;
using PokerApp.ViewModels;
using System.Linq;

namespace PokerApp.Strategies
{
    public class EscaleraStrategy : IMano
    {
        public string GetName()
        {
            return "Escalera";
        }

        public int GetPuntaje()
        {
            return 600;
        }

        public bool Verificar(PlayerViewModel player)
        {
            var cartas = player.Cartas.OrderBy(o => o.Valor).ToList();

            var numeroInicial = cartas[0].Valor;
            var index = 0;
            var flag = true;

            do
            {
                if (cartas[index].Valor != numeroInicial)
                {
                    flag = false;
                    break;
                }
                numeroInicial++;
                index++;
            } while (index < 5);

            return flag;
        }
    }
}
