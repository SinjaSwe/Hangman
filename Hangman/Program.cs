using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                        Console.WriteLine("      ");
                        ///Console.WriteLine($"You selected: {number}");
                    }
                } while (notNumber);

                return number;

            }

            static void PlayHangman()
            {                
                int guesses = 0;
                int noOfTries = 10;
                string wordToGuess;
                string[] correctEnteredLetters; // declared array for correct lettters guessed
                correctEnteredLetters = new string[0];
                              
                
                // Array of Strings
                string[] arrayOfWords = { "house", "train", "school", "lamp", "apple", "elephant", "pillow", "tiger", "nerd", "computer", "flower", "mississippi" };

                //Random Word Generator
                Random stringRandom = new Random();
                int random = stringRandom.Next(arrayOfWords.Length);
                wordToGuess = Convert.ToString(arrayOfWords[random]);
                Console.WriteLine($"Randomly selected word is {wordToGuess}");  // only for use in testing 

                List<char> guessedLetters = new List<char>();
                bool won = false;

                while (guesses < noOfTries && !won)
                {
                    string wordToDisplay = DisplayWord(guessedLetters, wordToGuess); //call method using list of guessed letter and the hidden word                                      

                    if (!wordToDisplay.Contains("_"))
                    {
                        won = true;
                        Console.WriteLine("Fantastic! You won! Go grab a beer.");
                    }
                    else if ((noOfTries - guesses) <= 0)
                    {
                        won = true;
                        Console.WriteLine("Oh no, you lost! The hidden word was:  " + wordToGuess);
                    }
                    else
                    {
                        GuessLetters(guessedLetters, wordToGuess, wordToDisplay, ref noOfTries);
                    }
                }          
            }
            
            static string DisplayWord(List<char> guessedLetters, string wordToGuess)
            {
                //Method to display hidden word             

                string displayWord = ""; // empty string to fill 
                if (guessedLetters.Count == 0)
                {
                    foreach (char letter in wordToGuess)
                    {
                        displayWord += "_ ";
                    }
                    return displayWord;
                }
                foreach (char letter in wordToGuess)
                {
                    bool correctTry = false; 
                    foreach (char key in guessedLetters)
                    {
                        if (key == letter)
                        {
                            displayWord += key + " ";
                            correctTry = true;
                            break;
                        }
                        else
                        {
                            correctTry = false;
                        }
                    }
                    if (correctTry == false)
                    {
                        displayWord += "_";
                    }             
                }
                return displayWord;
            }

            static void GuessLetters (List<char> guessedLetters, string wordToGuess, string wordToDisplay, ref int numTriesLeft)
            {
                string letters = "";
                string guess;
                foreach (char letter in guessedLetters)
                {
                    letters += " " + letter;
                }
                char guessedCharacter;

                Console.WriteLine("      "); 
                Console.WriteLine("-------Current Game Status-------");
                Console.WriteLine("Letters guessed: " + letters);
                Console.WriteLine("Guesses left: " + numTriesLeft);
                Console.WriteLine("---------------------------------");
                Console.WriteLine(" "); 
                Console.WriteLine("The hidden word:" + " " + wordToDisplay);
                Console.WriteLine(" "); 
                Console.WriteLine("Enter a letter: ");
                guess = Console.ReadLine();
                
                guessedCharacter = Convert.ToChar(Console.ReadLine());           // PROBLEM HERE      
                                
                bool match = false;

                if (guess.Length > 1)
                {
                    Console.WriteLine(guess == wordToDisplay ? string.Format("Well done! You guessed the correct word", wordToDisplay) : string.Format("Opps! Not the right word"));
                }
                /*else

                    try
                    {
                        guessedCharacter = Convert.ToChar(guess);
                        if (!char.IsLetter(guessedCharacter))
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Only letters or words can be tried");
                    }
                */

                for (int i = 0; i < guessedLetters.Count; i++) //PRINTS THIS TOO MANY TIMES
                {
                    if (guessedLetters.Contains(guessedCharacter))
                    {
                        Console.WriteLine("You already tried" + " " + guessedCharacter + ", guess a different letter");
                        match = true;
                    }
                }

                if (match == false)
                {
                    guessedLetters.Add(guessedCharacter);
                    numTriesLeft -= 1;
                }

                if (wordToGuess.Contains(guessedCharacter))

                {
                    Console.WriteLine("Well done! The letter " + "" + guessedCharacter + "" + " is contained within the hidden word");
                }

                else
                {
                    Console.WriteLine("The letter" + " " + guessedCharacter + " " + "is not in the word");
                    StringBuilder wrongGuesses = new StringBuilder();
                    wrongGuesses.AppendLine(Convert.ToString(guessedCharacter));
                    Console.WriteLine("You have in guessed the following wrong letters:" +""+ wrongGuesses);
                    
                    
                    //TO DO HOW TO WRITE THIS TO THE CONSOLE.     
                    //PROBLEM WITH GUESSING A LETTER TWICE. Prints too many times
                    //Guess a word
                    //Exception when enter not a char

                }
                                    
                
            }
                       
        }

 
        
    }
}
