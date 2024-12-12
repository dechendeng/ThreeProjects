/*
 * Programmer: Dechen Deng
 * Date: 12/11/2024
 * Revision History: Final
 * Platform: Windows11 Rider
 */

using System;
using OrderClassLibrary;

namespace Driver
{
    /// <summary>
    /// The main program class to demonstrate the order processing system.
    /// This includes creating an order, calculating totals, and saving the data.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// Demonstrates creating an order, adding details, calculating totals, and saving the data.
        /// </summary>
        public static void Main()
        {
            // Step 1: Create an order with basic details
            var order = new Order(1000, new DateTime(2025, 10, 25), "John Jenkins", "253-312-4578");

            // Step 2: Add order details (items)
            order.AddDetail(new OrderDetail(1000, "ELECT001", "42 Inch TV", 300.00m, 1));
            order.AddDetail(new OrderDetail(1000, "ELECT044", "Battery", 50.00m, 1));

            // Step 3: Calculate totals including tax and tariffs
            order.CalculateTotal();

            // Step 4: Display order summary on the console
            Console.WriteLine($"Total Amount: {order.TotalAmount}");  // Final total including tax and tariffs
            Console.WriteLine($"Tax Amount: {order.TaxAmount}");      // Tax (10% of the total)
            Console.WriteLine($"Tariff Amount: {order.TariffAmount}");// Tariffs (5% on electronics)

            // Step 5: Save the order to the desired output format
            var factory = new OutputDataFactory();  // Factory to create output handlers
            Console.WriteLine("Choose Output Method: 1 for MYSQL, 2 for JSON");
            
            // Parse user input to choose output method
            int choice = int.Parse(Console.ReadLine());

            // Create and use the selected output handler
            var output = factory.CreateOutputData(choice);
            output.Write(order);  // Save the order using the chosen format
        }
    }
}






