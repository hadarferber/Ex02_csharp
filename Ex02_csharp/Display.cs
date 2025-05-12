using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_csharp
{
    internal class Display
    {
        void Main()
        {
            int numberOfGuesses = getNumberOfGuessesFromUser();
            //need to add reference to the game file class

            










        }

        private int getNumberOfGuessesFromUser()
        {
            Console.WriteLine("Enter the desired number of guesses (4-10): ");
            string inputFromUser = Console.ReadLine();

            if (int.TryParse(inputFromUser, out int numberOfGuessesFromUser))
            {
                while(numberOfGuessesFromUser < 4 || numberOfGuessesFromUser > 10)
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



    }
}
