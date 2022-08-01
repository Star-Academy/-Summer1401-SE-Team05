using FluentAssertions;

namespace SampleLibrary.Test;

public class FileReaderTest
{
    [Theory]
    [InlineData("for the sake of testing this program we will be using four test texts meant to test the different types of searching we are supposed to have")]
    public void getFileContentTest(string expected)
    {
        //Arrange
        var fileReader = new FileReader();
        string path =
            "C:\\Users\\gamer\\OneDrive\\Desktop\\phase 5\\Summer1401-SE-Team05\\phase5\\SampleLibrary.Test\\testResources\\TestText1.txt";
        
        //Act
        var result = fileReader.getFileContent(path);

        //Assert
        result.Should().Be(expected);
    }
}