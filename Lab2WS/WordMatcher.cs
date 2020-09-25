using System;
using System.Collections.Generic;

namespace Lab2WS
{
    class WordMatcher
    {
        // Finished Match Method - Justin.M
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scrambledWord in scrambledWords)
            {
                foreach (string word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });
                    }
                    else
                    {
                        char[] wordScr = scrambledWord.ToCharArray(); Array.Sort(wordScr); 
                        String scrString = wordScr.ToString();
                        char[] word1 = word.ToCharArray(); Array.Sort(word1); 
                        String word1String = word1.ToString();
                        if(scrString == word1String)
                        {
                            matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });
                        }
                    }

                }
            }

            return matchedWords;
        }



    }
}
