using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_csharp
{
    public class Game
    {
        public const int k_LengthOfSequence = 4;
        public const int k_MinNumberOfGuesses = 4;
        public const int k_MaxNumberOfGuesses = 10;

        public struct ResultOfSequenceFromUser
        {
            public int m_NotInTheRightPosition;
            public int m_RightPositionAndLetter;

        }

        public struct GuessAndResult
        {
            public ResultOfSequenceFromUser m_ResultOfGuess;
            public string m_Guess;
        }

        public enum eValidInputLetters
        {
            A, B, C, D, E, F, G, H, Q
        }

        private string m_ChosenSequence; //the sequece of letters that the computer chose
        private int m_MaxNumberOfGuesses;
        private List<GuessAndResult> m_GuessesAndResultsHistory;//list of history


        public List<GuessAndResult> GuessesAndResultsHistory
        {
            get {return m_GuessesAndResultsHistory; }
        }

        public int MaxNumberOfGuesses
        {
            get { return m_MaxNumberOfGuesses; }
            set { m_MaxNumberOfGuesses = value; }
        }

        public string ChosenSequence
        {
            get { return m_ChosenSequence; }
            set { generateSequence(); }
        }

        //generates a sequence of 4 letters from the enum excluding Q without duplicates
        private void generateSequence()
        {
            Random rand = new Random();
            string sequence = string.Empty;
            
            while(sequence.Length < k_LengthOfSequence)
            {
                int randomValueInRange = rand.Next(0, 7);
                eValidInputLetters randomLetter = (eValidInputLetters)randomValueInRange;

                while (sequence.Contains(randomLetter.ToString())) //checking no duplicates
                {
                    randomValueInRange = rand.Next(0, 7);
                    randomLetter = (eValidInputLetters)randomValueInRange;
                }

                sequence += randomLetter.ToString();

            }

            m_ChosenSequence = sequence;
        }


        public Game(int i_ChosenNumberOfGuesses) {
           
            m_MaxNumberOfGuesses = i_ChosenNumberOfGuesses;
            generateSequence();
            m_GuessesAndResultsHistory = new List<GuessAndResult>();
        }

        public void UpdateResultOfSequence(string i_SequenceFromUser)
        {
            int numberOfCorrectPositionLetters = 0;
            int numberOfWrongPositionLetters = 0;
            bool[] matchedInTheChosenSequence = new bool[k_LengthOfSequence];
            bool[] matchedInTheUserSequence = new bool[k_LengthOfSequence];
            GuessAndResult currentGuessAndResult;

            for (int i = 0; i < k_LengthOfSequence; i++)
            {
                if (i_SequenceFromUser[i] == m_ChosenSequence[i])
                {
                    numberOfCorrectPositionLetters++;
                    matchedInTheChosenSequence[i] = true;
                    matchedInTheUserSequence[i] = true;
                }
            }

            for (int i = 0; i < k_LengthOfSequence; i++)
            {
                if (matchedInTheUserSequence[i]) continue;

                for (int j = 0; j < k_LengthOfSequence; j++)
                {
                    if (!matchedInTheChosenSequence[j] && i_SequenceFromUser[i] == m_ChosenSequence[j])
                    {
                        numberOfWrongPositionLetters++;
                        matchedInTheChosenSequence[j] = true;
                        break;
                    }
                }
            }

            currentGuessAndResult.m_Guess = i_SequenceFromUser;
            currentGuessAndResult.m_ResultOfGuess.m_RightPositionAndLetter = numberOfCorrectPositionLetters;
            currentGuessAndResult.m_ResultOfGuess.m_NotInTheRightPosition = numberOfWrongPositionLetters;
            m_GuessesAndResultsHistory.Add(currentGuessAndResult);//adding this guess and result to the list
           
        }

   

       

    }


}
