using SampleLibrary;

namespace ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        var readerWriter = new ReaderWriter();
        var invertedIndex = new InvertedIndex();
        var documentChecker = new DocumentChecker(invertedIndex);
        new ConsoleController(readerWriter, invertedIndex, documentChecker).Run();
    }
}