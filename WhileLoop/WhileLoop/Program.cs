using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("J - Jump");
            Console.WriteLine("C - Crouch");
            Console.WriteLine("Q - Quit");
            Console.WriteLine();

            Console.Write("Enter choice: ");
            char choice = char.Parse(Console.ReadLine().ToUpper());

            // validate input
            while(choice != 'J' && choice != 'C' && choice != 'Q')
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input");

                Console.WriteLine("J - Jump");
                Console.WriteLine("C - Crouch");
                Console.WriteLine("Q - Quit");
                Console.WriteLine();

                Console.Write("Enter choice: ");
                choice = char.Parse(Console.ReadLine().ToUpper());
            }
            Console.WriteLine();
        }
    }
}
