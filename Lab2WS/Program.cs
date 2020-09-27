using System;
using System.Collections.Generic;

namespace Lab2WS
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the scrambled words manually or as a file: f - file, m = manual");

                string option = Console.ReadLine() ?? throw new Exception("String is null");
                
                while (option != "M" && option != "m" && option != "F" && option != "f") // Added validation for user input. - Justin Alves
                {
                    Console.WriteLine("Input is invalid. Please enter either f - file, m = manual ");
                    option = Console.ReadLine() ?? throw new Exception("String is null");
                }
                
                switch (option.ToUpper())
                {
                    case "F":
                        Console.WriteLine("Enter the full path and filename >");
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case "M":
                        Console.WriteLine("Enter word(s) separated by a comma");
                        ExecuteScrambledWordsManualEntryScenario();
                        break;
                    default:                       
                        Console.WriteLine("The entered option was not recognized");
                        break;
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry an error has occurred.. " + e.Message);
            }
            


        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string fileName = Console.ReadLine();
            string[] scrambledWords = fileReader.Read(fileName);
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario() // Finished ExecuteScrambledWordsManualEntryScenario method. - Justin Alves
        {

            String input = Console.ReadLine();

            var listWords = input.Split(',');

            DisplayMatchedScrambledWords(listWords);

            Console.WriteLine("Would you like to continue? Y / N.");

            String response = Console.ReadLine();

            while (response.ToUpper() == "Y")
            {
                Console.WriteLine("Enter word(s) separated by a comma.");

                input = Console.ReadLine();

                var listWords2 = input.Split(',');

                DisplayMatchedScrambledWords(listWords2);

                Console.WriteLine("Would you like to continue? Y / N.");

                response = Console.ReadLine();

            }

        }

        // Finished DisplayMatchedScrambledWords Method - Justin. M
        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(@"wordlist.txt"); // Put in a constants file. CAPITAL LETTERS.  READONLY.

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

            if(matchedWords == null)
            {
                Console.WriteLine("No words found.");
            }
            else
            {
                foreach(MatchedWord matche in matchedWords)
                {
                    Console.WriteLine("MATCH FOUND FOR {0}: {1}", matche.Word, matche.ScrambledWord);
                }
            }


            // Rule:  Use a formatter to display ... eg:  {0}{1}

            // Rule:  USe an IF to determine if matchedWords is empty or not......
            //            if empty - display no words found message.
            //            if NOT empty - Display the matches.... use "foreach" with the list (matchedWords)
        }
    }
}
