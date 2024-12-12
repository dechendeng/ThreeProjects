/*
 * Programmer: Dechen Deng
 * Date: 12/11/2024
 * Revision History: Final
 * Platform: Windows11 Rider
 */

using System;

namespace OrderClassLibrary
{
    /// <summary>
    /// A factory class to create different output handlers.
    /// This factory supports creating MYSQL and JSON output handlers.
    /// </summary>
    public class OutputDataFactory
    {
        /// <summary>
        /// Creates an instance of the desired output handler based on the input type.
        /// </summary>
        /// <param name="type">The output type: 1 for MYSQL, 2 for JSON.</param>
        /// <returns>An instance of IOutputData for the specified output type.</returns>
        /// <exception cref="ArgumentException">Thrown when the type is invalid.</exception>
        public IOutputData CreateOutputData(int type)
        {
            // Use a switch expression to decide which output handler to create
            return type switch
            {
                1 => new MYSQL(), // Creates a MYSQL output handler
                2 => new JSON(),  // Creates a JSON output handler
                _ => throw new ArgumentException("Invalid output type") // Handles unsupported types
            };
        }
    }
}