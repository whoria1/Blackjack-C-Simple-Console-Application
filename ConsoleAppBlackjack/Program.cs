using System.Numerics;

namespace ConsoleAppBlackjack
{
    class Program //This is the test branch
    {
        static void Main(string[] args)
        {
            Player playerDaniel = new Player("Daniel");
            Card drawforDaniel = new("10", "Diamonds", 10);

            TypeWriter.Write(playerDaniel.ToString());
            TypeWriter.Write(drawforDaniel.ToString());

            Game game = new Game();
            game.Start();

        }
    }


}
