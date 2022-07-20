import java.util.*;

public class InvertedIndex {
    public static HashMap<String, Set<String>> wordToDocumentMap = new HashMap<>();

    public static String[] wordSplitter(Map.Entry<String, String> file) {
        String content = file.getValue();
        return content.split("\\s");
    }

    public static void makeWordToDocumentMap(String[] words, String fileName) {
        for (String word : words) {
            if (wordToDocumentMap.containsKey(word)) {
                wordToDocumentMap.get(word).add(fileName);
            } else {
                Set<String> documentList = new HashSet<>();
                documentList.add(fileName);
                wordToDocumentMap.put(word, documentList);
            }
        }
    }
    public static void showFiles(HashMap<String, String> fileNameToContent) {
        for (Map.Entry<String, String> file : fileNameToContent.entrySet()) {
            String fileName = file.getKey();
            String[] words = wordSplitter(file);
            makeWordToDocumentMap(words, fileName);
        }
    }
}
