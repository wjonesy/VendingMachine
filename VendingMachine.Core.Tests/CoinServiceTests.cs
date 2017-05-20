using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Core.Coins;
using VendingMachine.Core.InsertedCoins;

namespace VendingMachine.Core.Tests
{
    [TestFixture]
    public class CoinServiceTests
    {
        private CoinService _sut;
        private InsertedCoin _coin_valid = InsertedCoinsConstants.Penny;
        private InsertedCoin _coin_invalid = new InsertedCoin(1, 2, 3);
        private double _pennyValue = CoinConstants.Penny.Value;

        [SetUp]
        public void Setup()
        {
            _sut = A.Fake<CoinService>();
        }

        [Test]
        public void CoinService_Exists()
        {
            Assert.That(_sut != null);
        }

        [Test]
        public void CoinService_GetCoinValue_ValidCoin_ReturnsValue()
        {

            var value = _sut.GetCoinValue(_coin_valid);

            Assert.AreEqual(CoinConstants.Penny.Value, value);
        }

        [Test]
        public void CoinService_GetCoinValue_InvalidCoin_ReturnsNull()
        {
            var value = _sut.GetCoinValue(_coin_invalid);

            Assert.AreEqual(null, value);
        }

        [Test]
        public void CoinService_GetCoinsTotalValue_NoCoinsInserted_ReturnsZero()
        {
            var total = _sut.GetCoinsTotalValue(new List<InsertedCoin>());
            Assert.That(total == 0);
        }

        [Test]
        public void CoinService_GetCoinsTotalValue_ValidCoinsInserted_ReturnsValue()
        {
            var insertedCoins = new List<InsertedCoin>() {
                InsertedCoinsConstants.Penny,
                InsertedCoinsConstants.Dime
            };
            var total = _sut.GetCoinsTotalValue(insertedCoins);
            Assert.That(total == 11);
        }


        [Test]
        public void CoinService_GetCoinsTotalValue_InValidCoinsInserted_ReturnsValue()
        {
            var insertedCoins = new List<InsertedCoin>() {
                InsertedCoinsConstants.Penny,
                new InsertedCoin(1,2,3)
            };

            Assert.Throws<Exception>(() => _sut.GetCoinsTotalValue(insertedCoins));
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(6, 2)]
        [TestCase(16, 3)]
        [TestCase(27, 3)]
        [TestCase(33, 5)]
        [TestCase(125, 5)]
        [TestCase(126, 6)]
        public void CoinService_GetCoinsForAmount_NumberOfCoinsIsCorrect(int amount, int numberOfCoins)
        {
            var coins = _sut.GetCoinsForAmount(amount);

            Assert.That(coins.Count == numberOfCoins);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(6)]
        [TestCase(16)]
        [TestCase(27)]
        [TestCase(33)]
        [TestCase(125)]
        [TestCase(126)]
        public void CoinService_GetCoinsForAmount_ValueOfCoinsIsCorrect(int amount)
        {
            var coins = _sut.GetCoinsForAmount(amount);
            var value = 0;
            foreach (var coin in coins)
            {

                value += coin.Value;
            }
            Assert.That(amount == value);
        }
    }
}
