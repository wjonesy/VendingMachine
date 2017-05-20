using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
