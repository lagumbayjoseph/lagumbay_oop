using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagumbay_Inserting_Nodes_with_Exception_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> names = new LinkedList<string>();
            int count = 0;
            bool valid = false;

            // TRI-CATCH EXCEPTION HANDLING
            while (!valid)
            {
                try
                {
                    Console.Write("Enter how many names you want to input: ");
                    count = int.Parse(Console.ReadLine());

                    if (count <= 0)
                        throw new Exception("Number must be greater than zero.");

                    valid = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a NUMBER only.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: Number is too large.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            // USER INPUT FOR LINKED LIST
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter name {i + 1}: ");
                string name = Console.ReadLine();
                names.AddLast(name);
            }

            // DISPLAY ORIGINAL LINKED LIST
            Console.WriteLine("\nOriginal Linked List:");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            // COPY LINKED LIST TO ARRAY
            string[] nameArray = new string[names.Count];
            names.CopyTo(nameArray, 0);

            // SORT ARRAY
            Array.Sort(nameArray);

            // COPY SORTED ARRAY BACK TO LINKED LIST
            names.Clear();
            foreach (string name in nameArray)
            {
                names.AddLast(name);
            }

            // DISPLAY SORTED LINKED LIST
            Console.WriteLine("\nSorted Linked List:");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Console.ReadLine();
        }
    }
}
    
