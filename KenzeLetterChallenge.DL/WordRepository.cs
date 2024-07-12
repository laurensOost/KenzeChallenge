using KenzeLetterChallenge.BL.Interfaces;
using KenzeLetterChallenge.BL.Models;

namespace KenzeLetterChallenge.BL.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly string _filePath;

        public WordRepository(string relativePath)
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
        }

        public HashSet<Word> GetWords()
        {
            var words = new HashSet<Word>();

            foreach (var line in File.ReadLines(_filePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    words.Add(new Word(line.Trim()));
                }
            }

            return words;
        }
    }
}