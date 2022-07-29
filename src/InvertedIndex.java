import java.util.*;

public class InvertedIndex {
    private static InvertedIndex single_instance;
    public static InvertedIndex getInstance()
    {
        if (single_instance == null)
            single_instance = new InvertedIndex();

        return single_instance;
    }
    public HashMap<String, Set<String>> wordToDocumentMap = new HashMap<>();

    public String[] wordSplitter(Map.Entry<String, String> file) {
        String content = file.getValue();
        return content.split("\\s");
    }

    public void makeWordToDocumentMap(String[] words, String fileName) {
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
    public void showFiles(HashMap<String, String> fileNameToContent) {
        for (Map.Entry<String, String> file : fileNameToContent.entrySet()) {
            String fileName = file.getKey();
            String[] words = wordSplitter(file);
            makeWordToDocumentMap(words, fileName);
        }
    }
}
