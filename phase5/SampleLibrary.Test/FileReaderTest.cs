using FluentAssertions;

namespace SampleLibrary.Test;

public class FileReaderTest
{

    public string path =
        "C:\\Users\\gamer\\OneDrive\\Desktop\\phase 5\\Summer1401-SE-Team05\\phase5\\SampleLibrary.Test\\testResources";
    
    [Theory]
    [InlineData("for the sake of testing this program we will be using four test texts meant to test the different types of searching we are supposed to have")]
    public void GetFileContentTest(string expected)
    {
        //Arrange
        var fileReader = new FileReader();
        
        //Act
        var result = fileReader.getFileContent(path + "\\TestText1.txt");

        //Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ReadFilesTest()
    {
        //Arrange

        var fileName1 = (path + "\\TestText1.txt");
        string text1 = File.ReadAllText(fileName1).ToUpper();

        string fileName2 = (path + "\\TestText2.txt"); 
        string text2 = File.ReadAllText(fileName2).ToUpper();
        
        string fileName3 = (path + "\\TestText3.txt"); 
        string text3 = File.ReadAllText(fileName3).ToUpper();
        
        string fileName4 = (path + "\\TestText4.txt"); 
        string text4 = File.ReadAllText(fileName4).ToUpper();
        
        var expected = new Dictionary<string, string>
        {
            {"TestText1.txt", text1},
            {"TestText2.txt", text2},
            {"TestText3.txt", text3},
            {"TestText4.txt", text4},
        };
        var fileReader = new FileReader();
        
        //Act
        var result = fileReader.ReadFiles();

        //Assert
        result.Should().Equal(expected);
    }

    [Fact]
    public void GetFileNamesTest()
    {
        //Arrange
        var expected = new List<string>{"TestText1.txt", "TestText2.txt", "TestText3.txt", "TestText4.txt"};
        var fileReader = new FileReader();
        //Act
        var temp = fileReader.ReadFiles();
        // temp is just for calling ReadFiles function
        var result = fileReader.GetFileNames();
        //Assert
        result.Should().Equal(expected);
    }
}