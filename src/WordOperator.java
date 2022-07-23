import java.util.ArrayList;

public class WordOperator {
    public static WordContainer operate(String[] wordsToFind) {
        WordContainer wordContainer = new WordContainer();
        ArrayList<ConditionChecker> checkerList = init(wordContainer);
        for (String word : wordsToFind) {
            for (ConditionChecker checker : checkerList) {
                boolean flag = checker.checkAndAdd(word);
                if (flag){
                    break;
                }
            }
        }
        return wordContainer;
    }

    private static ArrayList<ConditionChecker> init(WordContainer wordContainer) {
        ArrayList<ConditionChecker> toReturn = new ArrayList<>();
        toReturn.add(new PlusWordsChecker(wordContainer));
        toReturn.add(new MinusWordsChecker(wordContainer));
        toReturn.add(new NormalWordsChecker(wordContainer));
        return toReturn;
    }
}
