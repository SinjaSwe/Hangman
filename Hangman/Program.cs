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
                Console.WriteLine(" ________    ");
                Console.WriteLine(" |/   |      ");
                Console.WriteLine(" |   (_)     ");
                Console.WriteLine(" |   /|-     ");
                Console.WriteLine(" |    |      ");
                Console.WriteLine(" |   / }     ");
                Console.WriteLine(" |           ");
                Console.WriteLine(" |___        ");

                //Variables
                int guesses = 0;
                int noOfTries = 10;
                char[] correctEnteredLetters = new char[] { };                
                List<char> guessedLetters = new List<char>();
                bool won = false;
                int returnCase = 0;

                // Call method to generate a random word
                string wordToGuess = RandomGenerator(); 

                while (guesses < noOfTries && !won)
                {
                    string wordToDisplay = DisplayWord(guessedLetters, wordToGuess); //call method using list of guessed letter and the hidden word                                      

                    if (!wordToDisplay.Contains("_"))
                    {
                        won = true;
                        Console.WriteLine(" "); 
                        Console.WriteLine("Fantastic! You won! Go grab some wine!. The hidden word was: " +"" + wordToGuess);
                        Console.WriteLine(" "); Replay();

                    }
                    else if ((noOfTries - guesses) <= 0)
                    {
                        won = true;
                        Console.WriteLine(" "); 
                        Console.WriteLine("Oh no, you lost! The hidden word was:  " + wordToGuess);
                        Console.WriteLine(" "); 
                        if (Replay())
                        {
                            //Reset variables when restarting the game
                            guessedLetters = new List<char>();
                            guesses = 0;
                            won = false;
                            wordToGuess = RandomGenerator();
                            noOfTries = 10;
                        }
                    }

                    else
                    {
                        returnCase = GuessLetters(guessedLetters, wordToGuess, wordToDisplay, ref noOfTries, ref correctEnteredLetters);
                        if (returnCase == 3)
                        {
                            //Reset variables when restarting the game
                            guessedLetters = new List<char>();
                            guesses = 0;
                            won = false;
                            wordToGuess = RandomGenerator();
                            noOfTries = 10;
                        }
                    }
                }
            }

            static string DisplayWord(List<char> guessedLetters, string wordToGuess)    //Method to display hidden word      
            {                   
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

            static int GuessLetters(List<char> guessedLetters, string wordToGuess, string wordToDisplay, ref int numTriesLeft, ref char[] correctEnteredLetters) // Guessed letters method
            {
                //variables
                int returnCase = 0;
                string letters = "";
                string guess;
                bool match = false;

                foreach (char letter in guessedLetters)
                {
                    letters += " " + letter;
                }
                char guessedCharacter;
                
                Console.WriteLine("\n-------Current Game Status-------");
                Console.WriteLine("Letters guessed: " + letters);
                Console.WriteLine("Guesses left: " + numTriesLeft);
                Console.WriteLine("---------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan; 
                Console.WriteLine("\nThe hidden word:" + " " + wordToDisplay);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter a letter: ");
                guess = Console.ReadLine();               
        
                if (guess.Length == 1)
                {
                    guessedCharacter = Convert.ToChar(guess);                    
                        if (guessedLetters.Contains(guessedCharacter))
                        {
                            Console.WriteLine("You already tried" + " " + guessedCharacter + ", guess a different letter");
                            match = true;
                        }                    

                    if (match == false)
                    {
                        guessedLetters.Add(guessedCharacter);
                        numTriesLeft -= 1;
                    }

                    if (wordToGuess.Contains(guessedCharacter))

                    {
                        //array for right guesses
                        
                        if (!correctEnteredLetters.Contains(guessedCharacter))
                        {
                            Console.WriteLine("\nWell done! The letter " + "" + guessedCharacter + "" + " is contained within the hidden word");

                            var tempList = correctEnteredLetters.ToList();
                            tempList.Add(guessedCharacter);
                            correctEnteredLetters = tempList.ToArray();
                            
                            Console.WriteLine("\nYou have guessed the following correct letters: ");
                            foreach (var item in correctEnteredLetters)
                            {
                                Console.WriteLine(item.ToString()); 
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("The letter" + " " + guessedCharacter + " " + "is not in the word");
                        StringBuilder wrongGuesses = new StringBuilder();
                        wrongGuesses.AppendLine(Convert.ToString(guessedCharacter));
                        Console.WriteLine("\nYou have  guessed the following wrong letters:" + " " + wrongGuesses);
                        returnCase = 2;
                    }
                }
                else if (guess.Length >= 1)
                {                    
                    if (guess == wordToGuess)
                    {
                        numTriesLeft -= 1; 
                        Console.WriteLine("\nWell done! You guessed the right word!");
                    }
                    else
                    {
                        numTriesLeft -= 1; 
                        Console.WriteLine("\nBoo hoo! Better luck next time");
                    }

                    bool isReplay = Replay();
                    if (isReplay)
                    {
                        returnCase = 3;
                    }
                }

                return returnCase;
            }

            static string RandomGenerator ()
            {                
                string[] arrayOfWords = { "house", "train", "school", "lamp", "apple", "elephant", "pillow", "tiger", "nerd", "computer", "lexicon", "mississippi" }; // Array of Strings
                string wordToGuess;

                //Random Word Generator
                Random stringRandom = new Random();
                int random = stringRandom.Next(arrayOfWords.Length);
                wordToGuess = Convert.ToString(arrayOfWords[random]);
                //Console.WriteLine($"Randomly selected word is {wordToGuess}");  // only for use in testing
                return wordToGuess;
            }

            static bool Replay() // if player wants to try again
            {
                bool isReplay = false;
                Console.WriteLine ("\nFancy another try? (y/n)"!);
                string tryAgain = Console.ReadLine();
                if (tryAgain == "n")
                {
                    Environment.Exit(1);
                }
                else
                {
                    isReplay = true;
                }

                return isReplay;
            }
                     
        }
    }

}

               

           
           