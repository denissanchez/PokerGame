using PokerApp.ViewModels;

namespace PokerApp.Contracts
{
    public interface IMano
    {
        int GetPuntaje();
        string GetName();
        bool Verificar(PlayerViewModel player);
    }
}
