import java.util.*;

public class Main {

    public static void init() {
        InvertedIndex.showFiles(FileReader.readFiles());
    }
    public static void endProgramWithNothing() {
        System.out.println("No documents were found!");
        System.exit(0);
    }
    public static void endIfSomeNormalWordHasNoAssociatedDocument(WordContainer wordContainer) {
        for (String normalWord : wordContainer.normalWords) {
            if (!InvertedIndex.wordToDocumentMap.containsKey(normalWord)){
                endProgramWithNothing();
            }
        }
    }

    public static void printFinalAnswer(ArrayList<String> checkedDocuments){

        if (checkedDocuments.isEmpty()){
            endProgramWithNothing();
        }

        for (String documentName : checkedDocuments) {
            System.out.println(documentName);
        }

    }

    public static void main(String[] args) {
        String words = Reader.getLine().toUpperCase();
        String[] wordsToFind = words.split("\\s");

        init();
        WordContainer wordContainer = WordOperator.operate(wordsToFind);
        endIfSomeNormalWordHasNoAssociatedDocument(wordContainer);
        ArrayList<String> checkedDocuments = DocumentChecker.check(wordContainer);
        printFinalAnswer(checkedDocuments);
    }
}
