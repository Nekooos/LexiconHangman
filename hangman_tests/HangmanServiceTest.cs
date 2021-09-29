using Hangman;
using System;
using System.IO;
using Xunit;

namespace hangmanServiceTest
{
    public class hangmanServiceTest
    {
        private HangmanService hangmanService;

        public hangmanServiceTest()
        {
            hangmanService = new HangmanService();
        }

        [Fact]
        public void FillArrayWithUnderscoreTest()
        {
            char[] testArray = new char[5];
            char[] expectedArray = new char[] { '_', '_', '_', '_', '_' };

            testArray = hangmanService.fillArrayWithUnderscore(testArray);
            
            Assert.Equal(expectedArray, testArray);
        }

        [Fact]
        public void InsertGuessInArrayTest()
        {
            char[] testArray = new char[] { '_', '_', '_', '_', '_', '_' };
            char[] expectedArray = new char[] { '_', '_', 'n', '_', '_', 'n' };

            testArray = hangmanService.insertGuessInArray(testArray, "n", "bensin");

            Assert.Equal(testArray, expectedArray);
        }

        [Fact]
        public void RandomizeWordTest()
        {
            WordRepository wordRepository = new WordRepository();
            String[] expetcedWords = wordRepository.GetAll();

            String testWord = hangmanService.randomizeWord();

            Assert.True(Array.Exists(expetcedWords, expected => testWord.Equals(expected)));
        }

        [Fact]
        public void ValidGuessReturnsTrueTest()
        {
            String guess = "test";
            String answer = "test";

            bool isEqual = hangmanService.CheckCorrectGuess(guess, answer);

            Assert.True(isEqual);
        }

        [Fact]
        public void ValidGuessReturnsFalseTest()
        {
            String guess = "test";
            String answer = "notSame";

            bool isEqual = hangmanService.CheckCorrectGuess(guess, answer);

            Assert.False(isEqual);
        }

        [Fact]
        public void ValidInputNumberStringTest()
        {
            var input = String.Join(Environment.NewLine, new[]
            {
                "5",
                "b",
            });

            Console.SetIn(new StringReader(input));

            String expectedWord = "b";
            String word = hangmanService.ValidGuess();

            Assert.Equal(expectedWord, word);
        }

        [Fact]
        public void ValidInputTest()
        {
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            StringReader input = new StringReader("b");
            Console.SetIn(input);

            String testGuess = hangmanService.ValidGuess();
            String expectedGuess = "b";

            String expectedOutput = "Enter a guess from a-ö or the word\r\n";

            Assert.Equal(output.ToString(),expectedOutput);
            Assert.Equal(expectedGuess, testGuess);
        }
    }
}
