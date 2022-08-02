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


    //a valid document is a document that contains all normal words, at least on plus word and no minus words
    public List<string> GetValidDocuments(WordContainer wordContainer, IInvertedIndex invertedIndex)
    {
        var documentsWithAtLeastOneMinusWord = GetDocumentsWithAtLeastOneWord(wordContainer.MinusWords, invertedIndex);
        var haveMinusWords = documentsWithAtLeastOneMinusWord.Count != 0;
        var documentsWithAtLeastOnePlusWord =
            GetDocumentsWithAtLeastOneWord(wordContainer.PlusWords, invertedIndex);
        var havePlusWords = documentsWithAtLeastOnePlusWord.Count != 0;
        
        return GetDocumentsWithAllWords(wordContainer.NormalWords, invertedIndex)
            .Where(x => !havePlusWords || documentsWithAtLeastOnePlusWord.Contains(x))
            .Where(x => !haveMinusWords || !documentsWithAtLeastOneMinusWord.Contains(x)).ToList();
    }
}
