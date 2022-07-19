import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class InvertedIndex {
    public static HashMap<String, ArrayList<String>> wordToDocumentMap = new HashMap<>();

    public static String[] wordSplitter(Map.Entry<String, String> file) {
        String content = file.getValue();
        return content.split("\\s");
    }

    public static void makeWordToDocumentMap(String[] words, String fileName) {
        for (String word : words) {
            if (wordToDocumentMap.containsKey(word)) {
                if (!wordToDocumentMap.get(word).contains(fileName))
                    wordToDocumentMap.get(word).add(fileName);
            } else {
                ArrayList<String> documentList = new ArrayList<>();
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
