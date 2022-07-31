import java.util.ArrayList;
import java.util.Collections;

public class DocumentChecker {

    public ArrayList<String> getDocumentsWithPlusWords(WordContainer wordContainer) {
        ArrayList<String> documentsWithPlusWords = new ArrayList<>();
        for (String word : wordContainer.plusWords)
            documentsWithPlusWords.addAll(InvertedIndex.getInstance().wordToDocumentMap.get(word));
        return documentsWithPlusWords;
    }

    public ArrayList<String> getDocumentsWithMinusWords(WordContainer wordContainer) {
        ArrayList<String> documentsWithMinusWords = new ArrayList<>();
        for (String word : wordContainer.minusWords) {
            documentsWithMinusWords.addAll(InvertedIndex.getInstance().wordToDocumentMap.get(word));
        }
        return documentsWithMinusWords;
    }

    public boolean doesNotContainAllNormalWords(String documentName, WordContainer wordContainer) {
        for (String normalWord : wordContainer.normalWords) {
            if (!documentContainsWord(normalWord, documentName)) {
                return true;
            }

        }
        return false;
    }

    public boolean documentContainsWord(String word, String documentName){
        return InvertedIndex.getInstance().wordToDocumentMap.get(word).contains(documentName);
    }

    public boolean checkIfContainsPlusWords(ArrayList<String> plusWords, String documentName) {

        return !plusWords.contains(documentName);

    }


    public boolean containsAtLeastOneMinusWord(ArrayList<String> minusWords, String documentName) {

        return minusWords.contains(documentName);

    }


    public boolean doesNotContainAtLeastOnePlusWord(String documentName, WordContainer wordContainer) {
        return (!getDocumentsWithPlusWords(wordContainer).isEmpty() &&
                checkIfContainsPlusWords(getDocumentsWithPlusWords(wordContainer), documentName));
    }
    public ArrayList<String> remove(ArrayList<String> documentNames, WordContainer wordContainer) {

        documentNames.removeIf(documentName ->
                doesNotContainAllNormalWords(documentName, wordContainer) ||
                doesNotContainAtLeastOnePlusWord(documentName, wordContainer) ||
                containsAtLeastOneMinusWord(getDocumentsWithMinusWords(wordContainer), documentName));

        return documentNames;
    }

    //a valid document is a document that contains all normal words, at least on plus word and no minus words
    public ArrayList<String> getValidDocuments(WordContainer wordContainer, CheckersAndOperators checkerOperator) {
        ArrayList<String> documentNames = checkerOperator.fileReader.getFileNames();
        ArrayList<String> validDocuments = remove(documentNames, wordContainer);
        Collections.sort(validDocuments);
        return validDocuments;
    }
}
