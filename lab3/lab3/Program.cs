using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace floating_point_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal originalFahrenheit;
            decimal calculatedCelsius;
            decimal calculatedFahrenheit;

            Console.Write("Enter temperature (Fahrenheit): ");
            originalFahrenheit = decimal.Parse(Console.ReadLine());

            calculatedCelsius = ((originalFahrenheit - 32) / 9) * 5;
            Console.WriteLine(originalFahrenheit + " degrees Fahrenheit is " + calculatedCelsius + " degrees Celsius");

            calculatedFahrenheit = ((calculatedCelsius * 9) / 5) + 32;
            Console.WriteLine(calculatedCelsius + " degrees Celsius is " + calculatedFahrenheit + " degrees Fahrenheit");

            Console.WriteLine();
        }
    }
}
