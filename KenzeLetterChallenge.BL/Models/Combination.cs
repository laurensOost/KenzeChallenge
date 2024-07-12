using KenzeLetterChallenge.BL.Models;

public class Combination 
{
    public Word FirstWord { get; set; }
    public Word SecondWord { get; set; }
    public Word ResultWord { get; set; }

    public Combination(Word firstWord, Word secondWord, Word resultWord)
    {
        FirstWord = firstWord;
        SecondWord = secondWord;
        ResultWord = resultWord;
    }

    public override string ToString()
    {
        return $"{FirstWord.Text}+{SecondWord.Text}={ResultWord.Text}";
    }
}
