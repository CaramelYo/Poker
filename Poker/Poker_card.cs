using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Poker_card
    {
        public Poker_card(char suit, int num)
        {
            this.suit = suit;
            this.num = num;
        }

        public char Suit
        {
            get { return suit; }
        }

        public int Num
        {
            get { return num; }
        }

        char suit;
        int num;
    }
}
