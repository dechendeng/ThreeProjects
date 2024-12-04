/*
 * Programmer: Dechen Deng
 * Date/ 11/25/2024
 * Reversion History: 1.0
 * Plateform: Windows11 Rider
 */
using OrderClassLibrary;
using System;

namespace Driver
{
    /// <summary>
    /// The main program for creating and processing an order.
    /// Demonstrates how to build an order, calculate its total, 
    /// and output the order data using a chosen method (MySQL or JSON).
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point for the program. Creates an order, calculates totals, 
        /// and allows the user to choose how to save the order.
        /// </summary>
        public static void Main()
        {
            // Step 1: Create a new order with basic details
            var order = new Order(1000, new DateTime(2025, 10, 25), "John Jenkins", "253-312-4578");

            // Step 2: Add items to the order
            order.AddDetail(new OrderDetail(1000, "ELECT001", "42 Inch TV", 300.00m, 1));
            order.AddDetail(new OrderDetail(1000, "ELECT044", "Battery", 50.00m, 2));

            // Step 3: Calculate the order totals (items, tax, and tariff)
            order.CalculateTotal();

            // Display the calculated totals
            Console.WriteLine($"Total Amount: {order.TotalAmount}");
            Console.WriteLine($"Tax Amount: {order.TaxAmount}");
            Console.WriteLine($"Tariff Amount: {order.TariffAmount}");

            // Step 4: Ask the user how they want to save the order
            var factory = new OutputDataFactory();
            Console.WriteLine("Choose Output Method: 1 for MYSQL, 2 for JSON");
            
            // Read the user's choice and create the appropriate output handler
            int choice = int.Parse(Console.ReadLine());
            var output = factory.CreateOutputData(choice);

            // Step 5: Save the order using the chosen method
            output.Write(order);
        }
    }
}



