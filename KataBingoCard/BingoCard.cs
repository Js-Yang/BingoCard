using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataBingoCard
{
    public class BingoCard
    {
        public static string[] GetCard()
        {
            var bingoCard = new List<string>
            {
                "B10", "B10", "B10", "B10", "B10",
                "I10", "I10", "I10", "I10", "I10",
                "N10", "N10", "N10", "N10",
                "G10", "G10", "G10", "G10", "G10",
                "O10", "O10", "O10", "O10", "O10",
            };
            return bingoCard.ToArray();
        }
    }
}
