using System.Reflection;
using FluentAssertions;

namespace SampleLibrary.Test;


public class FileReaderTest
{

    private readonly string _path = Directory.GetCurrentDirectory();

    
    private string generateRandomString()
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, random.Next(1000))
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    
    private void CreateFileWithContent(string path, string content)
    {
        using (var writer = File.CreateText(path))
        {
            writer.Write(content);
        }
    }
    
    [Fact]
    public void ReadFilesTest()
    {
        //Arrange

        var fileName1 = Path.Combine(_path, "TestText1.txt");
        var content1 = generateRandomString();
        CreateFileWithContent(fileName1, content1);

        var fileName2 = Path.Combine(_path, "TestText2.txt");
        var content2 = generateRandomString();
        CreateFileWithContent(fileName2, content2);

        var expected = new Dictionary<string, string>
        {
            {"TestText1.txt", content1},
            {"TestText2.txt", content2},
        };
        var fileReader = new FileReader(_path);
        
        //Act
        var result = fileReader.ReadFiles();

        //Assert
        result.Should().BeEquivalentTo(expected);
        File.Delete(fileName1);
        File.Delete(fileName2);
    }

    [Fact]
    public void GetFileNamesTest()
    {
        //Arrange
        var expected = new List<string>{"TestText1.txt", "TestText2.txt"};
        var fileReader = new FileReader(_path);
        
        var fileName1 = Path.Combine(_path, "TestText1.txt");
        var content1 = generateRandomString();
        CreateFileWithContent(fileName1, content1);

        var fileName2 = Path.Combine(_path, "TestText2.txt");
        var content2 = generateRandomString();
        CreateFileWithContent(fileName2, content2);

        //Act
        fileReader.ReadFiles();
        // temp is just for calling ReadFiles function
        var result = fileReader.GetFileNames();
        
        //Assert
        result.Should().BeEquivalentTo(expected);
        File.Delete(fileName1);
        File.Delete(fileName2);
    }
}