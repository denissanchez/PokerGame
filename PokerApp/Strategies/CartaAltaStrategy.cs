
using PokerApp.Contracts;
using PokerApp.ViewModels;

namespace PokerApp.Strategies
{
    public class CartaAltaStrategy : IMano
    {
        public string GetName()
        {
            return "Carta Alta";
        }

        public int GetPuntaje()
        {
            return 100;
        }

        public bool Verificar(PlayerViewModel player)
        {
            return true;
        }
    }
}
