using System;
using System.IO;

namespace Hangman
{
    public class WordRepository
    {

        private String path = @"c:\temp\words.txt";

        private String[] words = new string[] 
        {
            "båt",
            "ödla",
            "bäver",
            "bensin",
            "apelsin",
            "bokhylla"
        };

        public String[] GetAll()
        {
            if (!File.Exists(path))
            {
                CreateIfnotExists();
            }
            return File.ReadAllLines(path);
        }

        private void CreateIfnotExists()
        {
            using (StreamWriter streamWriter = File.CreateText(path))
            {
                foreach (String word in words)
                {
                    streamWriter.WriteLine(word);
                }
            }
        }

        public void deleteTextFile()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
