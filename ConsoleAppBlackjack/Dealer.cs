using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBlackjack
{
    public class Dealer : Player
    {
        public Dealer() : base("Dealer") { }

        public bool ShouldHit()
        {
            return GetHandValue() < 17; // Blackjack-regel: Dealern drar tills minst 17
        }
    }
}
