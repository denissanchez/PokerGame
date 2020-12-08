using PokerApp.Contracts;

namespace PokerApp.Services
{
    public class PaloService : PlayerViewMode
    {
        public string GetPalo()
        {
            var number = UtilService.NumeroAleatorio(1, 4);
            if (number == 1)
                return "Corazon";
            else if (number == 2)
                return "Diamante";
            else if (number == 3)
                return "Espada";
            return "Trebol";
        }
    }
}
