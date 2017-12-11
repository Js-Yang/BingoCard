using System;
using System.Collections.Generic;

public class BingoCard
{
    private static readonly List<string> Letters = new List<string> { "B", "I", "N", "G", "O" };
    private static int BaseRange = 15;

    public static string[] GetCard()
    {
        var bingoCard = new List<string>();
        foreach (var letter in Letters)
        {
            bingoCard.AddRange(GetRndNumbersBy(letter));
        }

        return bingoCard.ToArray();
    }

    private static List<string> GetRndNumbersBy(string letter)
    {
        var numbersOfLetter = new List<string>();
        var index = Letters.IndexOf(letter);
        var numbers = GetNumbersBetween(index * BaseRange, (index + 1) * BaseRange);
        for (var i = 0; i < GetLevel(letter); i++)
        {
            numbersOfLetter.Add(letter + RandomTakeFrom(numbers));
        }

        return numbersOfLetter;
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
