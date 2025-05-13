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
            Display display = new Display();

            bool isPlaying = true;
            int hit = 0;
            int miss = 0;

            while (isPlaying)
            {
                bool won = false;
                Screen.Clear();

                int numberOfGuesses = display.getNumberOfGuessesFromUser();

                Game game = new Game(numberOfGuesses);
                List<string> guesses = new List<string>();
                List<string> results = new List<string>();
                const int k_LengthOfSequence = Game.k_LengthOfSequence;

                while (guesses.Count < numberOfGuesses)
                {
                    Screen.Clear();
                    display.printScreen(numberOfGuesses, guesses, results);
                    string newGuess = display.getGuessFromUser(k_LengthOfSequence);
                    if (newGuess == "Q")
                    {
                        Console.WriteLine("Bye");
                        return;
                    }

                    game.updateResultOfSequence(newGuess);

                    game.getResults(out hit, out miss);

                    guesses.Add(newGuess);
                    results.Add(new string('V', hit) + new string('X', miss));

                    if (hit == k_LengthOfSequence)
                    {
                        won = true;
                        break;
                    }
                }

                Screen.Clear();
                display.printScreen(numberOfGuesses, guesses, results);

                if (won)
                {
                    Console.WriteLine("you guessed right yay");
                }
                else
                {
                    Console.WriteLine("No more guesses allowed. You Lost.");
                }

                Console.WriteLine("Would you like to start a new game? <Y/N>");
                String response = Console.ReadLine();
                if (response == "Y")
                {
                    isPlaying = true;
                }
                else
                {
                    isPlaying = false;
                }

            }


        }

    }
}
