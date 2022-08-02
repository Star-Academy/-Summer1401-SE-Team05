using FluentAssertions;
using NSubstitute;

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
    
    public static IEnumerable<object[]> PlusWordData(){
        yield return new object[] { null, new List<int>{ 42, 2112 }, null };
        yield return new object[] { 1, new List<int>{ 43, 2112 }, null };
        yield return new object[] { null, new List<int>{ 44, 2112 }, 6 };
    }


    public static IEnumerable<object[]> Data(){
        yield return new object[] { null, new List<int>{ 42, 2112 }, null };
        yield return new object[] { 1, new List<int>{ 43, 2112 }, null };
        yield return new object[] { null, new List<int>{ 44, 2112 }, 6 };
    }
    [Theory]
    [MemberData(nameof(PlusWordData))]
    public void GetDocumentsWithAtLeastOneWordTest()
    {
        
    }

    [Theory]
    [MemberData(nameof(PlusWordData))]
    public void GetDocumentWithPlusWordTest()
    {
        //arrange
        DocumentChecker documentChecker = new();
        var container = Substitute.For<WordContainer>();
        container.PlusWords.Returns(new List<string>{"anime", "white"});
        var invertedIndex = Substitute.For<InvertedIndex>();
        invertedIndex.wordToDocumentMap.Returns(testIndex);
        
        //act
        
        
        //assert

    }
    
}