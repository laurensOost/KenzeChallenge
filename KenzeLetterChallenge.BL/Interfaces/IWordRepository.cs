using KenzeLetterChallenge.BL.Models;

namespace KenzeLetterChallenge.BL.Interfaces
{
    public interface IWordRepository
    {
        HashSet<Word> GetWords();
    }
}
