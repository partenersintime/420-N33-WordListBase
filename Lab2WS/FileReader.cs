using System;
using System.IO;
using System.Text;

namespace Lab2WS
{
    class FileReader
    {
        // Implemented Read Method - Justin. M
        public string[] Read(string filename)
        {
            // Implement this using info from the slides.
            var path = filename;
            try
            {
                String[] words = File.ReadAllLines(path);
                return words;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error! " + e.Message);
            }
            return null;
        }
    }
}

        

