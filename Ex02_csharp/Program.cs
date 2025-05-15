using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace Ex02_csharp
{
    public class Program
    {
        static void Main()
        {
            Program program = new Program();

            program.startGame();    


        }

        private void startGame()
        {
            Display display = new Display();

            bool isTheUserCurrentlyPlaying = true;

            while (isTheUserCurrentlyPlaying)
            {
                bool won = false;
                Screen.Clear();

                Game game = new Game(display.GetNumberOfGuessesFromUser());

                while (game.GuessesAndResultsHistory.Count < game.MaxNumberOfGuesses) //current guesses are less than the max
                {
                    display.PrintScreen(game);
                    string newGuess = display.GetGuessFromUser(Game.k_LengthOfSequence);
                    if (newGuess == "Q")
                    {
                        Console.WriteLine("Goodbye!");
                        return;
                    }

                    game.UpdateResultOfSequence(newGuess);

                    if (game.GuessesAndResultsHistory.Last().m_ResultOfGuess.m_RightPositionAndLetter == Game.k_LengthOfSequence) //player has won
                    {
                        won = true;
                        break;
                    }
                }

                display.PrintScreen(game);

                if (won)
                {
                    Console.WriteLine("\nYou guessed right yay!");
                }
                else
                {
                    Console.WriteLine("No more guesses allowed. You Lost.");
                }

                Console.WriteLine("Would you like to start a new game? <Y/N>");
                String responseForKeepingPlaying = Console.ReadLine();
                if (responseForKeepingPlaying == "Y")
                {
                    isTheUserCurrentlyPlaying = true;
                }
                else
                {
                    isTheUserCurrentlyPlaying = false;
                }

            }
        }

    }
}
