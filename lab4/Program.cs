using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
    /// <summary>
    /// Demonstrate using the Deck class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrate using the Deck class
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            //Problem 1 - Create a deck and print it
            Console.WriteLine(" -- Problem 1 -- ");
            Deck deck = new Deck();
            deck.Print();
            Console.WriteLine();

            //Problem 2 - Shuffle the deck and print it
            Console.WriteLine(" -- Problem 2 -- ");
            deck.Shuffle();
            deck.Print();
            Console.WriteLine();

            //Problem 3 - Take two cards from the deck and print them
            Console.WriteLine(" -- Problem 3 -- ");
            Card card = deck.TakeTopCard();
            Console.WriteLine(card.Rank + " of " + card.Suit);

            card = deck.TakeTopCard();
            Console.WriteLine(card.Rank + " of " + card.Suit);

            //print Deck empty information
            //Console.WriteLine("Empty :" + deck.Empty);

            
            

         
            

            //cut the deck
            //deck.Cut(26);

            //take the top card and print info
            //Card card = deck.TakeTopCard();
            //Console.WriteLine(card.Rank + " of " + card.Suit);


            //Console.WriteLine();
            //deck.Print();


            Console.WriteLine();
            
            // create a new deck and print the contents of the deck

            // shuffle the deck and print the contents of the deck

            // take the top card from the deck and print the card rank and suit

            // take the top card from the deck and print the card rank and suit


        }
    }
}
