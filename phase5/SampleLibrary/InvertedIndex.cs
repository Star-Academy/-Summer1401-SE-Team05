namespace SampleLibrary;

public class InvertedIndex : IInvertedIndex
{

    public Dictionary<string, List<string>> WordToDocumentMap { get; } = new ();
    public static InvertedIndex getInstance()
    {
        return default;
    }
    
    public string[] wordSplitter(Dictionary<string, List<string>>.KeyCollection file)
    {
        return default;
    }

    public void makeWordToDocumentMap(string[] words, string fileName) 
    {
        
    }
    public void showFiles(Dictionary<string, string> fileNameToContent) 
    {
        
    }

}