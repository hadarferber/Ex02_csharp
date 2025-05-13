using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_csharp
{
    internal class Game
    {
        public const int k_LengthOfSequence = 4;
        public const int k_MinNumberOfGuesses = 4;
        public const int k_MaxNumberOfGuesses = 10;

        private struct ResultOfSequenceFromUser
        {
            public int m_NotInTheRightPosition;
            public int m_RightPositionAndLetter;

        }

        public enum eValidInputLetters
        {
            A, B, C, D, E, F, G, H, Q
        }

        private string m_ChosenSequence; //the sequece of letters that the computer chose
        private int m_MaxNumberOfGuesses;
        private ResultOfSequenceFromUser m_ResultOfSequence;
        private int m_currentNumberOfGuesses = 0;

        

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
        
        }

        public void updateResultOfSequence(string i_SequenceFromUser)
        {
            int numberOfCorrectPositionLetters = 0;
            int numberOfWrongPositionLetters = 0;

            bool[] matchedInTheChosenSequence = new bool[k_LengthOfSequence];
            bool[] matchedInTheUserSequence = new bool[k_LengthOfSequence];

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

            m_ResultOfSequence.m_RightPositionAndLetter = numberOfCorrectPositionLetters;
            m_ResultOfSequence.m_NotInTheRightPosition = numberOfWrongPositionLetters;

            m_currentNumberOfGuesses++;
        }

        public void getResults(out int hit, out int miss)
        {
            hit = m_ResultOfSequence.m_RightPositionAndLetter;
            miss = m_ResultOfSequence.m_NotInTheRightPosition;
        }

    }


}
