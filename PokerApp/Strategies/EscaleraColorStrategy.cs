using PokerApp.Contracts;
using PokerApp.Models;
using PokerApp.Services;
using PokerApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PokerApp.Strategies
{
    public class EscaleraColorStrategy : IMano
    {
        public string GetName()
        {
            return "Escalera Color";
        }

        public int GetPuntaje()
        {
            return 1000;
        }

        public bool Verificar(PlayerViewModel player)
        {
            var grupos = player.Cartas.GroupBy(o => o.Palo).ToList();

            if (grupos.Count > 1)
                return false;

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
