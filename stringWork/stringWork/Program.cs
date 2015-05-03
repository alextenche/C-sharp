using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stringWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter gamer tag: ");
            string gamertag = Console.ReadLine();

            Console.Write("Enter level: ");
            int level = int.Parse(Console.ReadLine());

            char firstGamertagCharacter = gamertag[0];

            Console.WriteLine("Gamertag: " + gamertag);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("First Gamertag character " + firstGamertagCharacter);
            Console.WriteLine();
        }
    }
}
