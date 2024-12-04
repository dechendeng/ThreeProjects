/*
 * Programmer: Dechen Deng
 * Date/ 11/25/2024
 * Reversion History: 1.0
 * Plateform: Windows11 Rider
 */
namespace OrderClassLibrary
{
    /// <summary>
    /// Represents a single item in an order, including product details and the quantity purchased.
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// The order number this item belongs to.
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// A unique number identifying this specific item within the order.
        /// This number starts at 1 and increments automatically for each new item.
        /// </summary>
        public int DetailNumber { get; set; }

        /// <summary>
        /// The stock ID of the product being purchased, such as a product code or SKU.
        /// </summary>
        public string Stock_ID { get; set; }

        /// <summary>
        /// The name of the product being purchased.
        /// </summary>
        public string StockName { get; set; }

        /// <summary>
        /// The price of a single unit of the product.
        /// </summary>
        public decimal StockPrice { get; set; }

        /// <summary>
        /// The quantity of this product that was purchased.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Keeps track of the detail number for each new item, ensuring it increments automatically.
        /// </summary>
        private static int _detailCounter = 1;

        /// <summary>
        /// Creates a new order detail, specifying the product and its details.
        /// Automatically assigns a unique detail number to this item.
        /// </summary>
        /// <param name="orderNumber">The order number this item belongs to.</param>
        /// <param name="stockID">The stock ID of the product.</param>
        /// <param name="stockName">The name of the product.</param>
        /// <param name="stockPrice">The price of a single unit of the product.</param>
        /// <param name="quantity">The quantity of the product purchased.</param>
        public OrderDetail(int orderNumber, string stockID, string stockName, decimal stockPrice, int quantity)
        {
            OrderNumber = orderNumber;
            DetailNumber = _detailCounter++;
            Stock_ID = stockID;
            StockName = stockName;
            StockPrice = stockPrice;
            Quantity = quantity;
        }

        /// <summary>
        /// Calculates the total cost for this item by multiplying the unit price by the quantity.
        /// </summary>
        /// <returns>The total cost of this item in the order.</returns>
        public decimal CalculateItemTotal()
        {
            return StockPrice * Quantity;
        }
    }
}


