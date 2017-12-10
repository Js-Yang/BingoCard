using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataBingoCard
{
    public class BingoCard
    {
        private static readonly List<string> Letters = new List<string>() {"B", "I", "N", "G", "O"};

        public static string[] GetCard()
        {
            var bingoCard = new List<string>();
            foreach (var letter in Letters)
            {
                var level = 5;
                if (letter == "N")
                {
                    level--;
                }

                AddNumbersWith(level, bingoCard, letter);
            }

            return bingoCard.ToArray();
        }

        private static void AddNumbersWith(int level, List<string> bingoCard, string letter)
        {
            for (var i = 0; i < level; i++)
            {
                bingoCard.Add(letter + "10");
            }
        }
    }
}