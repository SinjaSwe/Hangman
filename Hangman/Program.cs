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
                        Console.WriteLine($"You selected: {number}");
                    }
                } while (notNumber);

                return number;

            }

            static void PlayHangman()
            {                
                int guesses = 0;
                int noOfTries = 10;
                string wordToGuess;
                string[] allLettersTried;
                string[] correctEnteredLetters; // declared array for correct lettters guessed
                correctEnteredLetters = new string[0];
                string enteredLetter = String.Empty;
                allLettersTried = new string[0];
                
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
                
                        
        /*
         foreach (var item in allLettersTried)
        {
            Console.WriteLine("You have tried the following letters:" + item.ToString());
        }

        if (allLettersTried.Contains(enteredLetter))
        {
            Console.WriteLine("You already tried" + " " + enteredLetter + ", guess a different letter"); // LETTER NOW POPULATING
            Console.WriteLine("Number of guesses left: " + (noOfTries - guesses));
        }

        else
        {
            allLettersTried = new string[] { enteredLetter };

            if (wordToGuess.Contains(enteredLetter))
            {
                Console.WriteLine("You have choosen well! The letter" + "" + enteredLetter + "" + "is in the word");
                guesses++; // add one for every guess
                correctEnteredLetters = new string[] { enteredLetter };
                Console.WriteLine(correctEnteredLetters);
            }

            else
            {
                Console.WriteLine("You have choosen badly. The letter" + " " + enteredLetter + " " + "is not in the word");
                StringBuilder wrongGuesses = new StringBuilder();
                wrongGuesses.Append(enteredLetter);
                   guesses++; // add one for every guess
            }

        }
        if (HasWon(correctEnteredLetters, wordToGuess))
        {
            won = true;
            Console.WriteLine("Fantastic! You won! Go grab a beer.");
        }


    }
    if (!won)
    {
        Console.WriteLine($"Oh no, you lost! Correct answer is {wordToGuess}");
    }

    //Console.Write("Hit a key to try again");*/
        Console.ReadLine();



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
                foreach (char letter in guessedLetters)
                {
                    letters += " " + letter;
                }
                char guessedCharacter; 
                                 
                Console.WriteLine("Letters guessed: " + letters);
                Console.WriteLine("Guesses left: " + numTriesLeft);
                Console.WriteLine("Enter a letter: ");
                guessedCharacter = Convert.ToChar(Console.ReadLine());
                Console.WriteLine(wordToDisplay);
                string guess = Console.ReadLine();
                
                bool match = false;

                for (int i = 0; i < guessedLetters.Count; i++)
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
                    Console.WriteLine("You have choosen badly. The letter" + " " + guessedCharacter + " " + "is not in the word");
                    StringBuilder wrongGuesses = new StringBuilder();
                    wrongGuesses.Append(guessedCharacter);
                    //TO DO HOW TO WRITE THIS TO THE CONSOLE.     
                    //FIX DISPLAY SO There is room between each try
                    //Correct count of guesses
                }

                    
                




            }

            static bool HasWon(string[] rightEnteredLetters, string hiddenWord)
            {
                Console.WriteLine(string.Join("\n", rightEnteredLetters));
                string newRightEnteredLetters = String.Concat(rightEnteredLetters);
                Console.WriteLine(newRightEnteredLetters);
                for (int x = 0; x < hiddenWord.Length; x++)
                {
                    if (!newRightEnteredLetters.Contains(hiddenWord[x]))
                    {
                        return false;
                    }
                }

                return true;
            }

            

        }

 
        
    }
}
