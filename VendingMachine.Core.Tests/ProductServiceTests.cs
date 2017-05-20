using FakeItEasy;
using NUnit.Framework;
using System;
using System.Linq;
using VendingMachine.Core.Products;

namespace VendingMachine.Core.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private ProductService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = A.Fake<ProductService>();
        }

        [Test]
        public void ProductService_Exists()
        {
            Assert.That(_sut != null);
        }

        [Test]
        public void ProductService_GetAll_ReturnsProducts()
        {
            var products = _sut.GetAll();

            Assert.That(products != null);
            Assert.That(products.Any());
        }

        [Test]
        [TestCase(-100)]
        [TestCase(0)]
        [TestCase(-1)]
        public void ProductService_Get_InvalidArgument_ThrowsException(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Get(id));
        }

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(6634)]
        public void ProductService_Get_ValidArgument_DoesNotThrowException(int id)
        {
            Assert.DoesNotThrow(() => _sut.Get(id));
        }

        [Test]
        [TestCase(1)]
        public void ProductService_Get_ValidArgument_ReturnsProduct(int id)
        {
            var product = _sut.Get(id);

            Assert.That(product != null);
        }
    }
}
