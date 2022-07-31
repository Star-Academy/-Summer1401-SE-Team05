public class NormalWordsChecker extends ConditionChecker{

    public NormalWordsChecker(WordContainer wordContainer) {
        super(wordContainer);
    }

    @Override
    public boolean checkAndAdd(String word) {
        wordContainer.normalWords.add(word);
        return true;
    }
}
