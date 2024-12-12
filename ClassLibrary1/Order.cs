/*
 * Programmer: Dechen Deng
 * Date: 12/11/2024
 * Revision History: Final
 * Platform: Windows11 Rider
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderClassLibrary
{
    public class Order
    {
        // Order properties to store basic information
        public int OrderNumber { get; }  // Unique identifier for the order
        public DateTime DateTime { get; }  // When the order was placed
        public string CustomerName { get; }  // Customer's full name
        public string CustomerPhone { get; }  // Customer's contact number

        // Computed amounts for the order
        public decimal TaxAmount { get; private set; }  // 10% tax on total
        public decimal TariffAmount { get; private set; }  // Additional 5% for electronics
        public decimal TotalAmount { get; private set; }  // Final total amount

        // Stores all the items in the order
        public List<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

        private int _nextDetailNumber = 1;  // Keeps track of detail numbers (increments automatically)

        /// <summary>
        /// Initializes a new order with basic information.
        /// Ensures that customer name and phone number are not empty.
        /// </summary>
        public Order(int orderNumber, DateTime dateTime, string customerName, string customerPhone)
        {
            // Validate customer name and phone - avoid empty or null values
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be empty.", nameof(customerName));

            if (string.IsNullOrWhiteSpace(customerPhone))
                throw new ArgumentException("Customer phone cannot be empty.", nameof(customerPhone));

            OrderNumber = orderNumber;
            DateTime = dateTime;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
        }

        /// <summary>
        /// Adds an item (OrderDetail) to the order.
        /// Automatically assigns a detail number to the new item.
        /// </summary>
        public void AddDetail(OrderDetail detail)
        {
            // If the detail is null, throw an error (we can't process a null item)
            if (detail == null)
                throw new ArgumentNullException(nameof(detail), "Order detail cannot be null.");

            // Automatically assign the next available detail number
            detail.SetDetailNumber(_nextDetailNumber++);
            OrderDetails.Add(detail);
        }

        /// <summary>
        /// Calculates the total cost, tax, and tariffs for the order.
        /// This includes a 10% tax on the total amount and a 5% tariff on electronics.
        /// </summary>
        public void CalculateTotal()
        {
            // Sum up the total cost of all the order details (without tax or tariffs)
            decimal totalDetailsAmount = OrderDetails.Sum(detail => detail.CalculateItemTotal());

            // Calculate 10% tax on the total amount
            TaxAmount = Math.Round(totalDetailsAmount * 0.10m, 2);

            // Add 5% tariff for items starting with "ELECT" (electronics)
            TariffAmount = Math.Round(OrderDetails
                .Where(detail => detail.Stock_ID.StartsWith("ELECT", StringComparison.OrdinalIgnoreCase))
                .Sum(detail => detail.CalculateItemTotal() * 0.05m), 2);

            // Calculate the final total (sum of base amount, tax, and tariffs)
            TotalAmount = Math.Round(totalDetailsAmount + TaxAmount + TariffAmount, 2);
        }
    }
}








