using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace Ex02_csharp
{
    internal class Display
    {

        public string getGuessFromUser(int k_LengthOfSequence)
        {

            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine("Please type your next guess <A B C D> or Q to quit");

                isValid = true;
                string inputFromUser = Console.ReadLine();
                if (inputFromUser == "Q")
                {
                    return "Q";
                }

                string[] letters = inputFromUser.Split(' ');
                if (letters.Length != k_LengthOfSequence)
                {
                    Console.WriteLine("guess length incorrect. Guess must be of length " + k_LengthOfSequence);
                    isValid = false;
                    continue;
                }



                for (int i = 0; i < k_LengthOfSequence; i++)
                {
                    if (!Enum.TryParse(letters[i], out Game.eValidInputLetters letter))
                    {
                        isValid = false;
                        Console.WriteLine("invalid guess: " + letters[i]);
                            break;
                    }
                }

                if (isValid)
                {
                    return string.Join("", letters);
                }

            }
            return "Q";

        }

        public int getNumberOfGuessesFromUser()
        {
            Console.WriteLine("Enter the desired number of guesses (4-10): ");
            string inputFromUser = Console.ReadLine();

            if (int.TryParse(inputFromUser, out int numberOfGuessesFromUser))
            {
                while (numberOfGuessesFromUser < 4 || numberOfGuessesFromUser > 10)
                {
                    Console.WriteLine("Invalid input. Please enter a number within the range.");
                    numberOfGuessesFromUser = getNumberOfGuessesFromUser();
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
                numberOfGuessesFromUser = getNumberOfGuessesFromUser(); // Try again
            }


            return numberOfGuessesFromUser;
        }

        public void printScreen(int numberOfGuesses, List<string> guesses, List<string> results)
        {
            Console.WriteLine("Current board status");
            Console.WriteLine("|Pins:    |Results:|");
            Console.WriteLine("|=========|========|");
            Console.WriteLine("| # # # # |        |");
            Console.WriteLine("|=========|========|");

            for (int i = 0; i < numberOfGuesses; i++)
            {
                if (i < guesses.Count)
                {
                    string guessToPrint = string.Join(" ", guesses[i].ToList());
                    string resultsToPrint = string.Join(" ", results[i].ToList());
                    Console.WriteLine($"| {guessToPrint} | {resultsToPrint}|");
                }
                else
                {
                    Console.WriteLine("|         |        |");
                }
                Console.WriteLine("|=========|========|");

            }

        }


    }



}
