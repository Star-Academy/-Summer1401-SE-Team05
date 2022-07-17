import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class InvertedIndex {
    public static HashMap<String, ArrayList<String>> wordToDocumentMap = new HashMap<>();
    public static void showFiles(HashMap<String, String> fileNameToContent) {
        for (Map.Entry<String, String> file : fileNameToContent.entrySet()) {
            String content = file.getValue();
            String fileName = file.getKey();
            String[] words = content.split("\\s");
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
    }

}
