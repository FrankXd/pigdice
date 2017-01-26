using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDice
{
    class PlayNum
    {
        public static int PNMethod()
        {
            Console.WriteLine("");
            Console.WriteLine("How many players will be playing this game?");
            string line = Console.ReadLine();
            if (int.TryParse(line, out MainClass.playerNumber))
            {
                // this is an int
                MainClass.playerNumber = Int32.Parse(line);
                // do you minimum number check here
            }
            else
            {
                // this is not an int
                Console.WriteLine("Please enter a number amount of players");
                PNMethod();

            }
            return MainClass.playerNumber;
        }
    }
}
