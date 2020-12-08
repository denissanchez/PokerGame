using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerApp.Services
{
    public class UtilService
    {
        public static int NumeroAleatorio(int min, int max)
        {
            Random randomizer = new Random();
            return randomizer.Next(min, max);
        }

        public static int NumeroAleatorioDistintoA(int min, int max, int numero)
        {
            var valorDistinto = 0;

            do {
                valorDistinto = NumeroAleatorio(min, max);
            } while (valorDistinto == numero);

            return valorDistinto;
        }
    }
}
