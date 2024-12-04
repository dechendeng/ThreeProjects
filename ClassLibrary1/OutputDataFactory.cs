/*
 * Programmer: Dechen Deng
 * Date/ 11/25/2024
 * Reversion History: 1.0
 * Plateform: Windows11 Rider
 */

namespace OrderClassLibrary
{
    /// <summary>
    /// A factory class responsible for creating instances of different output types.
    /// This allows dynamic selection of how orders are saved, such as to a database or a JSON file.
    /// </summary>
    public class OutputDataFactory
    {
        /// <summary>
        /// Creates and returns an instance of an output type based on the input value.
        /// Currently supports two types:
        /// - 1: MYSQL (for saving orders to a database)
        /// - 2: JSON (for saving orders to a JSON file)
        /// </summary>
        /// <param name="type">The type of output (1 for MYSQL, 2 for JSON).</param>
        /// <returns>An instance of the corresponding OutputData implementation.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid type is provided.</exception>
        public OutputData CreateOutputData(int type)
        {
            return type switch
            {
                1 => new MYSQL(), // Returns a MYSQL instance for database output
                2 => new JSON(),  // Returns a JSON instance for file output
                _ => throw new ArgumentException("Invalid output type") // Handles unsupported types
            };
        }
    }
}