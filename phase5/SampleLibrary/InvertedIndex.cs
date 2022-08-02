namespace SampleLibrary;

public class InvertedIndex : IInvertedIndex
{

    public Dictionary<string, List<string>> WordToDocumentMap { get; } = new ();

    public void makeWordToDocumentMap(string[] words, string fileName) 
    {
        foreach(string word in words) 
        {
            if (WordToDocumentMap.ContainsKey(word)) 
            {
                WordToDocumentMap[word].Add(fileName);
            } else 
            {
                List<string> documentList = new ();
                documentList.Add(fileName);
                WordToDocumentMap[word] = documentList;
            }
        }
    }
    public void showFiles(Dictionary<string, string> fileNameToContent)
    {
        foreach (var keyValuePair in fileNameToContent)
        {
            string fileName = keyValuePair.Key;
            string[] words = keyValuePair.Value.Split();
            makeWordToDocumentMap(words, fileName);
        }
    }

}