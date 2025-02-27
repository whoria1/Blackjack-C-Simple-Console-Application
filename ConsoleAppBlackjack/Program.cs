using System.Numerics;

namespace ConsoleAppBlackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Skapar en kortlek och blandar den
            Deck deck = new Deck();
            deck.Shuffle();

        // Skapat spelare och en dealer via konstruktor 
        string dittNamn;
        Console.WriteLine("Vad heter du?");

        dittNamn = Console.ReadLine();

        Player player1 = new Player(dittNamn);
        Dealer dealerHusetLuffare = new Dealer();

        // Ger spelaren två kort
        player1.ReceiveCard(deck.DrawCard());
        player1.ReceiveCard(deck.DrawCard());

        // Ger dealern två kort
        dealerHusetLuffare.ReceiveCard(deck.DrawCard());
        dealerHusetLuffare.ReceiveCard(deck.DrawCard());

        // Skriver ut bådas händer
        Console.WriteLine(player1);
        Console.WriteLine($"Dealer visar: {dealerHusetLuffare.Hand[0]} och ett dolt kort.");

        Console.ReadKey();
           */
            Player playerDaniel = new Player("Daniel");
            Card drawforDaniel = new("10", "Diamonds", 10);

            TypeWriter.Write(playerDaniel.ToString());
            TypeWriter.Write(drawforDaniel.ToString());

            Game game = new Game();
            game.Start();

        }
    }


}
