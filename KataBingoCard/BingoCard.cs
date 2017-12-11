using System;
using System.Collections.Generic;

public class BingoCard
{
    private static readonly List<string> Letters = new List<string> { "B", "I", "N", "G", "O" };

    public static string[] GetCard()
    {
        var bingoCard = new List<string>();
        var BaseRange = 15;
        var start = 0;
        var end = 15;
        foreach (var letter in Letters)
        {
            AddRndNumbersBy(bingoCard, letter, start, end);
            start += BaseRange;
            end += BaseRange;
        }

        return bingoCard.ToArray();
    }

    private static void AddRndNumbersBy(List<string> bingoCard, string letter, int start, int end)
    {
        var numbers = GenerateNumbers(start, end);
        for (var i = 0; i < GetLevel(letter); i++)
        {
            bingoCard.Add(letter + RandomTakeFrom(numbers));
        }
    }

    private static int GetLevel(string letter)
    {
        return letter == "N" ? 4 : 5;
    }

    private static List<int?> GenerateNumbers(int start, int end)
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
        var randPosition = GetRandPosition(numbers);
        var rndNumber = numbers[randPosition];
        numbers[randPosition] = null;
        return rndNumber;
    }

    private static int GetRandPosition(List<int?> numbers)
    {
        while (true)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var randPosition = rnd.Next(1, 15);
            if (numbers[randPosition] != null)
            {
                return randPosition;
            }
        }
    }
}
