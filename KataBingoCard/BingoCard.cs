﻿using System;
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
                "B",
                "I",
                "N",
                "G",
                "O"
            };
            return bingoCard.ToArray();
        }
    }
}
