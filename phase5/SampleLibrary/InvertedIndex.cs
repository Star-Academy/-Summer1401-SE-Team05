namespace SampleLibrary;

public class InvertedIndex
{
    public static InvertedIndex getInstance()
    {
        return default;
    }
    public Dictionary<String, List<String>> WordToDocumentMap { get; set; } = new ();

    public String[] wordSplitter(Dictionary<String, List<String>>.KeyCollection file)
    {
        return default;
    }

    public void makeWordToDocumentMap(String[] words, String fileName) {
        
    }
    public void showFiles(Dictionary<String, String> fileNameToContent) {
        
    }
}