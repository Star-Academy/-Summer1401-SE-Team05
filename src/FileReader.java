import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Objects;

public class FileReader {
    public static HashMap<String, String> readFiles(String path) {
        File dir = new File(path);
        HashMap<String, String> fileNameToContent = new HashMap<>();
        for (File file : Objects.requireNonNull(dir.listFiles())) {
            String content = null;
            try {
                content = Files.readString(Paths.get(file.getPath()));
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            content = content.toUpperCase();
            fileNameToContent.put(file.getName(), content);
        }
        return fileNameToContent;
    }

    public static ArrayList<String> getFileNames(String path){
        File dir = new File(path);
        ArrayList<String> fileNames = new ArrayList<>();

        for (File file : Objects.requireNonNull(dir.listFiles())) {
            fileNames.add(file.getName());
        }
        return fileNames;
    }
}
