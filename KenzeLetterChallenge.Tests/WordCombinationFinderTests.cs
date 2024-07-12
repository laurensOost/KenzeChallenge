using KenzeLetterChallenge.BL.Interfaces;
using KenzeLetterChallenge.BL.Models;
using KenzeLetterChallenge.BL.Services;

public class WordCombinationFinderTests
{
    [Fact]
    public void FindSixLetterCombinations_ShouldReturnValidCombinations()
    {
        // Arrange
        var mockRepo = new Mock<IWordRepository>();
        mockRepo.Setup(repo => repo.GetWords()).Returns(new HashSet<Word>
        {
            new Word("foobar"),
            new Word("fo"),
            new Word("obar"),
            new Word("hello"),
            new Word("world"),
            new Word("hell"),
            new Word("oworld"),
            new Word("o")
        });
    
        var finder = new WordCombinationFinder(mockRepo.Object);
    
        // Act
        var combinations = finder.FindSixLetterCombinations();
    
        // Assert
        Assert.Contains(combinations, c => c.ToString() == "fo+obar=foobar");
        Assert.Contains(combinations, c => c.ToString() == "o+world=oworld");
        Assert.DoesNotContain(combinations, c => c.ToString() == "hell+o=hello"); // vijf letters checken
    }

    [Fact]
    public void FindSixLetterCombinations_ShouldHandleNoCombinations()
    {
        // Arrange
        var mockRepo = new Mock<IWordRepository>();
        mockRepo.Setup(repo => repo.GetWords()).Returns(new HashSet<Word>
        {
            new Word("foobar"),
            new Word("hello"),
            new Word("world")
        });

        var finder = new WordCombinationFinder(mockRepo.Object);

        // Act
        var combinations = finder.FindSixLetterCombinations();

        // Assert
        Assert.Empty(combinations);
    }

    [Fact]
    public void FindSixLetterCombinations_ShouldReturnEmptyForEmptyInput()
    {
        // Arrange
        var mockRepo = new Mock<IWordRepository>();
        mockRepo.Setup(repo => repo.GetWords()).Returns(new HashSet<Word>());

        var finder = new WordCombinationFinder(mockRepo.Object);

        // Act
        var combinations = finder.FindSixLetterCombinations();

        // Assert
        Assert.Empty(combinations);
    }

    [Fact]
    public void FindSixLetterCombinations_ShouldMatchSixLetterWordInInput()
    {
        // Arrange
        var mockRepo = new Mock<IWordRepository>();
        mockRepo.Setup(repo => repo.GetWords()).Returns(new HashSet<Word>
        {
            new Word("foobar"),
            new Word("fo"),
            new Word("obar"),
            new Word("hello"),
            new Word("world"),
            new Word("hell"),
            new Word("oworld"),
            new Word("o"),
            new Word("foobar"),
            new Word("oworld"),
            new Word("ooo"),
            new Word("ppp")
        });
    
        var finder = new WordCombinationFinder(mockRepo.Object);
    
        // Act
        var combinations = finder.FindSixLetterCombinations();
    
        // Assert
        Assert.Contains(combinations, c => c.ToString() == "fo+obar=foobar");
        Assert.Contains(combinations, c => c.ToString() == "o+world=oworld");
        Assert.DoesNotContain(combinations, c => c.ToString() == "ooo+ppp=oooppp"); // combo checken die niet in de lijst zit -- mag niet returnen 
    }
}
