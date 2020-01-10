using System;
using System.Collections.Generic;

namespace Hangman.Models
{
    public static class Game
    {
        public static List<string> WordList = new List<string>{"retired", "difference", 
        "warthwax", "debate", "speech"};

        public static int GameCount { get; set; }

        public static string CurrentWord { get; set; }
        public static string CurrentMatch { get; set; }
        public static bool WinningStatus { get; set; }
        public static List<char> userGuesses { get; set;}

        public static void StartGame()
        {
            Random rnd = new Random();
            int  randomNum = rnd.Next(0, WordList.Count);
            CurrentWord = WordList[randomNum];
            GameCount = 0;
            CurrentMatch = "";
            WinningStatus = true;
            foreach(char letter in CurrentWord)
            {
                CurrentMatch += "_ ";
            }
            userGuesses = new List<char>{};
        }

        public static string CompleteGuess(char userGuess)
        {
            if(GameCount == 6)
            {
                WinningStatus = false;
                return CurrentWord;
            }
            else
            {
                return CheckLetter(userGuess);
            }
        }

        public static string CheckLetter(char userGuess)
        {
            for (int i = 0; i <userGuesses.Count; i++)
            {
                if (userGuesses[i] == userGuess)
                {
                    return "You have already guess this word. Try another guess.";
                }
            }

            char[] charArray = CurrentMatch.ToCharArray();
            for(int i = 0; i < CurrentWord.Length; i++)
            {
                if(CurrentWord[i] == userGuess)
                {
                    charArray[i] = userGuess;
                }
            }

            CurrentMatch = new string(charArray);
            GameCount++;
            return CurrentMatch;
        }

        public static bool CheckWord(string userGuess)
        {
            if(CurrentWord == userGuess)
            {
                return true;
            }
            else
            {
                GameCount++;
                if(GameCount == 6)
                {
                    WinningStatus = false;
                }
                return false;
            }
        }
    }
}