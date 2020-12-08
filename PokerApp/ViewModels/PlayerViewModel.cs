using PokerApp.Models;
using System.Collections.Generic;

namespace PokerApp.ViewModels
{
    public class PlayerViewModel
    {
        public string Name { get; set; }
        public List<Carta> Cartas { get; set; }
        public int Puntaje { get; set; }
        public string Estrategia { get; set; }
    }
}
