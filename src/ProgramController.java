import java.util.ArrayList;

public class ProgramController {
    public static void init() {
        InvertedIndex.showFiles(FileReader.readFiles());
    }

    public static void endIfSomeNormalWordHasNothing(WordContainer wordContainer) {
        for (String normalWord : wordContainer.normalWords) {
            if (!InvertedIndex.wordToDocumentMap.containsKey(normalWord)){
                IOOperations.endProgramWithNothing();
            }
        }
    }

    public static void printFinalAnswer(ArrayList<String> checkedDocuments){

        if (checkedDocuments.isEmpty()){
            IOOperations.endProgramWithNothing();
        }

        IOOperations.printDocuments(checkedDocuments);
    }

    public static void run() {
        String words = IOOperations.getLine().toUpperCase();
        String[] wordsToFind = words.split("\\s");

        init();
        WordContainer wordContainer = WordOperator.operate(wordsToFind);
        endIfSomeNormalWordHasNothing(wordContainer);
        ArrayList<String> checkedDocuments = DocumentChecker.check(wordContainer);
        printFinalAnswer(checkedDocuments);
    }
}
