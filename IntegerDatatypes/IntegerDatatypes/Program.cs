using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegerDatatypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare integer variable and constant
            int totalSecondsPlayed = 100;
            const int SECONDS_PER_MINUTE = 60;

            //calculate minutes and seconds
            int minutes = totalSecondsPlayed / SECONDS_PER_MINUTE;
            int seconds = totalSecondsPlayed % SECONDS_PER_MINUTE;

            //print output
            Console.WriteLine("Minutes: " + minutes);
            Console.WriteLine("Seconds: " + seconds);

            Console.WriteLine();
        }
    }
}
