using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBlackjack
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        private static readonly string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        private static readonly string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private static readonly Dictionary<string, int> cardValues = new Dictionary<string, int>
    {
        { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 },
        { "7", 7 }, { "8", 8 }, { "9", 9 }, { "10", 10 }, { "J", 10 },
        { "Q", 10 }, { "K", 10 }, { "A", 11 }  // Ess kan vara 11 eller 1 (hanteras i spelet)
    };

        public Deck()
        {
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card(suit, rank, cardValues[rank]));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]); // Swap
            }
        } 
           

        public Card DrawCard()
        {
            if (cards.Count == 0)
                throw new InvalidOperationException("Deck is empty!");//Dåligt gjort säger Kingen, Exception = Undantag, inte saker som faktiskt kan hända.

            Card drawnCard = cards[0];
            cards.RemoveAt(0);
            return drawnCard;
        }
    }
}
