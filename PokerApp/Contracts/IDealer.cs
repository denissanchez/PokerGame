using PokerApp.Models;
using PokerApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PokerApp.Contracts
{
    public interface IDealer
    {
        List<PlayerViewModel> RepartirCartas(List<PlayerViewModel> players);
        void GetPlayersStrategies(List<PlayerViewModel> players);
        Dictionary<int, IGrouping<int, PlayerViewModel>> MakePositionsTable(List<PlayerViewModel> players);
    }
}
