namespace SampleLibrary.Test;
using FluentAssertions;
public class PlusWordHandlerTest
{
    
    public readonly List<string> AllWords = new(new [] {"+this", "-is", "+a", "test", "string", "-for", "+word", "bank"});
    public readonly List<string> AllWordsPlus = new(new [] {"this", "a", "word"});
    public readonly List<string> AllWordsNotPlus = new(new [] {"-is", "test", "string", "-for" ,"bank"});
    
    public readonly List<string> RegWords = new(new [] {"this", "is", "a", "test", "string", "for", "word", "bank"});
    

    
    
    [Fact]
    public void PlusWordHandlerTest_ContainsPlusWord()
    {
        //arrange
        var handler = new PlusWordSeparator();
        
        //act
        var result = handler.Separate(AllWords);
        
        //assert
        handler.Words.Should().Equal(AllWordsPlus);
        result.Should().Equal(AllWordsNotPlus);

    }
    
    [Fact]
    public void PlusWordHandlerTest_noPlusWordsInList()
    {
        //arrange
        var handler = new PlusWordSeparator();

        //act
        var result = handler.Separate(RegWords);
        
        //assert
        handler.Words.Should().BeEmpty();
        result.Should().Equal(RegWords);

    }
    
}