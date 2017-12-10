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
        public void GetCard_When_GetCard_Should_Return24Numbers()
        {
            Assert.AreEqual(24, BingoCard.GetCard().Length);
        }
    }
}