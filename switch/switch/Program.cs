using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @switch
{
    class Program
    {
        static void Main(string[] args)
        {
            // ask for and get user answer
            Console.Write("Pick up the shiny think ? (y/n): ");
            char answer = Console.ReadLine()[0];

            // print appropriate message
            switch (answer)
            {
                case 'y':
                case 'Y':
                    Console.WriteLine("You have the shiny object !");
                    break;
                case 'n':
                case 'N':
                    Console.WriteLine("Nope !");
                    break;
                default:
                    Console.WriteLine("Do not undestand what you want !");
                    break;
            }
            Console.WriteLine();

        }
    }
}
