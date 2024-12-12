/*
 * Programmer: Dechen Deng
 * Date: 12/11/2024
 * Revision History: Final
 * Platform: Windows11 Rider
 */
using System;
using System.Text.Json;
using System.IO;

namespace OrderClassLibrary
{
    /// <summary>
    /// Interface for saving order data to different output formats.
    /// Helps in writing order details to a database or a file.
    /// </summary>
    public interface IOutputData
    {
        /// <summary>
        /// Writes the order details to the chosen output format.
        /// </summary>
        void Write(Order order);
    }

    /// <summary>
    /// Implementation for saving order data to a simulated MySQL database.
    /// </summary>
    public class MYSQL : IOutputData
    {
        /// <summary>
        /// Simulates writing the order to a MySQL database.
        /// This implementation simply prints the order details to the console.
        /// </summary>
        /// <param name="order">The order to be saved.</param>
        public void Write(Order order)
        {
            // In a real implementation, this would connect to a MySQL database.
            Console.WriteLine($"[MYSQL] Writing order {order.OrderNumber} to database...");
            Console.WriteLine($"Order Data: {order.OrderNumber}, {order.DateTime}, {order.CustomerName}, {order.CustomerPhone}, Tax: {order.TaxAmount}, Tariff: {order.TariffAmount}, Total: {order.TotalAmount}");
        }
    }

    /// <summary>
    /// Implementation for saving order data to a JSON file.
    /// </summary>
    public class JSON : IOutputData
    {
        /// <summary>
        /// Saves the order details to a JSON file.
        /// This file is created in the current directory with the order number in the file name.
        /// </summary>
        /// <param name="order">The order to be saved.</param>
        public void Write(Order order)
        {
            // Create a JSON file named after the order number
            string filePath = $"Order_{order.OrderNumber}.json";

            // Configure JSON options for readable formatting
            var options = new JsonSerializerOptions { WriteIndented = true };

            // Serialize the order object into a JSON string
            string jsonString = JsonSerializer.Serialize(order, options);

            // Write the JSON string to the file
            File.WriteAllText(filePath, jsonString);

            // Notify the user that the file has been created
            Console.WriteLine($"Order {order.OrderNumber} written to {filePath}");
        }
    }
}


