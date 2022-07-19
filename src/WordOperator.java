public class WordOperator {
    public static WordContainer operate(String[] wordsToFind) {
        WordContainer wordContainer = new WordContainer();
        for (String word : wordsToFind) {
            if (word.startsWith("+")) {
                wordContainer.plusWords.add(word.substring(1));
            } else if (word.startsWith("-")) {
                wordContainer.minusWords.add(word.substring(1));
            } else {
                wordContainer.normalWords.add(word);
            }
        }
        return wordContainer;
    }
}
