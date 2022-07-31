import java.util.ArrayList;

public class ProgramController {
    private final CheckersAndOperators checkerOperator = new CheckersAndOperators();

   public void init() {
        InvertedIndex.getInstance().showFiles(checkerOperator.fileReader.readFiles());
    }

    public void endIfSomeNormalWordHasNothing(WordContainer wordContainer) {
        for (String normalWord : wordContainer.normalWords) {
            if (!InvertedIndex.getInstance().wordToDocumentMap.containsKey(normalWord)){
                checkerOperator.ioOperations.endProgramWithNothing();
            }
        }
    }

    public void printFinalAnswer(ArrayList<String> checkedDocuments){

        if (checkedDocuments.isEmpty()){
            checkerOperator.ioOperations.endProgramWithNothing();
        }

        checkerOperator.ioOperations.printDocuments(checkedDocuments);
    }

    public void run() {
        String words = checkerOperator.ioOperations.getLine().toUpperCase();
        String[] wordsToFind = words.split("\\s");

        WordContainer wordContainer = new WordContainer();
        init();
        checkerOperator.wordOperator.operate(wordsToFind, wordContainer);
        endIfSomeNormalWordHasNothing(wordContainer);
        ArrayList<String> checkedDocuments = checkerOperator.documentChecker.getValidDocuments(wordContainer, checkerOperator);
        printFinalAnswer(checkedDocuments);
    }
}
