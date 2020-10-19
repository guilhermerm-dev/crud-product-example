using crud_product_domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace crud_product_tests.Entities
{
    [TestClass]
    public class ProductTest
    {
        private readonly int _code;

        public readonly string _name;

        public readonly string _description;

        public readonly decimal _price;

        public readonly int _quantity;

        public ProductTest()
        {
            _code = 10;
            _name = "name ";
            _description = "description";
            _price = 10.5M;
            _quantity = 10;
        }
        
        [TestMethod]
        public void ShouldCreateProduct()
        {
            var product = new Product(_code, _name, _description, _price, _quantity);
            Assert.IsNotNull(product);
            Assert.IsInstanceOfType(product, typeof(Product));
        }

        [TestMethod]
        public void ProductShouldBeInvalidWhenNameIsNull()
        {
            var product = new Product(_code, null, _description, _price, _quantity);
            Assert.IsTrue(product.Invalid);
        }

        [TestMethod]
        public void ProductShouldBeInvalidWhenNameIsEmpty()
        {
            var product = new Product(_code, "", _description, _price, _quantity);
            Assert.IsTrue(product.Invalid);
        }

        [TestMethod]
        public void ProductShouldBeInvalidWhenPriceIsEqualTo0()
        {
            var product = new Product(_code, _name, _description, 0.0M, _quantity);
            Assert.IsTrue(product.Invalid);
        }
    }
}
