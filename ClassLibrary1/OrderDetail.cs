/*
 * Programmer: Dechen Deng
 * Date: 12/11/2024
 * Revision History: Final
 * Platform: Windows11 Rider
 */
using System;

namespace OrderClassLibrary
{
    public class OrderDetail
    {
        // Order number this detail belongs to
        public int OrderNumber { get; }

        // A unique identifier for this specific detail in the order
        public int DetailNumber { get; private set; }

        // The unique stock identifier (e.g., "ELECT001")
        public string Stock_ID { get; }

        // The name of the stock item (e.g., "42 Inch TV")
        public string StockName { get; }

        // The price of a single unit of this stock item
        public decimal StockPrice { get; }

        // The number of units purchased for this item
        public int Quantity { get; set; }

        /// <summary>
        /// Initializes an OrderDetail object with required information.
        /// Ensures price and quantity are non-negative.
        /// </summary>
        public OrderDetail(int orderNumber, string stockID, string stockName, decimal stockPrice, int quantity)
        {
            // Make sure stock price and quantity aren't negative
            if (stockPrice < 0 || quantity < 0)
                throw new ArgumentException("Stock price and quantity must be non-negative.");

            OrderNumber = orderNumber;
            Stock_ID = stockID;
            StockName = stockName;
            StockPrice = stockPrice;
            Quantity = quantity;
        }

        /// <summary>
        /// Sets the detail number for this item.
        /// This is typically assigned by the Order class when the item is added.
        /// </summary>
        public void SetDetailNumber(int detailNumber)
        {
            DetailNumber = detailNumber;
        }

        /// <summary>
        /// Calculates the total price for this item.
        /// Multiplies the unit price by the quantity purchased.
        /// </summary>
        public decimal CalculateItemTotal()
        {
            return StockPrice * Quantity;
        }
    }
}








