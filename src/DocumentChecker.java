import java.util.ArrayList;
import java.util.Collections;

public class DocumentChecker {
    private static DocumentChecker single_instance;
    public static DocumentChecker getInstance()
    {
        if (single_instance == null)
            single_instance = new DocumentChecker();

        return single_instance;
    }

    public ArrayList<String> getDocumentsWithPlusWords() {
        ArrayList<String> documentsWithPlusWords = new ArrayList<>();
        for (String word : WordContainer.getInstance().plusWords)
            documentsWithPlusWords.addAll(InvertedIndex.getInstance().wordToDocumentMap.get(word));
        return documentsWithPlusWords;
    }

    public ArrayList<String> getDocumentsWithMinusWords() {
        ArrayList<String> documentsWithMinusWords = new ArrayList<>();
        for (String word : WordContainer.getInstance().minusWords) {
            documentsWithMinusWords.addAll(InvertedIndex.getInstance().wordToDocumentMap.get(word));
        }
        return documentsWithMinusWords;
    }

    public boolean checkNormalWords(String documentName) {
        for (String normalWord : WordContainer.getInstance().normalWords) {
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


    public boolean checkMinusWords(ArrayList<String> minusWords, String documentName) {

        return minusWords.contains(documentName);

    }


    public boolean checkPlusWords(String documentName) {
        return (!getDocumentsWithPlusWords().isEmpty() &&
                checkIfContainsPlusWords(getDocumentsWithPlusWords(), documentName));
    }
    public ArrayList<String> remove(ArrayList<String> documentNames) {

        documentNames.removeIf(documentName ->
                checkNormalWords(documentName) ||
                checkPlusWords(documentName) ||
                checkMinusWords(getDocumentsWithMinusWords(), documentName));

        return documentNames;
    }

    public ArrayList<String> check() {
        ArrayList<String> documentNames = FileReader.getInstance().getFileNames();

        ArrayList<String> checkedDocuments = remove(documentNames);
        Collections.sort(checkedDocuments);
        return checkedDocuments;
    }
}
