namespace SampleLibrary;

public class DocumentChecker
{
    public List<string> getDocumentsWithPlusWords(WordContainer wordContainer)
    {
        return null;
    }

    public List<string> getDocumentsWithMinusWords(WordContainer wordContainer) 
    {
        return default;
    }

    public bool doesNotContainAllNormalWords(string documentName, WordContainer wordContainer) {
        return default;
    }

    public bool documentContainsWord(string word, string documentName)
    {
        return default;
    }

    public bool checkIfContainsPlusWords(List<string> plusWords, string documentName) {

        return default;

    }


    public bool containsAtLeastOneMinusWord(List<string> minusWords, string documentName)
    {

        return default;

    }


    public bool doesNotContainAtLeastOnePlusWord(string documentName, WordContainer wordContainer)
    {
        return default;
    }
    public List<string> remove(List<string> documentNames, WordContainer wordContainer) 
    {
        return default;
    }

    //a valid document is a document that contains all normal words, at least on plus word and no minus words
    public List<string> getValidDocuments(WordContainer wordContainer, CheckersAndOperators checkerOperator) {
        
        return default;
    }
}
