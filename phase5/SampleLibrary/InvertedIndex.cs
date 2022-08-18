namespace SampleLibrary;

public class InvertedIndex : IInvertedIndex
{

    public Dictionary<string, List<string>> WordToDocumentMap { get; } = new ();

    public void makeWordToDocumentMap(string[] words, string fileName) 
    {
        foreach(var word in words) 
        {
            if (WordToDocumentMap.ContainsKey(word)) 
            {
                WordToDocumentMap[word].Add(fileName);
            } else 
            {
                WordToDocumentMap[word] = new List<string> {fileName};
            }
        }
    }
    public void createIndex(Dictionary<string, string> fileNameToContent)
    {
        foreach (var keyValuePair in fileNameToContent)
        {
            var fileName = keyValuePair.Key;
            var words = keyValuePair.Value.Split();
            makeWordToDocumentMap(words, fileName);
        }
    }

}