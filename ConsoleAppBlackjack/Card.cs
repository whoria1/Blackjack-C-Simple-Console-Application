using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBlackjack
{
    public class Card
    {
        public string Suit { get; set; }  // Färg (Hearts, Diamonds, Clubs, Spades)
        public string Rank { get; set; }  // Kortets värde (2, 3, 4... J, Q, K, A)
        public int Value { get; set; }    // Numeriskt värde för spelet

        public Card(string suit, string rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";  // Visar kortets rank och färg
        }
    }
}
