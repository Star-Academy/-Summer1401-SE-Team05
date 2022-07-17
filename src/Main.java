import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.*;

public class Main {
    public static HashMap<String, ArrayList<String> > wordToDocumentMap = new HashMap<>();

    public static void init(){
        File dir = new File("C:\\Users\\gamer\\OneDrive\\Desktop\\InvertedIndex\\Resources");
        showFiles(dir.listFiles());
    }
    public static void showFiles(File[] files) {
        for (File file : files) {
            try {
                String content = Files.readString(Paths.get(file.getPath()));
                content = content.toUpperCase();
                String[] words = content.split("\\s");
                for (String word : words) {
                    if (wordToDocumentMap.containsKey(word)) {
                        wordToDocumentMap.get(word).add(file.getName());
                    } else {
                        ArrayList<String> documentList= new ArrayList<>();
                        documentList.add(file.getName());
                        wordToDocumentMap.put(word, documentList);
                    }
                }

            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String word = scanner.nextLine();
        word = word.toUpperCase();
        init();
        if (wordToDocumentMap.containsKey(word)) {
            for (String s : wordToDocumentMap.get(word)) {
                System.out.println(s);
            }
        } else {
            System.out.println("Word not found !");
        }
    }
}
