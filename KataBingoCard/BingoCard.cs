using System.Collections.Generic;

public class BingoCard
{
    private static readonly List<string> Letters = new List<string> { "B", "I", "N", "G", "O" };
    private static int NextRange = 1;

    public static string[] GetCard()
    {
        NextRange = 1;
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
        for (var i = level * 2; i >= 1; i -= 2)
        {
            var number = i + NextRange;
            bingoCard.Add(letter + number);
        }
        NextRange += 15;
    }
}
