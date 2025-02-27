using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBlackjack
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; private set; } = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public void ReceiveCard(Card card)
        {
            Hand.Add(card);
        }

        public int GetHandValue()
        {
            int value = 0;
            int aceCount = 0;

            foreach (var card in Hand)
            {
                value += card.Value;
                if (card.Rank == "A") aceCount++;
            }

            // Om vi har ess och över 21, justera ess-värdet från 11 till 1
            while (value > 21 && aceCount > 0)
            {
                value -= 10;
                aceCount--;
            }

            return value;
        }

        public override string ToString()
        {
            return $"{Name}'s Hand: {string.Join(", ", Hand)} (Total Value: {GetHandValue()})";
        }
    }
}
