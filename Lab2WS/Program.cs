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
            string response = "Y";
            while(response.ToUpper() == "Y")
            {
                try
                {
                    Console.WriteLine(Constants.WELCOMEMSG);

                    string option = Console.ReadLine() ?? throw new Exception(Constants.NULLSTRINGMSG);

                    while (option != "M" && option != "m" && option != "F" && option != "f") // Added validation for user input. - Justin Alves
                    {
                        Console.WriteLine(Constants.UNRECMSG);
                        option = Console.ReadLine() ?? throw new Exception(Constants.NULLSTRINGMSG);
                    }

                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine(Constants.FILEMSG);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine(Constants.MANUALMSG);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine(Constants.UNRECMSG);
                            break;
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(Constants.EXCEPTIONMSG + e.Message);
                }

                Console.WriteLine(Constants.YENOMSG);
                response = Console.ReadLine();

                while(response.ToUpper() != "Y" && response.ToUpper() != "N")
                {
                    Console.WriteLine(Constants.UNRECMSG);
                    response = Console.ReadLine();
                }
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

            String input = Console.ReadLine().Replace(" ", "");
  
            var listWords = input.Split(',');
            
            DisplayMatchedScrambledWords(listWords);

        }

        // Finished DisplayMatchedScrambledWords Method - Justin. M
        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(Constants.WORDLIST); 

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

            if(matchedWords == null)
            {
                Console.WriteLine(Constants.NOFOUNDMSG);
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
