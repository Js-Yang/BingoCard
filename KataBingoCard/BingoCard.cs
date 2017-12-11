using System;
using System.Collections.Generic;

public class BingoCard
{
    public static string[] GetCard()
    {
        var bingoCard = new List<string>();
        bingoCard.AddRange(RndNumbers.Generate("B", 1, 15, 5));
        bingoCard.AddRange(RndNumbers.Generate("I", 16, 30, 5));
        bingoCard.AddRange(RndNumbers.Generate("N", 31, 45, 4));
        bingoCard.AddRange(RndNumbers.Generate("G", 46, 60, 5));
        bingoCard.AddRange(RndNumbers.Generate("O", 61, 75, 5));
        return bingoCard.ToArray();
    }
}

public class RndNumbers
{
    public static IEnumerable<string> Generate(string label, int start, int end, int count)
    {
        var rndNumbers = new List<string>();
        var rnd = new Random(Guid.NewGuid().GetHashCode());
        while (rndNumbers.Count < count)
        {
            var rndNumber = label + rnd.Next(start, end);
            if (!rndNumbers.Contains(rndNumber))
            {
                rndNumbers.Add(rndNumber);
            }
        }

        return rndNumbers;
    }
}