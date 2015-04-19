using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieExample
{   
    /// <summary>
    /// Demonstrates implementation of Die class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Test the Die class
        /// </summary>
        static void Main(string[] args)
        {
            // test standard die
            Die standardDie = new Die();
            Console.WriteLine("STANDARD DIE");
            Console.WriteLine("Number of sides: " + standardDie.NumSides);
            Console.WriteLine("Side on top: " + standardDie.TopSide);
            Console.WriteLine();

            // roll and print the results
            Console.WriteLine("Rolling...");
            standardDie.Roll();
            Console.WriteLine("Side on top: " + standardDie.TopSide);
            Console.WriteLine();


            // test D20 die
            Die d20Die = new Die(20);
            Console.WriteLine("D20 DIE");
            Console.WriteLine("Number of sides: " + d20Die.NumSides);
            Console.WriteLine("Side on top: " + d20Die.TopSide);
            Console.WriteLine();

            // roll and print the results
            Console.WriteLine("Rolling...");
            d20Die.Roll();
            Console.WriteLine("Side on top: " + d20Die.TopSide);
            Console.WriteLine();

        }
    }
}
