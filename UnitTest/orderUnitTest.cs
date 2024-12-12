/*
 * Programmer: Dechen Deng
 * Date: 12/11/2024
 * Revision History: Final
 * Platform: Windows11 Rider
 */

using NUnit.Framework;
using OrderClassLibrary;
using System;

namespace UnitTest
{
    /// <summary>
    /// Unit tests for the Order class.
    /// Tests include calculations, adding details, and edge cases.
    /// </summary>
    [TestFixture]
    public class OrderTests
    {
        /// <summary>
        /// Tests that the total amount, tax, and tariff are calculated correctly for valid order details.
        /// </summary>
        [Test]
        public void CalculateTotal_ValidDetails_CalculatesCorrectly()
        {
            // Arrange: Create an order and add valid details
            var order = new Order(1000, DateTime.Now, "Nick Deng", "123-456-7890");
            order.AddDetail(new OrderDetail(1000, "ELECT001", "42 Inch TV", 300.00m, 1)); // Tariff: 15.00
            order.AddDetail(new OrderDetail(1000, "BATTERY001", "Battery", 50.00m, 2));   // No tariff

            // Act: Calculate totals (tax, tariff, and total amount)
            order.CalculateTotal();

            // Assert: Verify that totals are correct
            Assert.AreEqual(455.00m, order.TotalAmount); // 300 + 100 + 40 (tax) + 15 (tariff)
            Assert.AreEqual(40.00m, order.TaxAmount);    // (300 + 100) * 10%
            Assert.AreEqual(15.00m, order.TariffAmount); // 300 * 5%
        }

        /// <summary>
        /// Tests that adding a null detail throws an ArgumentNullException.
        /// This ensures the AddDetail method validates its input properly.
        /// </summary>
        [Test]
        public void AddDetail_NullDetail_ThrowsArgumentNullException()
        {
            // Arrange: Create an order without details
            var order = new Order(1000, DateTime.Now, "Nick Deng", "123-456-7890");

            // Act & Assert: Verify that adding a null detail throws an exception
            Assert.Throws<ArgumentNullException>(() => order.AddDetail(null));
        }

        /// <summary>
        /// Tests that an order with no details calculates to zero amounts.
        /// This checks the edge case where an order is empty.
        /// </summary>
        [Test]
        public void CalculateTotal_WithNoDetails_TotalAmountIsZero()
        {
            // Arrange: Create an order without any details
            var order = new Order(1000, DateTime.Now, "Nick Deng", "123-456-7890");

            // Act: Calculate totals for the empty order
            order.CalculateTotal();

            // Assert: Verify that all calculated amounts are zero
            Assert.AreEqual(0.00m, order.TotalAmount); // No items, so total is zero
            Assert.AreEqual(0.00m, order.TaxAmount);   // No base amount, so tax is zero
            Assert.AreEqual(0.00m, order.TariffAmount);// No electronic items, so tariff is zero
        }
    }
}
