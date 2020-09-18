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
                string wordToGuess;

                //char guess;
                //string hiddenLetters;

                string[] arrayOfWords = { "house", "train", "school", "lamp", "apple", "elephant", "pillow", "tiger", "nerd", "computer", "flower", "mississippi" };

                Random stringRandom = new Random();
                int random = stringRandom.Next(arrayOfWords.Length);
                wordToGuess = Convert.ToString(arrayOfWords[random]);                                            
                Console.WriteLine($"Randomly selected word is {wordToGuess}");
                string[] allLettersTried;

                //1.
                
                //2. Fix Loop

                //3. Show part filled word


                //string correctGuesses; 

                string enteredLetter = String.Empty;
                string usedLetters = String.Empty;
                
                while (guesses < noOfGuesses && !won)
                {
                    Console.WriteLine("Enter a letter: ");
                    enteredLetter = Console.ReadLine();
                    allLettersTried = new string[] { enteredLetter };

                    foreach (var item in allLettersTried)
                    {
                        Console.WriteLine("You have tried the following letters:" + item.ToString());
                    }                    

                    //TO DO TOMORROW

                    // Get it to loop around until each letter is filled

                    //char[] listOfLetters = new char[] { }; // array to capture entered letters
                    //if length of enteredletter is 1 then its a char
                    //  else its a string.   and if so, 
                    //listOfLetters[0] = Convert.ToChar(enteredLetter);


                    if (allLettersTried.Contains(enteredLetter))
                    {
                        Console.WriteLine("You already tried" +" "+ enteredLetter + ", guess a different letter"); // LETTER NOW POPULATING
                        Console.WriteLine("Number of guesses left: " + (noOfGuesses - guesses));                      
                    }

                    

                    else if (wordToGuess.Contains(enteredLetter))
                    {
                        Console.WriteLine("You have choosen well! The letter" +""+ enteredLetter +""+ "is in the word");
                        guesses++; // add one for every guess

                        string[] arrayEnteredLetters; // declared array for correct lettters guessed
                        arrayEnteredLetters = new string[] { enteredLetter };
                        Console.WriteLine(arrayEnteredLetters);
                                               
                       /* for (int x = 0; x < wordToGuess.Length; x++)
                        {
                            if (wordToGuess[x] == guess)
                            {
                                arrayEnteredLetters[x] = guess;
                            }
                        }

                        Console.WriteLine(hiddenLetters.ToString()); */
                     }

                    else

                    {
                        Console.WriteLine("You have choosen badly. The letter" + " "+ enteredLetter + " " + "is not in the word");
                        //Console.WriteLine(hiddenLetters.ToString());
                        guesses++; // add one for every guess

                        StringBuilder wrongGuesses = new StringBuilder();
                        wrongGuesses.Append(enteredLetter); 
                    }

                    if (wordToGuess.ToString().Equals(wordToGuess))
                    {
                        won = true;
                        Console.WriteLine("Fantastic! You won! Go grab a beer.");

                    }
                                                         
                                      
                }
                if (!won)
                {
                    Console.WriteLine($"Oh no, you lost! Correct answer is {wordToGuess}");
                }

                //Console.Write("Hit a key to try again");
                Console.ReadLine();


            }         

                

         }

 
        
    }
}
