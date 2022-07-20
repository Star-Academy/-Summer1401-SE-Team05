import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Objects;

public class FileReader {
    public static String path = "C:\\Users\\gamer\\OneDrive\\Desktop\\InvertedIndex\\Resources";
    public static ArrayList<String> fileNames = new ArrayList<>();
    public static String getFileContent(File file){
        try {
            return Files.readString(Paths.get(file.getPath()));
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public static HashMap<String, String> readFiles() {
        File dir = new File(path);
        HashMap<String, String> fileNameToContent = new HashMap<>();
        for (File file : Objects.requireNonNull(dir.listFiles())) {
            String content = getFileContent(file).toUpperCase();
            fileNameToContent.put(file.getName(), content);
        }

        fileNames = new ArrayList<>(fileNameToContent.keySet());
        return fileNameToContent;
    }

    public static ArrayList<String> getFileNames(){
        return fileNames;
    }
}
