using ECOMCupCake.Models;
using Xunit;

namespace ECOMCupCakeTests
{
    public class BasketTests
    {
        /// <summary>
        /// Can set property to an object
        /// </summary>
        [Fact]
        public void Model_OnSetProperty_PropertyIsAssigned()
        {
            // arrange
            Basket basket = new Basket();
            // act
            int expectedProductId = 1;
            int expectedQuantity = 1;
            basket.ProductID = expectedProductId;
            basket.Quantity = expectedQuantity;
            // assert
            Assert.Equal(expectedProductId, basket.ProductID);
            Assert.Equal(expectedQuantity, basket.Quantity);
        }

        /// <summary>
        /// Can get property to an object
        /// </summary>
        [Fact]
        public void Model_OnGetProperty_PropertyIsEqualToPreviouslySetted()
        {
            // arrange
            Basket basket = new Basket();
            // act
            int expectedProductId = 1;
            basket.ProductID = expectedProductId;
            // assert
            Assert.Equal(expectedProductId, basket.ProductID);
        }
    }
}
