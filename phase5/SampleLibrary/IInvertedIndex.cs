namespace SampleLibrary;

public interface IInvertedIndex
{
    public Dictionary<string, List<string>> WordToDocumentMap { get; }

    public void makeWordToDocumentMap(string[] words, string fileName);

    public void createIndex(Dictionary<string, string> fileNameToContent);

    

}