using FakeItEasy;
using NUnit.Framework;
using VendingMachine.Core.Coins;
using VendingMachine.Core.InsertedCoins;

namespace VendingMachine.Core.Tests
{
    [TestFixture]
    public class CoinServiceTests
    {
        private ICoinService _sut;
        private InsertedCoin _coin_valid = InsertedCoinsConstants.Penny;
        private InsertedCoin _coin_invalid = new InsertedCoin(1, 2, 3);
        private double _pennyValue = CoinConstants.Penny.Value;

        [SetUp]
        public void Setup()
        {
            _sut = A.Fake<ICoinService>();
        }

        [Test]
        public void ICoinService_Exists()
        {
            Assert.That(_sut != null);
        }

        [Test]
        public void ICoinService_GetCoinValue_ValidCoin_ReturnsValue()
        {

            A.CallTo(() => _sut.GetCoinValue(_coin_valid)).Returns(_pennyValue);

            var value = _sut.GetCoinValue(_coin_valid);

            Assert.AreEqual(CoinConstants.Penny.Value, value);
        }

        [Test]
        public void ICoinService_GetCoinValue_InvalidCoin_ReturnsNull()
        {

            A.CallTo(() => _sut.GetCoinValue(_coin_invalid)).Returns(null);
            var value = _sut.GetCoinValue(_coin_invalid);

            Assert.AreEqual(null, value);
        }
    }
}
