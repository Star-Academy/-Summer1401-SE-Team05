using FluentAssertions;

namespace SampleLibrary.Test;

public class MinusWordHandlerTest
{
    public readonly List<string> AllWords = new(new [] {"+this", "-is", "+a", "test", "string", "-for", "+word", "bank"});
    public readonly List<string> AllWordsMinus = new(new [] {"is", "for"});
    public readonly List<string> AllWordsNotMinus = new(new [] {"+this", "+a", "test", "string", "+word", "bank"});

    public readonly List<string> RegWords = new(new [] {"this", "is", "a", "test", "string", "for", "word", "bank"});

    
    [Fact]
    public void MinusWordHandlerTest_ContainsMinusWord()
    {
        //arrange
        var handler = new MinusWordHandler();
        
        //act
        var result = handler.Separate(AllWords);
        
        //assert
        handler.Words.Should().Equal(AllWordsMinus);
        result.Should().Equal(AllWordsNotMinus);

    }
    
    [Fact]
    public void MinusWordHandlerTest_NoMinusWordsInList()
    {
        //arrange
        var handler = new MinusWordHandler();

        //act
        var result = handler.Separate(RegWords);
        
        //assert
        handler.Words.Should().BeEmpty();
        result.Should().Equal(RegWords);

    }


}