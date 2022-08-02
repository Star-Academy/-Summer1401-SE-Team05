using FluentAssertions;
using NSubstitute;
using NSubstitute.Extensions;

namespace SampleLibrary.Test;

public class DocumentCheckerTest
{
    private readonly Dictionary<string, List<string>> testIndex;
    
    
    public DocumentCheckerTest()
    {
        testIndex = new Dictionary<string, List<string>>
        {
            {"first", new List<string> {"1", "2"}},
            {"second", new List<string> {"1"}},
            {"third", new List<string> {"1", "2", "3"}},
            {"fourth", new List<string> {"2"}},
            {"here", new List<string> {"3"}},
            {"there", new List<string> {"4"}},
            {"hi", new List<string> {"3"}},
        };
    }
    

    public static IEnumerable<object[]> Data(){
        yield return new object[] { new List<string>{ "second" }, new List<string>{ "1" }};
        yield return new object[] { new List<string>{ "there", "hi" }, new List<string>{ "3", "4" }};
        yield return new object[] { new List<string>{ "third", "there" }, new List<string>{ "1", "2", "3", "4" }};
        yield return new object[] { new List<string>(), new List<string>()};
    }
    
    [Theory]
    [MemberData(nameof(Data))]
    public void GetDocumentsWithAtLeastOneWordTest(List<string> words, List<string> expected)
    {
        //arrange
        DocumentChecker documentChecker = new();
        var invertedIndex = Substitute.For<InvertedIndex>();
        invertedIndex.WordToDocumentMap = Substitute.For<Dictionary<string, List<string>>>();
        invertedIndex.WordToDocumentMap.ReturnsForAnyArgs(testIndex);
        
        //act
        var result = documentChecker.GetDocumentsWithAtLeastOneWord(words, invertedIndex);

        //assert
        result.Should().Equal(expected);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void GetDocumentWithPlusWordTest()
    {
        //arrange
        DocumentChecker documentChecker = new();
        var container = Substitute.For<WordContainer>();
        container.PlusWords.Returns(new List<string>{"anime", "white"});
        var invertedIndex = Substitute.For<InvertedIndex>();
        invertedIndex.WordToDocumentMap.Returns(testIndex);
        
        //act
        
        
        //assert

    }
    
}