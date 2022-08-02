namespace SampleLibrary;

public class DocumentChecker
{
    
    public List<string> GetDocumentsWithAllWords(List<string> words, IInvertedIndex invertedIndex)
    {
        if (words.Count == 0)
        {
            return new List<string>();
        }
        
        var documents = invertedIndex.WordToDocumentMap[words[0]];
        foreach (var word in words)
        {
            documents = documents.Where(x => invertedIndex.WordToDocumentMap[word].Contains(x)).ToList();
        }
        return documents;
    }

    public bool DocumentContainsWord(string word, string documentName, IInvertedIndex invertedIndex)
    {
        return invertedIndex.WordToDocumentMap[word].Contains(documentName);
    }
    
    public List<string> GetDocumentsWithAtLeastOneWord(List<string> words, IInvertedIndex invertedIndex)
    {
        return words.SelectMany(x => invertedIndex.WordToDocumentMap[x]).Distinct().ToList();
    }


    public List<string> remove(List<string> documentNames, WordContainer wordContainer) 
    {
        return default;
    }

    //a valid document is a document that contains all normal words, at least on plus word and no minus words
    public List<string> getValidDocuments(WordContainer wordContainer, CheckersAndOperators checkerOperator, IInvertedIndex invertedIndex) {
        
        return default;
    }
}
