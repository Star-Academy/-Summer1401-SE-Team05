import java.util.ArrayList;
import java.util.Collections;

public class DocumentChecker {

    public static ArrayList<String> getDocumentsWithPlusWords(WordContainer wordContainer) {
        ArrayList<String> documentsWithPlusWords = new ArrayList<>();
        for (String word : wordContainer.plusWords)
            documentsWithPlusWords.addAll(InvertedIndex.wordToDocumentMap.get(word));
        return documentsWithPlusWords;
    }

    public static ArrayList<String> getDocumentsWithMinusWords(WordContainer wordContainer) {
        ArrayList<String> documentsWithMinusWords = new ArrayList<>();
        for (String word : wordContainer.minusWords)
            documentsWithMinusWords.addAll(InvertedIndex.wordToDocumentMap.get(word));
        return documentsWithMinusWords;
    }

    public static boolean checkNormalWords(ArrayList<String> normalWords, String documentName) {
        for (String normalWord : normalWords) {
            if (!InvertedIndex.wordToDocumentMap.get(normalWord).contains(documentName)) {
                return true;
            }

        }
        return false;
    }

    public static boolean checkPlusWords(ArrayList<String> plusWords, String documentName) {

        return !plusWords.contains(documentName);

    }


    public static boolean checkMinusWords(ArrayList<String> minusWords, String documentName) {

        return minusWords.contains(documentName);

    }

    public static ArrayList<String> remove(WordContainer wordContainer, ArrayList<String> documentNames) {


        documentNames.removeIf(documentName -> checkNormalWords(wordContainer.normalWords, documentName) ||
                (!getDocumentsWithPlusWords(wordContainer).isEmpty() &&
                        checkPlusWords(getDocumentsWithPlusWords(wordContainer), documentName)) ||
                checkMinusWords(getDocumentsWithMinusWords(wordContainer), documentName));

        return documentNames;
    }

    public static ArrayList<String> check(WordContainer wordContainer) {
        ArrayList<String> documentNames = FileReader.getFileNames();

        ArrayList<String> checkedDocuments = remove(wordContainer, documentNames);
        Collections.sort(checkedDocuments);
        return checkedDocuments;
    }
}