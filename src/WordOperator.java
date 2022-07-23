import java.util.ArrayList;

public class WordOperator {
    private static WordOperator single_instance;
    public static WordOperator getInstance()
    {
        if (single_instance == null)
            single_instance = new WordOperator();

        return single_instance;
    }
    public void operate(String[] wordsToFind) {
        ArrayList<ConditionChecker> checkerList = init(WordContainer.getInstance());
        for (String word : wordsToFind) {
            for (ConditionChecker checker : checkerList) {
                boolean flag = checker.checkAndAdd(word);
                if (flag){
                    break;
                }
            }
        }
    }

    private ArrayList<ConditionChecker> init(WordContainer wordContainer) {
        ArrayList<ConditionChecker> toReturn = new ArrayList<>();
        toReturn.add(new PlusWordsChecker(wordContainer));
        toReturn.add(new MinusWordsChecker(wordContainer));
        toReturn.add(new NormalWordsChecker(wordContainer));
        return toReturn;
    }
}
