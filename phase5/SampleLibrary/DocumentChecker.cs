namespace SampleLibrary;

public class DocumentChecker
{
    public List<string> GetDocumentsWithPlusWords(WordContainer wordContainer, InvertedIndex invertedIndex)
    {
        
        
        return default;
    }

    public List<string> GetDocumentsWithMinusWords(WordContainer wordContainer, InvertedIndex invertedIndex) 
    {
        return default;
    }

    public bool DoesNotContainAllNormalWords(string documentName, WordContainer wordContainer, InvertedIndex invertedIndex) {
        return default;
    }

    public bool DocumentContainsWord(string word, string documentName, InvertedIndex invertedIndex)
    {
        return default;
    }

    public bool checkIfContainsPlusWords(List<string> plusWords, string documentName, InvertedIndex invertedIndex) {

        return default;

    }


    public bool GetDocumentsThatContainAtLeastOneWord(List<string> words, string documentName, InvertedIndex invertedIndex)
    {

        return default;

    }


    public List<string> remove(List<string> documentNames, WordContainer wordContainer) 
    {
        return default;
    }

    //a valid document is a document that contains all normal words, at least on plus word and no minus words
    public List<string> getValidDocuments(WordContainer wordContainer, CheckersAndOperators checkerOperator, InvertedIndex invertedIndex) {
        
        return default;
    }
}
