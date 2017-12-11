using System;
using System.Collections.Generic;

public class BingoCard
{
    private static readonly List<string> Letters = new List<string> { "B", "I", "N", "G", "O" };

    public static string[] GetCard()
    {
        var bingoCard = new List<string>();
        foreach (var letter in Letters)
        {
            AddRndNumbersBy(letter, bingoCard);
        }

        return bingoCard.ToArray();
    }

    private static void AddRndNumbersBy(string letter, List<string> bingoCard)
    {
        var BaseRange = 15;
        var index = Letters.IndexOf(letter);
        var numbers = GetNumbersBetween(index * BaseRange, (index + 1) * BaseRange);
        for (var i = 0; i < GetLevel(letter); i++)
        {
            bingoCard.Add(letter + RandomTakeFrom(numbers));
        }
    }

    private static int GetLevel(string letter)
    {
        return letter == "N" ? 4 : 5;
    }

    private static List<int?> GetNumbersBetween(int start, int end)
    {
        var numbers = new List<int?>();
        for (var i = start; i < end; i++)
        {
            numbers.Add(i);
        }
        return numbers;
    }

    private static int? RandomTakeFrom(List<int?> numbers)
    {
        while (true)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var randPosition = rnd.Next(1, 15);
            if (numbers[randPosition] != null)
            {
                var rndNumber = numbers[randPosition];
                numbers[randPosition] = null;
                return rndNumber;
            }
        }
    }
}
