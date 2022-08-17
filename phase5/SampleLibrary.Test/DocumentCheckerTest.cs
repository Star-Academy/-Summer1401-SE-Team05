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
            {"all", new List<string>{"1", "2", "3", "4"}}
        };
    }
    
    private static IEnumerable<object[]> DataForValidDocumentFetching(){
        yield return new object[] { new List<string>{ "third", "first" }, new List<string>{ "second", "here" },
                                    new List<string>(), new List<string> {"1"}};
        yield return new object[] { new List<string>{ "all" }, new List<string>(),
                                    new List<string>{"here", "first"}, new List<string>{"4"}};
        yield return new object[] { new List<string>{ "all" }, new List<string>{ "second", "fourth", "hi" },
                                    new List<string>{"here"}, new List<string>{"1", "2"}};
    }

    
    private static IEnumerable<object[]> DataForGettingDocumentsWithAtLeastOneWord(){
        yield return new object[] { new List<string>{ "second" }, new List<string>{ "1" }};
        yield return new object[] { new List<string>{ "there", "hi" }, new List<string>{ "3", "4" }};
        yield return new object[] { new List<string>{ "third", "there" }, new List<string>{ "1", "2", "3", "4" }};
        yield return new object[] { new List<string>(), new List<string>()};
    }
    
    private static IEnumerable<object[]> NormalWordTestData(){
        yield return new object[] { new List<string>{ "first", "second", "third" }, new List<string>{ "1" }};
        yield return new object[] { new List<string>{ "first", "third" }, new List<string>{ "1", "2" }};
        yield return new object[] { new List<string>{"here", "there"}, new List<string>()};
        yield return new object[] { new List<string>(), new List<string>()};

    }

    
    
    [Theory]
    [InlineData("second", "1", true)]
    [InlineData("hi", "4", false)]
    [InlineData("third", "3", true)]
    private void DocumentChecker_CheckDocumentContainsWord(string word, string documentName, bool expected)
    {
        //arrange
        var invertedIndex = Substitute.For<IInvertedIndex>();
        invertedIndex.WordToDocumentMap.Returns(_testIndex);
        DocumentChecker documentChecker = new(invertedIndex);

        //act
        var result = documentChecker.DocumentContainsWord(word, documentName);

        //assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(DataForGettingDocumentsWithAtLeastOneWord))]
    private void DocumentChecker_GetDocumentsWithAtLeastOneWord(List<string> words, List<string> expected)
    {
        //arrange
        var invertedIndex = Substitute.For<IInvertedIndex>();
        invertedIndex.WordToDocumentMap.Returns(_testIndex);
        var documentChecker = new DocumentChecker(invertedIndex);
        
        //act
        var result = documentChecker.GetDocumentsWithAtLeastOneWord(words);

        //assert
        result.Should().BeEquivalentTo(expected);
    }

    
    
    [Theory]
    [MemberData(nameof(NormalWordTestData))]
    private void DocumentChecker_GetDocumentsWithAllWords(List<string> words, List<string> expected)
    {
        //arrange
        var invertedIndex = Substitute.For<IInvertedIndex>();
        invertedIndex.WordToDocumentMap.Returns(_testIndex);
        DocumentChecker documentChecker = new(invertedIndex);

        //act
        var result = documentChecker.GetDocumentsWithAllWords(words);

        //assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    private void GetValidDocumentsTest_noNormalWords()
    {
        //arrange
        var container = new WordContainer(new List<string>(),
            new List<string> {"here", "there"},
            new List<string>{"hi"});
        var invertedIndex = Substitute.For<IInvertedIndex>();
        invertedIndex.WordToDocumentMap.Returns(_testIndex);
        DocumentChecker documentChecker = new(invertedIndex);

        //act
        var result = documentChecker.GetValidDocuments(container);
        
        //assert
        result.Should().BeEquivalentTo(new List<string>());
    }
    
    
    [Theory]
    [MemberData(nameof(DataForValidDocumentFetching))]
    private void GetValidDocumentsTest_AllTypesOfWords(List<string> normal, List<string> plus ,List<string> minus ,List<string> expected)
    {
        //arrange
        var container = new WordContainer(normal, plus, minus);
        var invertedIndex = Substitute.For<IInvertedIndex>();
        invertedIndex.WordToDocumentMap.Returns(_testIndex);
        DocumentChecker documentChecker = new(invertedIndex);

        //act
        var result = documentChecker.GetValidDocuments(container);
        
        //assert
        result.Should().BeEquivalentTo(expected);
    }
    
}