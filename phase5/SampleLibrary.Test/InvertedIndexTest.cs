using FluentAssertions;

namespace SampleLibrary.Test;

public class InvertedIndexTest
{
    [Fact]
    public void MakeWordToDocumentMap_MapMadeCorrectly()
    {
        //Arrange
        var invertedIndex = new InvertedIndex();
        Dictionary<string, List<string>> expected = new()
            {
                {"1", new List<string> {"first"}},
                {"2", new List<string> {"first"}}
            };
     
        //Act
        string[] str = {"1", "2"};
        invertedIndex.makeWordToDocumentMap(str, "first");
        
        //Assert
        invertedIndex.WordToDocumentMap.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void CreateIndex_IndexMadeCorrectly()
    {
        //Arrange
        var invertedIndex = new InvertedIndex();
        Dictionary<string, string> mockedDictionary = new()
        {
            {"first", "1 2"},
            {"second", "1 2"}
        };
        Dictionary<string, List<string>> expected = new()
        {
            {"1", new List<string> {"first", "second"}},
            {"2", new List<string> {"first", "second"}}
        };
        //Act
        invertedIndex.createIndex(mockedDictionary);
        //Assert
        invertedIndex.WordToDocumentMap.Should().BeEquivalentTo(expected);
    }
}