using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alojzy.Modules
{
    internal class Commands
    {

        public static string Roll(string cmd)
        {
            string text = "(**";
            var Random = new Random();
            List<int> Numery = new List<int>();
            int diceNumber = int.Parse(cmd[5..cmd.IndexOf('d')].ToString()), 
                diceSize = int.Parse(cmd[(cmd.IndexOf('d') + 1)..^0].ToString()), 
                total = 0;

            //
            for (int i = 1; i <= diceNumber; i++)
            {
                var numer = Random.Next(1, diceSize + 1);
                Numery.Add(numer);
                if (i != diceNumber)
                    text += numer.ToString() + ", ";
                else
                    text += numer.ToString() + "**)";
                total += numer;
            }
            text += $"\n**Total: ** {total}";

            return text;
        }
        public static string BNB()
        {
            var Random = new Random();
            if (Random.Next(1, 3) == 1) return "Balls <:EZ:804082660267655188> <:pepelaugh:940224754302980189>";
            else return "No balls <:pepelaugh:940224754302980189>";
        }

    }
}
