using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ifStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            // ask for and get user answer
            Console.Write("Pick up the shiny think ? (y/n): ");
            char answer = Console.ReadLine()[0];

            // print appropriate message
            if (answer == 'y' || answer == 'Y')
            {
                Console.WriteLine("You have the shiny object !");
            } else if(answer == 'n' || answer == 'N'){
                Console.WriteLine("Nope !");
            }
            else
            {
                Console.WriteLine("Do not undestand what you want !");
            }
            Console.WriteLine();


        }
    }
}
