﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
  
            bool keepLooping = true;
            string[] words = { "house", "cat", "train", "school", "lamp", "apple", "elephant", "pillow", "tiger", "nerd", "computer", "flower", "mississippi" };
            char enteredLetter;
            int chances = 10;

            //while (keepLooping)

            {
                Console.WriteLine("Welcome to Hangman.");
                Console.WriteLine("Try and guess the following random word");


                
                Console.WriteLine("------Menu------");
                Console.WriteLine("1: Try a letter");
                Console.WriteLine("2: Try whole word");
                Console.WriteLine("3: Exit");

                double selection = AskForNumber();

                switch (selection)
                {
                    case 1:
                        ;// What happenes in the enter 1
                        break;

                    case 2:
                        ; //what happens if they enter 2

                    case 3:
                        keepLooping = false; //they wish to exit
                        Console.WriteLine("Thank you for playing Hangman!");
                        break;

                    default:
                        Console.WriteLine("not a valid selection. Please try again.");
                        break;
                }

            }

                if (lettersSubmitted.Contains(enteredLetter))
                {
                    // letter already tried
                }


                char letterSelected = AskForLetter(); //create a method here
                string wordSelected = AskForWord(); // create a method here
               
            
             
            static void RandomWord()
            {
                Random wordGenerator = new Random();
                int index = wordGenerator.Next(words.Length);
                Console.WriteLine($"Random word is {words[index]}");
            }

            static void AskForLetter ()
            {       
                do
                {
                    Console.Write("Please enter a letter: ");
                }

            }

            static void AskForWord ()

            {

            }

            
            
            static void lettersSubmitted ()
            {
                StringBuilder stringbuilder = new StringBuilder(lettersSubmitted.Lenght);
                for (int i = 0; i < lettersSubmitted.Lenght; i++)
                    showUser.Append('_');      
     
                List<char> lettersInWord = new List<char>();
                List<char> lettersNotInWord = new List<char>();
            }

            static double AskForNumber()
            {
                bool notNumber = false;

                double number = 0;

                do
                {
                    Console.Write("Please enter a valid number; ");

                    try
                    {
                        number = double.Parse(Console.ReadLine());
                        notNumber = false;
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("I do not understand your input.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Your number was too big for this game.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Was unable to read your entry. \nYou must use a number and not text.");
                    }
                    catch
                    {
                        Console.WriteLine("Some error happened.");
                        notNumber = true;
                    }
                    finally
                    {
                        Console.WriteLine($"You selected: {number}");
                    }
                } while (notNumber);

                return number;

            }
            /*
 * Method
    Is the letter present in the word Yes

    Method ö randowm work from array

// use Random to select a random word from the array in hangman

Random randomWord = new Random();
for (string i = 0; i < 10; i++)
{
    Console.WriteLine(randomWord.Next(1, 10))

}
*/



        }
    }
}