namespace SampleLibrary.Test;
using FluentAssertions;
public class PlusWordSeparatorTest
{
    
    private readonly List<string> _allWords = new(new [] {"+this", "-is", "+a", "test", "string", "-for", "+word", "bank"});
    private readonly List<string> _allWordsPlus = new(new [] {"this", "a", "word"});
    private readonly List<string> _allWordsNotPlus = new(new [] {"-is", "test", "string", "-for" ,"bank"});
    
    private readonly List<string> _regWords = new(new [] {"this", "is", "a", "test", "string", "for", "word", "bank"});
    

    
    
    [Fact]
    private void PlusWordHandlerTest_ContainsPlusWord()
    {
        //arrange
        var handler = new PlusWordSeparator();
        
        //act
        var result = handler.Separate(_allWords);
        
        //assert
        handler.Words.Should().Equal(_allWordsPlus);
        result.Should().Equal(_allWordsNotPlus);

    }
    
    [Fact]
    private void PlusWordHandlerTest_noPlusWordsInList()
    {
        //arrange
        var handler = new PlusWordSeparator();

        //act
        var result = handler.Separate(_regWords);
        
        //assert
        handler.Words.Should().BeEmpty();
        result.Should().Equal(_regWords);

    }
    
}