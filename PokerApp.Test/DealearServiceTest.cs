using NUnit.Framework;
using PokerApp.Services;
using PokerApp.ViewModels;
using System.Collections.Generic;

namespace PokerApp.Test
{
    class DealearServiceTest
    {
        private List<PlayerViewModel> GetPlayers (int numPlayers = 5)
        {
            var players = new List<PlayerViewModel>();

            for (var i = 0; i < numPlayers; i++)
                players.Add(new PlayerViewModel { Name = "Jugador " + i });

            return players;
        }

        [Test]
        public void ReparteCincoCartasADosJugadores()
        {
            var dealer = new DealerService();
            var players = GetPlayers(2);

            dealer.RepartirCartas(players);

            Assert.That(players[0].Cartas.Count == 5);
            Assert.That(players[1].Cartas.Count == 5);
        }

        [Test]
        public void ReparteCincoCartasACincoJugadores()
        {
            var dealer = new DealerService();
            var players = GetPlayers(5);

            dealer.RepartirCartas(players);

            Assert.That(players[0].Cartas.Count == 5);
            Assert.That(players[1].Cartas.Count == 5);
            Assert.That(players[2].Cartas.Count == 5);
            Assert.That(players[3].Cartas.Count == 5);
            Assert.That(players[4].Cartas.Count == 5);
        }

