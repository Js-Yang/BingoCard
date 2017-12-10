using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ExpectedObjects;
using NUnit.Framework;

namespace KataBingoCard.Tests
{
    public class BingoCardTest
    {
        [Test]
        public void When_GetCard_Should_contain_Char_Below_B_I_N_G_O()
        {
            var expecteds = new List<string>() { "B", "I", "N", "G", "O" };
            var bingoCard = BingoCard.GetCard();
            foreach (var expected in expecteds)
            {
                Assert.IsTrue(new List<string>(bingoCard).Any(x => x.Contains(expected)));
            }
        }

        [Test]
        public void When_GetCard_Should_Return_Start_With_BINGO_And_Number()
        {
            var bingoCard = BingoCard.GetCard();
            foreach (var number in bingoCard.ToList())
            {
                Assert.IsTrue(Regex.IsMatch(number, "^[BINGO][0-9]*$"));
            }
        }
        
        [TestCase("B", 5, TestName = "B Count Should be 5")]
        [TestCase("I", 5, TestName = "I Count Should be 5")]
        [TestCase("N", 4, TestName = "N Count Should be 4")]
        [TestCase("G", 5, TestName = "G Count Should be 5")]
        [TestCase("O", 5, TestName = "O Count Should be 5")]
        public void GetCard_Check_Array_Count(string column, int expected)
        {
            Assert.AreEqual(expected, BingoCard.GetCard().Count(x => x.Contains(column)));
        }

        [Test]
        public void NumbersAreOrderedByColumn()
        {
            var columns = string.Join("", BingoCard.GetCard().ToList()
                .Select(x => x.Substring(0, 1)).ToArray());

            Assert.IsTrue(Regex.IsMatch(columns, "^[B]*[I]*[N]*[G]*[O]*$"));
        }
        
        [TestCase("B", 1, 15)]
        [TestCase("I", 16, 30)]
        [TestCase("N", 31, 45)]
        [TestCase("G", 46, 60)]
        [TestCase("O", 61, 75)]
        public void NumbersWithinColumnAreAllInTheCorrectRange(string column, int start, int end)
        {
            var numbers = BingoCard.GetCard().Where(x => x.StartsWith(column)).ToList();

            foreach (var number in numbers)
            {
                var n = Convert.ToInt32(number.Substring(1));
                Assert.GreaterOrEqual(n, start, "Column {0} should be in the range between {1} and {2}, found: {3}", column, start, end, number);
                Assert.LessOrEqual(n, end, "Column {0} should be in the range between {1} and {2}, found: {3}", column, start, end, number);
            }
        }
        
        [Test]
        public void NumbersWithinColumnAreInRandomOrder()
        {
            var card = BingoCard.GetCard().Select(x => Convert.ToInt32(x.Substring(1))).ToArray();

            var isRandom = false;
            for (var i = 1; i < card.Length; i++)
            {
                if (card[i - 1] > card[i])
                {
                    isRandom = true;
                    break;
                }
            }

            Assert.IsTrue(isRandom, "Unlikely result, is the list ordered?");
        }

        [Test]
        public void EachNumberOnCardIsUnique()
        {
            var card = BingoCard.GetCard();
            Assert.AreEqual(card.Length, card.ToList().Distinct().Count());
        }

        [Test]
        public void GetCard_Twice_Should_Be_Different_Set()
        {
            var card1 = BingoCard.GetCard().ToExpectedObject();
            var card2 = BingoCard.GetCard();

            card1.ShouldNotEqual(card2);
        }
    }
}