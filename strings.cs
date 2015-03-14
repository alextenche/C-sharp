using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strings
{
    class Program
    {
        static void Main(string[] args)
        {
            // prompt for and read in the gamertag
            Console.Write("Enter gamertag: ");
            string gamertag = Console.ReadLine();

            // prompt and read in the level
            Console.Write("Enter level: ");
            int level = int.Parse(Console.ReadLine());

            // extract the first character of gamertag
            char firstGamertagCharacter = gamertag[0];

            // print out values
            Console.WriteLine();
            Console.WriteLine("Gamertag: " + gamertag);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("First gamertag character: " + firstGamertagCharacter);
            Console.WriteLine();
            
        }
    }
}
