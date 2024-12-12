/*
 * Programmer: Dechen Deng
 * Date: 12/11/2024
 * Revision History: Final
 * Platform: Windows11 Rider
 */

using NUnit.Framework;
using OrderClassLibrary;

namespace UnitTest
{
    /// <summary>
    /// Unit tests for the OrderDetail class.
    /// Tests include item total calculations and constructor validation.
    /// </summary>
    [TestFixture]
    public class OrderDetailTests
    {
        /// <summary>
        /// Tests that the total cost of an item is calculated correctly.
        /// This multiplies the price by the quantity.
        /// </summary>
        [Test]
        public void CalculateItemTotal_ValidPriceAndQuantity_ReturnsCorrectTotal()
        {
            // Arrange: Create an order detail with valid price and quantity
            var detail = new OrderDetail(1000, "ELECT001", "42 Inch TV", 300.00m, 2);

            // Act: Calculate the total cost
            var total = detail.CalculateItemTotal();

            // Assert: Verify the total is correct (300 * 2 = 600)
            Assert.AreEqual(600.00m, total);
        }

        /// <summary>
        /// Tests that the constructor throws an exception when the price is negative.
        /// This ensures validation for invalid input.
        /// </summary>
        [Test]
        public void Constructor_NegativePrice_ThrowsArgumentException()
        {
            // Act & Assert: Verify that a negative price throws an exception
            Assert.Throws<ArgumentException>(() =>
                new OrderDetail(1000, "ELECT001", "42 Inch TV", -300.00m, 1));
        }

        /// <summary>
        /// Tests that the constructor throws an exception when the quantity is negative.
        /// This ensures validation for invalid input.
        /// </summary>
        [Test]
        public void Constructor_NegativeQuantity_ThrowsArgumentException()
        {
            // Act & Assert: Verify that a negative quantity throws an exception
            Assert.Throws<ArgumentException>(() =>
                new OrderDetail(1000, "ELECT001", "42 Inch TV", 300.00m, -1));
        }
    }
}
