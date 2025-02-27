using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBlackjack
{
    using System;
    using System.Threading;

    public class Game
    {
        private Deck deck;
        private Player player;
        private Dealer dealer;

        private int playerWins = 0;
        private int dealerWins = 0;

        public Game()
        {
            deck = new Deck();
            dealer = new Dealer();
        }

        public void Start()
        {
            TypeWriter.Write("Välkommen till Blackjack!\nVad är ditt namn?", 35);
            string playerName = Console.ReadLine();

            player = new Player(playerName);

            TypeWriter.Write($"\nHej {playerName}, vi spelar bäst av 5 rundor! Först till 3 vinster tar hem spelet.\n", 35);

            while (playerWins < 3 && dealerWins < 3)
            {
                PlayRound();
                TypeWriter.Write($"\nStällning: {player.Name} {playerWins} - {dealerWins} Dealer\n", 35);
            }

            AnnounceFinalWinner();
        }

        private void PlayRound()
        {
            TypeWriter.Write("\n--- Ny runda startar! ---\n", 35);
            deck = new Deck();
            deck.Shuffle();

            player.Hand.Clear();
            dealer.Hand.Clear();

            DealStartingHands();
            PlayerTurn();

            if (player.GetHandValue() <= 21)
            {
                DealerTurn();
            }

            DetermineWinner();
        }

        private void DealStartingHands()
        {
            TypeWriter.Write("Delar ut kort...\n", 35);
            player.ReceiveCard(deck.DrawCard());
            dealer.ReceiveCard(deck.DrawCard());
            player.ReceiveCard(deck.DrawCard());
            dealer.ReceiveCard(deck.DrawCard());

            TypeWriter.Write(player.ToString(), 30);
            TypeWriter.Write($"Dealern visar: {dealer.Hand[0]} och ett dolt kort.", 30);
        }

        private void PlayerTurn()
        {
            while (true)
            {
                TypeWriter.Write("\nVill du ta ett kort? (y/n)", 35);
                string input = Console.ReadLine();

                if (input.ToLower() == "y")
                {
                    player.ReceiveCard(deck.DrawCard());
                    TypeWriter.Write(player.ToString(), 30);

                    if (player.GetHandValue() > 21)
                    {
                        TypeWriter.Write("Du har över 21! Du förlorar rundan.", 35);
                        dealerWins++;
                        return;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void DealerTurn()
        {
            TypeWriter.Write("\nDealerns tur...", 35);
            TypeWriter.Write($"Dealerns kort: {dealer}", 30);

            while (dealer.ShouldHit())
            {
                TypeWriter.Write("Dealern drar ett kort...", 50);
                dealer.ReceiveCard(deck.DrawCard());
                TypeWriter.Write(dealer.ToString(), 30);
            }

            TypeWriter.Write("Dealern stannar.", 35);
        }

        private void DetermineWinner()
        {
            int playerScore = player.GetHandValue();
            int dealerScore = dealer.GetHandValue();

            TypeWriter.Write("\nSlutresultat:", 35);
            TypeWriter.Write(player.ToString(), 30);
            TypeWriter.Write(dealer.ToString(), 30);

            if (playerScore > 21)
            {
                TypeWriter.Write("Du förlorade rundan!", 35);
                dealerWins++;
            }
            else if (dealerScore > 21 || playerScore > dealerScore)
            {
                TypeWriter.Write("Grattis! Du vann rundan!", 35);
                playerWins++;
            }
            else if (playerScore == dealerScore)
            {
                TypeWriter.Write("Det blev oavgjort! (Push)", 35);
            }
            else
            {
                TypeWriter.Write("Dealern vann rundan!", 35);
                dealerWins++;
            }
        }

        private void AnnounceFinalWinner()
        {
            TypeWriter.Write("\n--- Spelet är avgjort! ---\n", 50);

            if (playerWins == 3)
            {
                TypeWriter.Write($"Grattis {player.Name}! Du vann spelet med {playerWins}- {dealerWins}!", 50);
            }
            else
            {
                TypeWriter.Write($"Dealern vann spelet med {dealerWins} - {playerWins}. Bättre lycka nästa gång!", 50);
            }
        }

        /*private void TypeWriter.Write(string text, int speed = 35)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(speed);
            }
            Console.WriteLine();
        }*/
    }

}
