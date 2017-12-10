using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace KataBingoCard.Tests
{
    public class BingoCardTest
    {
        [Test]
        public void When_GetCard_Should_contain_BINGO()
        {
            var expecteds = new List<string>() { "B", "I", "N", "G", "O" };
            var bingoCard = BingoCard.GetCard();
            foreach (var expected in expecteds)
            {
                Assert.IsTrue(new List<string>(bingoCard).Contains(expected));
            }
        }
    }
}