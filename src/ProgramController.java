import java.util.ArrayList;

public class ProgramController {
    private static ProgramController single_instance;
    public static ProgramController getInstance()
    {
        if (single_instance == null)
            single_instance = new ProgramController();

        return single_instance;
    }
    public void init() {
        InvertedIndex.getInstance().showFiles(FileReader.getInstance().readFiles());
    }

    public static void endIfSomeNormalWordHasNothing() {
        for (String normalWord : WordContainer.getInstance().normalWords) {
            if (!InvertedIndex.getInstance().wordToDocumentMap.containsKey(normalWord)){
                IOOperations.getInstance().endProgramWithNothing();
            }
        }
    }

    public static void printFinalAnswer(ArrayList<String> checkedDocuments){

        if (checkedDocuments.isEmpty()){
            IOOperations.getInstance().endProgramWithNothing();
        }

        IOOperations.getInstance().printDocuments(checkedDocuments);
    }

    public void run() {
        String words = IOOperations.getInstance().getLine().toUpperCase();
        String[] wordsToFind = words.split("\\s");

        init();
        WordOperator.getInstance().operate(wordsToFind);
        endIfSomeNormalWordHasNothing();
        ArrayList<String> checkedDocuments = DocumentChecker.getInstance().check();
        printFinalAnswer(checkedDocuments);
    }
}
