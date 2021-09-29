using Hangman;
using System;
using Xunit;

namespace hangman_tests
{
    public class WordRepositoryTests
    {
        private WordRepository wordRepository;
        public WordRepositoryTests()
        {
            wordRepository = new WordRepository();
        }

        [Fact]
        public void GetAllTest()
        {
            String[] expectedWords = new string[]
            {
                "båt",
                "ödla",
                "bäver",
                "bensin",
                "apelsin",
                "bokhylla"
            };

            String[] words = wordRepository.GetAll();

            Assert.Equal(expectedWords, words);
        }
    }
}
