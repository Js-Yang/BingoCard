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
            var level = 5;
            if (letter == "N")
            {
                level--;
            }

            AddNumbersWith(level, bingoCard, letter, start, end);
            start += BaseRange;
            end += BaseRange;
        }

        return bingoCard.ToArray();
    }

    private static void AddNumbersWith(int level, List<string> bingoCard, string letter, int start, int end)
    {
        var numbers = InitNumbers(start, end);

        var rnd = new Random(Guid.NewGuid().GetHashCode());
        for (var i = 0; i < level; i++)
        {
            int randPosition;
            do
            {
                randPosition = rnd.Next(1, 15);
            } while (numbers[randPosition] == null);

            bingoCard.Add(letter + numbers[randPosition]);
            numbers[randPosition] = null;
        }
    }

    private static List<int?> InitNumbers(int start, int end)
    {
        var numbers = new List<int?>();
        for (var i = start; i < end; i++)
        {
            numbers.Add(i);
        }
        return numbers;
    }
}
