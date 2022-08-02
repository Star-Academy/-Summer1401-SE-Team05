namespace SampleLibrary;

public interface IInvertedIndex
{
    public Dictionary<string, List<string>> WordToDocumentMap { get; }

    public void makeWordToDocumentMap(string[] words, string fileName);

    public void showFiles(Dictionary<string, string> fileNameToContent);

    public string[] wordSplitter(Dictionary<string, List<string>>.KeyCollection file);
    

}