/*
 * Programmer: Dechen Deng
 * Date/ 11/25/2024
 * Reversion History: 1.0
 * Plateform: Windows11 Rider
 */

namespace OrderClassLibrary
{
    /// <summary>
    /// Represents a general output mechanism for orders. Classes that implement this interface
    /// need to define how an order is written to a specific storage medium, such as a database or file.
    /// </summary>
    public interface OutputData
    {
        /// <summary>
        /// Writes the provided order to a specific output destination.
        /// </summary>
        /// <param name="order">The order to be written.</param>
        void Write(Order order);
    }

    /// <summary>
    /// Handles writing orders to a MySQL database.
    /// </summary>
    public class MYSQL : OutputData
    {
        /// <summary>
        /// Simulates writing the order and its details to a MySQL database.
        /// Outputs all the order and order detail information to the console as a placeholder.
        /// </summary>
        /// <param name="order">The order to be written to the database.</param>
        public void Write(Order order)
        {
            Console.WriteLine($"[MYSQL] Writing order {order.OrderNumber} to database...");
            Console.WriteLine($"[MYSQL] Order Data: {order.OrderNumber}, {order.DateTime}, {order.CustomerName}, {order.CustomerPhone}, Tax: {order.TaxAmount}, Tariff: {order.TariffAmount}, Total: {order.TotalAmount}");
            
            foreach (var detail in order.OrderDetails)
            {
                Console.WriteLine($"[MYSQL] Detail Data: {detail.OrderNumber}, {detail.DetailNumber}, {detail.Stock_ID}, {detail.StockName}, {detail.StockPrice}, {detail.Quantity}, Total: {detail.CalculateItemTotal()}");
            }
        }
    }

    /// <summary>
    /// Handles writing orders to a JSON file.
    /// </summary>
    public class JSON : OutputData
    {
        /// <summary>
        /// Writes the order and its details to a JSON file. The file is saved locally 
        /// with the name "Order_{OrderNumber}.json".
        /// </summary>
        /// <param name="order">The order to be written to a JSON file.</param>
        public void Write(Order order)
        {
            Console.WriteLine($"[JSON] Writing order {order.OrderNumber} to JSON file...");

            // Generate file path
            string filePath = $"Order_{order.OrderNumber}.json";

            // Serialize the order to a JSON string with indentation for readability
            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(order, options);

            // Write the JSON string to the file
            System.IO.File.WriteAllText(filePath, jsonString);

            Console.WriteLine($"[JSON] Order {order.OrderNumber} successfully written to file: {filePath}");
        }
    }
}
