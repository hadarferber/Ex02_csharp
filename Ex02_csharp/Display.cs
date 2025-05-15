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
using static Ex02_csharp.Game;

namespace Ex02_csharp
{
    internal class Display
    {

        public string GetGuessFromUser(int k_LengthOfSequence)
        {

            bool isValid = false;
            string inputFromUser = "Q";

            while (!isValid)
            {
                Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");

                isValid = true;
                inputFromUser = Console.ReadLine();
                if (inputFromUser == "Q")
                {
                    break;
                }

                if (inputFromUser.Length != k_LengthOfSequence)
                {
                    Console.WriteLine("guess length incorrect. Guess must be of length " + k_LengthOfSequence);
                    isValid = false;
                    continue;
                }


                if (!IsValidUserSequence(inputFromUser)) //if it is not valid
                {
                    isValid = false;
                }

            }

            return inputFromUser;

        }

        public int GetNumberOfGuessesFromUser()
        {
            Console.WriteLine("Enter the desired number of guesses (4-10): ");
            string inputFromUser = Console.ReadLine();

            if (int.TryParse(inputFromUser, out int numberOfGuessesFromUser))
            {
                while (numberOfGuessesFromUser < 4 || numberOfGuessesFromUser > 10)
                {
                    Console.WriteLine("Invalid input. Please enter a number within the range.");
                    numberOfGuessesFromUser = GetNumberOfGuessesFromUser();
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
                numberOfGuessesFromUser = GetNumberOfGuessesFromUser(); // Try again
            }

            return numberOfGuessesFromUser;
        }

        public void PrintScreen(Game game)
        {
            Screen.Clear();
            Console.WriteLine("Current board status");
            Console.WriteLine("|Pins:    |Results:|");
            Console.WriteLine("|=========|========|");
            Console.WriteLine("| # # # # |        |");
            Console.WriteLine("|=========|========|");

            List<GuessAndResult> history = game.GuessesAndResultsHistory;

            for (int i = 0; i < game.MaxNumberOfGuesses; i++)
            {
                if (i < game.GuessesAndResultsHistory.Count)
                {
                    string resultStringOfXandV = new string('V', game.GuessesAndResultsHistory[i].m_ResultOfGuess.m_RightPositionAndLetter) 
                        + new string('X', game.GuessesAndResultsHistory[i].m_ResultOfGuess.m_NotInTheRightPosition)
                        + new string(' ', Game.k_LengthOfSequence - game.GuessesAndResultsHistory[i].m_ResultOfGuess.m_RightPositionAndLetter - game.GuessesAndResultsHistory[i].m_ResultOfGuess.m_NotInTheRightPosition);

                    string guessToPrint = string.Join(" ", game.GuessesAndResultsHistory[i].m_Guess.ToList());
                    string resultsToPrint = string.Join(" ", resultStringOfXandV.ToList());
                    Console.WriteLine($"| {guessToPrint} | {resultsToPrint}|");
                }
                else
                {
                    Console.WriteLine("|         |        |");
                }
                Console.WriteLine("|=========|========|");

            }

        }


        public bool IsValidUserSequence(string userSequence)   //true if is good and false if bad
        {
            List<char> seenCharactersInTheSequence = new List<char>();

            foreach (char c in userSequence)
            {
                // Check for duplicate
                if (seenCharactersInTheSequence.Contains(c))
                {
                    return false; // Duplicate found
                }

                // Check if it's in the enum
                if (!Enum.IsDefined(typeof(eValidInputLetters), c.ToString()))
                {
                    return false; // Invalid letter
                }

                seenCharactersInTheSequence.Add(c);
            }

            return true; // All letters are unique and valid
        }



    }



}
