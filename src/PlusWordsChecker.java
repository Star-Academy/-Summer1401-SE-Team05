public class PlusWordsChecker extends ConditionChecker{

    public PlusWordsChecker(WordContainer wordContainer) {
        super(wordContainer);
    }

    @Override
    public boolean checkAndAdd(String word) {
        if (word.startsWith("+")){
            wordContainer.plusWords.add(word.substring(1));
            return true;
        }
        return false;
    }
}
