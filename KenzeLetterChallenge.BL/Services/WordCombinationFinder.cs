using System.Diagnostics;
using KenzeLetterChallenge.BL.Interfaces;

namespace KenzeLetterChallenge.BL.Services
{
    public class WordCombinationFinder
    {
        private readonly IWordRepository _wordRepository;

        public WordCombinationFinder(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public List<Combination> FindSixLetterCombinations(int combinationLength = 6) // lengte van combinaties kan hier aangepast worden; changing requirements 
        {
            Console.WriteLine("working...");

            var stopwatch = Stopwatch.StartNew();

            Task.Run(() =>
            {
                while (true)
                {
                    if (stopwatch.ElapsedMilliseconds > 10000)
                    {
                        Console.WriteLine("RAM gaat brrrrrrrrrrrrr");
                        break;
                    }

                    Task.Delay(100).Wait();
                }
            });

            var wordSet = _wordRepository.GetWords();
            var targetLengthWords = wordSet.Where(word => word.Text.Length == combinationLength).ToHashSet();
            var combinations = new List<Combination>();

            foreach (var word in wordSet)
            {
                foreach (var otherWord in wordSet)
                {
                    if (word == otherWord) continue;

                    var combinedText = word.Text + otherWord.Text;
                    if (combinedText.Length == combinationLength && targetLengthWords.Any(w => w.Text == combinedText))
                    {
                        var resultWord = targetLengthWords.First(w => w.Text == combinedText);
                        combinations.Add(new Combination(word, otherWord, resultWord));
                    }
                }
            }

            return combinations;
        }
    }
}