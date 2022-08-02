using FluentAssertions;
using NSubstitute;

namespace SampleLibrary.Test;

public class DocumentCheckerTest
{
    private readonly Dictionary<string, List<string>> _testIndex;
    
    
    public DocumentCheckerTest()
    {
        _testIndex = new Dictionary<string, List<string>>
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
    
    public static IEnumerable<object[]> NormalWordTestData(){
        yield return new object[] { new List<string>{ "first", "second", "third" }, new List<string>{ "1" }};
        yield return new object[] { new List<string>{ "first", "third" }, new List<string>{ "1", "2" }};
        yield return new object[] { new List<string>{"here", "there"}, new List<string>()};
        yield return new object[] { new List<string>(), new List<string>()};

    }
    
    
    [Theory]
    [InlineData("second", "1", true)]
    [InlineData("hi", "4", false)]
    [InlineData("third", "3", true)]
    public void DocumentContainsWordTest(string word, string documentName, bool expected)
    {
        //arrange
        DocumentChecker documentChecker = new();
        var invertedIndex = Substitute.For<IInvertedIndex>();
        invertedIndex.WordToDocumentMap.Returns(_testIndex);

        //act
        var result = documentChecker.DocumentContainsWord(word, documentName, invertedIndex);

        //assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Data))]
    public void GetDocumentsWithAtLeastOneWordTest(List<string> words, List<string> expected)
    {
        //arrange
        DocumentChecker documentChecker = new();
        var invertedIndex = Substitute.For<IInvertedIndex>();
        invertedIndex.WordToDocumentMap.Returns(_testIndex);
        
        //act
        var result = documentChecker.GetDocumentsWithAtLeastOneWord(words, invertedIndex);

        //assert
        result.Should().BeEquivalentTo(expected);
    }

    
    
    [Theory]
    [MemberData(nameof(NormalWordTestData))]
    public void GetDocumentsWithAllWordsTest(List<string> words, List<string> expected)
    {
        //arrange
        DocumentChecker documentChecker = new();
        var invertedIndex = Substitute.For<IInvertedIndex>();
        invertedIndex.WordToDocumentMap.Returns(_testIndex);
        
        //act
        var result = documentChecker.GetDocumentsWithAllWords(words, invertedIndex);

        //assert
        result.Should().BeEquivalentTo(expected);
    }

}