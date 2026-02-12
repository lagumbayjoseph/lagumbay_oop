using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagumbay_Act8
{
    internal class UserInput
    {
        public static string ReadNonEmpty(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Input cannot be empty.");
            }
            while (string.IsNullOrWhiteSpace(input));

            return input.Trim();
        }

        // Read integer with range validation
        public static int ReadIntInRange(string prompt, int min, int max)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) &&
                    value >= min && value <= max)
                    return value;

                Console.WriteLine($"Invalid input. Enter a number between {min} and {max}.");
            }
        }
    }
}