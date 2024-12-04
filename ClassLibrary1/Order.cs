/*
 * Programmer: Dechen Deng
 * Date/ 11/25/2024
 * Reversion History: 1.0
 * Plateform: Windows11 Rider
 */
namespace OrderClassLibrary
{
    /// <summary>
    /// Represents a customer order that includes details like customer information, 
    /// purchased items, tax, tariffs, and the total cost of the order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// A unique identifier for the order.
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// The date and time when the order was created.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// The customer's name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// The customer's phone number.
        /// </summary>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// The total tax amount for the order. Calculated as 10% of the order's total item cost.
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// The total tariff amount applied to electronic items in the order.
        /// A 5% tariff is applied to items with Stock_IDs starting with "ELECT".
        /// </summary>
        public decimal TariffAmount { get; set; }

        /// <summary>
        /// The overall total amount for the order, including tax and tariffs.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// A list of all the items purchased in this order.
        /// </summary>
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        /// <summary>
        /// Initializes a new order with basic information like the order number, 
        /// date/time, customer's name, and phone number.
        /// </summary>
        /// <param name="orderNumber">The unique order number.</param>
        /// <param name="dateTime">The date and time of the order.</param>
        /// <param name="customerName">The name of the customer placing the order.</param>
        /// <param name="customerPhone">The phone number of the customer.</param>
        public Order(int orderNumber, DateTime dateTime, string customerName, string customerPhone)
        {
            OrderNumber = orderNumber;
            DateTime = dateTime;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
        }

        /// <summary>
        /// Adds a new detail item to the order, representing a purchased product.
        /// </summary>
        /// <param name="detail">The detail item to add to the order.</param>
        public void AddDetail(OrderDetail detail)
        {
            OrderDetails.Add(detail);
        }

        /// <summary>
        /// Calculates the total cost of the order. 
        /// This includes summing up the cost of all items, adding a 10% tax, 
        /// and applying a 5% tariff to electronic items.
        /// </summary>
        public void CalculateTotal()
        {
            // Sum up the total cost of all the order's items
            decimal totalDetailsAmount = OrderDetails.Sum(detail => detail.CalculateItemTotal());

            // Calculate the tax (10% of the item total)
            TaxAmount = totalDetailsAmount * 0.10m;

            // Calculate the tariff for electronic items (5%)
            TariffAmount = OrderDetails
                .Where(detail => detail.Stock_ID.StartsWith("ELECT"))
                .Sum(detail => detail.CalculateItemTotal() * 0.05m);

            // Update the total amount (items + tax + tariff)
            TotalAmount = totalDetailsAmount + TaxAmount + TariffAmount;
        }
    }
}



