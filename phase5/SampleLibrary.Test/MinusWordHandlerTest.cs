using FluentAssertions;

namespace SampleLibrary.Test;

public class MinusWordHandlerTest
{
    private readonly List<string> _allWords = new(new [] {"+this", "-is", "+a", "test", "string", "-for", "+word", "bank"});
    private readonly List<string> _allWordsMinus = new(new [] {"is", "for"});
    private readonly List<string> _allWordsNotMinus = new(new [] {"+this", "+a", "test", "string", "+word", "bank"});

    private readonly List<string> _regWords = new(new [] {"this", "is", "a", "test", "string", "for", "word", "bank"});

    
    [Fact]
    public void MinusWordHandlerTest_ContainsMinusWord()
    {
        //arrange
        var handler = new MinusWordSeparator();
        
        //act
        var result = handler.Separate(_allWords);
        
        //assert
        handler.Words.Should().Equal(_allWordsMinus);
        result.Should().Equal(_allWordsNotMinus);

    }
    
    [Fact]
    public void MinusWordHandlerTest_NoMinusWordsInList()
    {
        //arrange
        var handler = new MinusWordSeparator();

        //act
        var result = handler.Separate(_regWords);
        
        //assert
        handler.Words.Should().BeEmpty();
        result.Should().Equal(_regWords);

    }


}