public abstract class ConditionChecker {
    WordContainer wordContainer;

    public ConditionChecker(WordContainer wordContainer) {
        this.wordContainer = wordContainer;
    }

    public abstract boolean checkAndAdd(String word);

}
