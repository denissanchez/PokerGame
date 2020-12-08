using PokerApp.Models;
using PokerApp.ViewModels;
using System.Collections.Generic;

namespace PokerApp.Contracts
{
    public interface IDealer
    {
        List<PlayerViewModel> RepartirCartas(List<PlayerViewModel> players);
        void VerificarGanadores(List<PlayerViewModel> players);
    }
}
