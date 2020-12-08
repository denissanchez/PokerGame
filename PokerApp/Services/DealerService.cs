using PokerApp.Contracts;
using PokerApp.Models;
using PokerApp.Strategies;
using PokerApp.ViewModels;
using System.Collections.Generic;

namespace PokerApp.Services
{
    public class DealerService : IDealer
    {
        private Dictionary<int, Carta> cartas;

        private EscaleraColorStrategy escaleraColorStrategy;
        private PokerStrategy pokerStrategy;
        private FullStrategy fullStrategy;
        private ColorStrategy colorStrategy;
        private EscaleraStrategy escaleraStrategy;
        private TrioStrategy trioStrategy;
        private DobleParStrategy dobleParStrategy;
        private UnParStrategy unParStrategy;
        private CartaAltaStrategy cartaAltaStrategy;

        public DealerService()
        {
            ObtenerCartas();
            escaleraColorStrategy = new EscaleraColorStrategy();
            pokerStrategy = new PokerStrategy();
            fullStrategy = new FullStrategy();
            colorStrategy = new ColorStrategy();
            escaleraStrategy = new EscaleraStrategy();
            trioStrategy = new TrioStrategy();
            dobleParStrategy = new DobleParStrategy();
            unParStrategy = new UnParStrategy();
            cartaAltaStrategy = new CartaAltaStrategy();
        }

        private void ObtenerCartas()
        {
            cartas = new Dictionary<int, Carta>();

            var cartaId = 1;

            for (int i = 1; i <= 4; i++)
            {
                string palo = i switch
                {
                    1 => "Corazones",
                    2 => "Diamantes",
                    3 => "Espadas",
                    _ => "Trebol",
                };

                for (int j = 1; j <= 13; j++)
                {
                    cartas.Add(cartaId, new Carta {
                        Valor = j,
                        Palo = palo
                    });

                    cartaId++;
                }
            }
        }

        public List<PlayerViewModel> RepartirCartas(List<PlayerViewModel> players)
        {
            foreach (var player in players)
            {
                player.Cartas = new List<Carta>();

                for (int i = 1; i <= 5; i++) {
                    var randomId = UtilService.NumeroAleatorio(1, cartas.Count + 1);
                    var carta = cartas.GetValueOrDefault(randomId);
                    player.Cartas.Add(carta);
                    cartas.Remove(randomId);
                }
            }

            return players;
        }

        public bool VerificarMano(IMano mano, PlayerViewModel player)
        {
            var respuesta = mano.Verificar(player);
            if (respuesta) {
                player.Puntaje = mano.GetPuntaje();
                player.Estrategia = mano.GetName();
            }
            return respuesta;
        }

        public void VerificarGanadores(List<PlayerViewModel> players)
        {
            foreach (var player in players)
            {
                if (VerificarMano(escaleraColorStrategy, player))
                    continue;
                else if (VerificarMano(pokerStrategy, player))
                    continue;
                else if (VerificarMano(fullStrategy, player))
                    continue;
                else if (VerificarMano(colorStrategy, player))
                    continue;
                else if (VerificarMano(escaleraStrategy, player))
                    continue;
                else if (VerificarMano(trioStrategy, player))
                    continue;
                else if (VerificarMano(dobleParStrategy, player))
                    continue;
                else if (VerificarMano(unParStrategy, player))
                    continue;
                else
                    VerificarMano(cartaAltaStrategy, player);
            }
        }
    }
}
