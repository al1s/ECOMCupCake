using ECOMCupCake.Models;
using Xunit;

namespace ECOMCupCakeTests
{
    public class OrderTests
    {
        /// <summary>
        /// Can set property to an object
        /// </summary>
        [Fact]
        public void Model_OnSetProperty_PropertyIsAssigned()
        {
            // arrange
            Order order = new Order();
            // act
            string expectedUserId = "MyUserId";
            order.UserID = expectedUserId;
            // assert
            Assert.Equal(expectedUserId, order.UserID);
        }

        /// <summary>
        /// Can get property to an object
        /// </summary>
        [Fact]
        public void Model_OnGetProperty_PropertyIsEqualToPreviouslySetted()
        {
            // arrange
            Order order = new Order();
            // act
            string expectedUserId = "MyUserId";
            order.UserID = expectedUserId;
            // assert
            Assert.Equal(expectedUserId, order.UserID);
        }
    }
}