        [Test]
        public void VerificarSiRetornaEscaleraDeColorStrategy()
        {
            var dealer = new DealerService();
            var players = GetPlayers(1);

            players[0].Cartas = new List<Models.Carta>() {
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 9
                    },
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 5
                    },
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 7
                    },
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 6
                    },
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 8
                    },
            };

            dealer.GetPlayersStrategies(players);
            Assert.AreEqual(players[0].Estrategia, "Escalera Color");
        }


        [Test]
        public void VerificarSiRetornaPokerStrategy()
        {
            var dealer = new DealerService();
            var players = GetPlayers(1);

            players[0].Cartas = new List<Models.Carta>() {
                new Models.Carta
                    {
                        Palo = "Diamamantes",
                        Valor = 1
                    },
                new Models.Carta
                    {
                        Palo = "Diamamantes",
                        Valor = 7
                    },
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 1
                    },
                new Models.Carta
                    {
                        Palo = "Corazones",
                        Valor = 1
                    },
                new Models.Carta
                    {
                        Palo = "Trebol",
                        Valor = 1
                    },
            };

            dealer.GetPlayersStrategies(players);
            Assert.AreEqual(players[0].Estrategia, "Poker");
        }

        [Test]
        public void VerificarSiRetornaFullStrategy()
        {
            var dealer = new DealerService();
            var players = GetPlayers(1);

            players[0].Cartas = new List<Models.Carta>() {
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 10
                    },
                new Models.Carta
                    {
                        Palo = "Corazones",
                        Valor = 10
                    },
                new Models.Carta
                    {
                        Palo = "Trebol",
                        Valor = 13
                    },
                new Models.Carta
                    {
                        Palo = "Corazones",
                        Valor = 13
                    },
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 13
                    },
            };

            dealer.GetPlayersStrategies(players);
            Assert.AreEqual(players[0].Estrategia, "Full");
        }

        [Test]
        public void VerificarSiRetornaColorStrategy()
        {
            var dealer = new DealerService();
            var players = GetPlayers(1);

            players[0].Cartas = new List<Models.Carta>() {
                new Models.Carta
                    {
                        Palo = "Trebol",
                        Valor = 12
                    },
                new Models.Carta
                    {
                        Palo = "Trebol",
                        Valor = 10
                    },
                new Models.Carta
                    {
                        Palo = "Trebol",
                        Valor = 9
                    },
                new Models.Carta
                    {
                        Palo = "Trebol",
                        Valor = 7
                    },
                new Models.Carta
                    {
                        Palo = "Trebol",
                        Valor = 4
                    },
            };

            dealer.GetPlayersStrategies(players);
            Assert.AreEqual(players[0].Estrategia, "Color");
        }

        [Test]
        public void VerificarSiRetornaEscaleraStrategy()
        {
            var dealer = new DealerService();
            var players = GetPlayers(1);

            players[0].Cartas = new List<Models.Carta>() {
                new Models.Carta
                    {
                        Palo = "Corazones",
                        Valor = 2
                    },
                new Models.Carta
                    {
                        Palo = "Diamantes",
                        Valor = 3
                    },
                new Models.Carta
                    {
                        Palo = "Trebol",
                        Valor = 4
                    },
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 5
                    },
                new Models.Carta
                    {
                        Palo = "Corazones",
                        Valor = 6
                    },
            };

            dealer.GetPlayersStrategies(players);
            Assert.AreEqual(players[0].Estrategia, "Escalera");
        }

        [Test]
        public void VerificarSiRetornaTrioStrategy()
        {
            var dealer = new DealerService();
            var players = GetPlayers(1);

            players[0].Cartas = new List<Models.Carta>() {
                new Models.Carta
                    {
                        Palo = "Diamantes",
                        Valor = 13
                    },
                new Models.Carta
                    {
                        Palo = "Corazones",
                        Valor = 13
                    },
                new Models.Carta
                    {
                        Palo = "Trebol",
                        Valor = 13
                    },
                new Models.Carta
                    {
                        Palo = "Trebol",
                        Valor = 4
                    },
                new Models.Carta
                    {
                        Palo = "Diamanates",
                        Valor = 7
                    },
            };

            dealer.GetPlayersStrategies(players);
            Assert.AreEqual(players[0].Estrategia, "Trio");
        }

        [Test]
        public void VerificarSiRetornaDobleParStrategy()
        {
            var dealer = new DealerService();
            var players = GetPlayers(1);

            players[0].Cartas = new List<Models.Carta>() {
                new Models.Carta
                    {
                        Palo = "Diamantes",
                        Valor = 8
                    },
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 8
                    },
                new Models.Carta
                    {
                        Palo = "Corazones",
                        Valor = 6
                    },
                new Models.Carta
                    {
                        Palo = "Trebol",
                        Valor = 6
                    },
                new Models.Carta
                    {
                        Palo = "Corazones",
                        Valor = 7
                    },
            };

            dealer.GetPlayersStrategies(players);
            Assert.AreEqual(players[0].Estrategia, "Doble Par");
        }

        [Test]
        public void VerificarSiRetornaUnParStrategy()
        {
            var dealer = new DealerService();
            var players = GetPlayers(1);

            players[0].Cartas = new List<Models.Carta>() {
                new Models.Carta
                    {
                        Palo = "Diamantes",
                        Valor = 2
                    },
                new Models.Carta
                    {
                        Palo = "Corazones",
                        Valor = 6
                    },
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 8
                    },
                new Models.Carta
                    {
                        Palo = "Diamantes",
                        Valor = 1
                    },
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 1
                    },
            };

            dealer.GetPlayersStrategies(players);
            Assert.AreEqual(players[0].Estrategia, "Un Par");
        }

        [Test]
        public void VerificarSiRetornaCartaAltaStrategy()
        {
            var dealer = new DealerService();
            var players = GetPlayers(1);

            players[0].Cartas = new List<Models.Carta>() {
                new Models.Carta
                    {
                        Palo = "Trebol",
                        Valor = 13
                    },
                new Models.Carta
                    {
                        Palo = "Corazones",
                        Valor = 11
                    },
                new Models.Carta
                    {
                        Palo = "Corazones",
                        Valor = 10
                    },
                new Models.Carta
                    {
                        Palo = "Diamantes",
                        Valor = 2
                    },
                new Models.Carta
                    {
                        Palo = "Espadas",
                        Valor = 5
                    },
            };

            dealer.GetPlayersStrategies(players);
            Assert.AreEqual(players[0].Estrategia, "Carta Alta");
        }
    }
}
