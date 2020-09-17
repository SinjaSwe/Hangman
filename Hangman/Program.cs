using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {


            bool keepLooping = true;

            //int chances = 10;
            //string whatsTheWord = wordGenerator.Next(0, words.Length)];

            while (keepLooping)

            {
                Console.WriteLine("Welcome to Hangman.");
                Console.WriteLine("------Options------");
                Console.WriteLine("1: Play");
                Console.WriteLine("2: Exit");

                double selection = AskForNumber();

                switch (selection)
                {
                    case 1:
                        PlayHangman(); // Please 1 to play
                        break;

                    case 2:
                        keepLooping = false; //they wish to exit
                        Console.WriteLine("Thank you for playing Hangman!");
                        break;

                    default:
                        Console.WriteLine("not a valid selection. Please try again.");
                        break;
                }


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

            static void PlayHangman()

            {
                bool won = false;
                int guesses = 0;
                int noOfGuesses = 10;
                                               
                string[] arrayOfWords = { "house", "cat", "train", "school", "lamp", "apple", "elephant", "pillow", "tiger", "nerd", "computer", "flower", "mississippi" }; // my secret word list
                int choice = new Random().Next(arrayOfWords.Length);
                Console.WriteLine("The word is: " + arrayOfWords[choice]);                                   



                StringBuilder hiddenLetters = new StringBuilder();
                for (int i = 0; i < (arrayOfWords[choice]).Length; i++)
                {
                    hiddenLetters.Append('-');
                }
              
                string enteredLetter = String.Empty;
                string usedLetters = String.Empty;
                

                while (guesses < noOfGuesses && !won)
                {
                    Console.WriteLine("Enter a letter: ");
                    enteredLetter = Console.ReadLine();
                    //guess = usedLetters[0]; // array of tried letters
                                        
                    guesses++; // add one for every guess
                    
                    if (usedLetters.Contains(enteredLetter))
                    {
                        Console.WriteLine("You already tried {0}, guess a different letter");
                        Console.WriteLine("Number of guesses left: " + (noOfGuesses - guesses));                      
                    }

                    if ((arrayOfWords[choice]).Contains(enteredLetter))
                    {
                        Console.WriteLine("You have choosen well! The letter {} is in the word");

                        for (int x = 0; x < (arrayOfWords[choice]).Length; x++)
                        {
                            if ((arrayOfWords[choice])[x] == guess )
                            {
                                hiddenLetters.Append('-');
                            }
                        }                      

                     }

                    else

                    {
                        Console.WriteLine("You have choosen badly. The letter {0} is not in the word");
                        Console.WriteLine(hiddenLetters.ToString());  
                    }

                    if ((arrayOfWords[choice]).ToString().Equals(arrayOfWords[choice]))
                    {
                        won = true;
                    }

                    if (won)
                    {
                        Console.WriteLine("Fantastic! You won! Go grab a beer.");
                    }
                    
                    else

                    {
                        Console.WriteLine($"Oh no, you lost! Correct answer is {(arrayOfWords[choice])}");
                    }

                    Console.Write("Hit a key to try again");
                    Console.ReadLine();
                }                   
                
            }         

                

         }

 
        
    }
}
