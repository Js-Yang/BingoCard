using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        [Test]
        public void When_GetCard_Should_Return_Length_Equal_To_24()
        {
            Assert.AreEqual(24, BingoCard.GetCard().Length);
        }

        [TestCase("B",5,TestName = "B Count Should be 5")]
        [TestCase("I",5,TestName = "I Count Should be 5")]
        [TestCase("N",4,TestName = "N Count Should be 4")]
        [TestCase("G",5,TestName = "G Count Should be 5")]
        [TestCase("O",5,TestName = "O Count Should be 5")]
        public void GetCard_Check_Array_Count(string charactor, int expected)
        {
            Assert.AreEqual(expected, BingoCard.GetCard().Count(x => x.Contains(charactor)));
        }
    }
}