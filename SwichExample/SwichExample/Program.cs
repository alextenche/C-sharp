using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwichExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Pick up the skiny thing ? (y,n): ");
            char answer = Console.ReadLine()[0];

            //print apropiate message
            switch (answer)
            {
                case 'y':
                case 'Y': 
                    Console.WriteLine("You have the shiny object ");
                    break;
                case 'n':
                case 'N':
                    Console.WriteLine("You don't have the shiny object ");
                    break;
                default:
                    Console.WriteLine("You'r a n00b");
                    break;
            }
        }
    }
}
