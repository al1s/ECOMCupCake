using ECOMCupCake.Models;
using Xunit;

namespace ECOMCupCakeTests
{
    public class ProductTests
    {
        /// <summary>
        /// Can set property to an object
        /// </summary>
        [Fact]
        public void Model_OnSetProperty_PropertyIsAssigned()
        {
            // arrange
            Product product = new Product();
            // act
            string expectedName = "MyProductName";
            string expectedDescription = "MyInventoryDescription";
            product.Name = expectedName;
            product.Description = expectedDescription;
            // assert
            Assert.Equal(expectedName, product.Name);
            Assert.Equal(expectedDescription, product.Description);
        }

        /// <summary>
        /// Can get property to an object
        /// </summary>
        [Fact]
        public void Model_OnGetProperty_PropertyIsEqualToPreviouslySetted()
        {
            // arrange
            Product product = new Product();
            string expectedName = "MyProductName";
            product.Name = expectedName;
            // act
            // assert
            Assert.Equal(expectedName, product.Name);
        }
    }
}
