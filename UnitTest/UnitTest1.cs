/*
 * Programmer: Dechen Deng
 * Date/ 11/25/2024
 * Reversion History: 1.0
 * Plateform: Windows11 Rider
 */
using OrderClassLibrary;
using NUnit.Framework;

namespace UnitTest
{
    /// <summary>
    /// This is a test class to make sure the Order class works correctly, 
    /// especially when it comes to calculating the total cost of an order.
    /// </summary>
    [TestFixture]
    public class UnitTest1
    {
        /// <summary>
        /// Tests the CalculateTotal method to ensure it properly calculates 
        /// the total cost of an order, including the item prices, tax, and tariffs.
        /// </summary>
        [Test]
        public void Test_CalculateTotal()
        {
            // Arrange: Set up an order with some items
            var order = new Order(1000, DateTime.Now, "John Doe", "123-456-7890");
            order.AddDetail(new OrderDetail(1000, "ELECT001", "42 Inch TV", 300.00m, 1)); // Electronics item
            order.AddDetail(new OrderDetail(1000, "ELECT044", "Battery", 50.00m, 2));     // Another electronics item

            // Act: Calculate the total for this order
            order.CalculateTotal();

            // Expected results
            var expectedItemTotal = 300.00m * 1 + 50.00m * 2;        // Total cost of items: 400.00
            var expectedTax = expectedItemTotal * 0.10m;             // Tax (10% of items): 40.00
            var expectedTariff = 300.00m * 0.05m;                    // Tariff (5% on ELECT001): 15.00
            var expectedTotal = expectedItemTotal + expectedTax + expectedTariff; // Final total: 455.00

            // Assert: Check if the calculated total matches what we expect
            Assert.AreEqual(expectedTotal, order.TotalAmount);
        }
    }
}



