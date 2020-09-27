using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2WS
{
    class Constants // Added Constants class and replaced strings accordingly. - Justin Alves
    {

        public const string WORDLIST = (@"wordlist.txt");

        public const string FILEMSG = ("Enter the full path and filename >.");

        public const string MANUALMSG = ("Enter word(s) separated by a comma.");

        public const string UNRECMSG = ("The entered option was not recognized. Re-enter input.");

        public const string YENOMSG = ("Would you like to continue Y/N.");

        public const string WELCOMEMSG = ("Enter the scrambled words manually or as a file: f - file, m = manual");

        public const string NOFOUNDMSG = ("No words found.");

        public const string EXCEPTIONMSG = ("Sorry an error has occurred... ");

        public const string NULLSTRINGMSG = ("String is null");
    }
}
