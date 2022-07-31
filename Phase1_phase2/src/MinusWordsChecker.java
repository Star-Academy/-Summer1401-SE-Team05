public class MinusWordsChecker extends ConditionChecker {

    public MinusWordsChecker(WordContainer wordContainer) {
        super(wordContainer);
    }

    @Override
    public boolean checkAndAdd(String word) {
        if (word.startsWith("-")) {
            wordContainer.minusWords.add(word.substring(1));
            return true;
        }
        return false;
    }
}
