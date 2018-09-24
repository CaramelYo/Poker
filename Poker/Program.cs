using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            bool conti = true;
            while (conti)
            {
                Console.WriteLine("輸入y來開始隨機發牌，輸入n結束遊戲");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "y":
                        break;
                    case "n":
                        Console.WriteLine("goodbye");
                        conti = false;
                        continue;
                    default:
                        Console.WriteLine("輸入有問題，請重新輸入");
                        continue;
                }

                List<Poker_card> pokers = new List<Poker_card>();
                for (int i = 0; i < 4; ++i)
                    for (int j = 1; j <= 13; ++j)
                        pokers.Add(new Poker_card(suit_names[i], j));

                // randomly deal all cards to 4 players
                Poker_card[,] players = new Poker_card[4, 13];
                Random r = new Random();

                for (int i = 0; i < 4; ++i)
                {
                    for (int j = 0; j < 13; ++j)
                    {
                        int card_index = r.Next(0, pokers.Count);
                        players[i, j] = pokers[card_index];
                        pokers.RemoveAt(card_index);
                    }
                }
                
                // print the cards
                for (int i = 0; i < 4; ++i)
                {
                    string s = "";
                    for (int j = 0; j < 13; ++j)
                    {
                        Poker_card c = players[i, j];
                        s += c.Suit.ToString() + "_" + c.Num.ToString() + " ";
                    }

                    Console.WriteLine("player " + i.ToString() + " : " + s);
                }

                // check the pairs
                for (int i = 0; i < 4; ++i)
                {
                    List<int> ints = new List<int>();
                    for (int j = 0; j < 13; ++j)
                    {
                        ints.Add(players[i, j].Num);
                    }

                    ints.Sort();
                    int count = 0, memo = 0;
                    bool is_pair = false;

                    for (int j = 0; j < 13; ++j)
                    {
                        if (memo != ints[j])
                        {
                            memo = ints[j];
                            is_pair = false;
                            continue;
                        }

                        if (!is_pair)
                        {
                            is_pair = true;
                            ++count;
                        }
                    }
                    
                    Console.WriteLine("player " + i.ToString() + "有" + count.ToString() + "組對子");
                }
            }
        }

        static char[] suit_names = new char[4] { 'A', 'B', 'C', 'D' };
    }
}
