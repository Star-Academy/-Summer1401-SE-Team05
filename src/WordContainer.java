import java.util.ArrayList;

public class WordContainer {
    private static WordContainer single_instance;
    public static WordContainer getInstance()
    {
        if (single_instance == null)
            single_instance = new WordContainer();

        return single_instance;
    }
    public ArrayList<String> plusWords = new ArrayList<>();
    public ArrayList<String> minusWords = new ArrayList<>();
    public ArrayList<String> normalWords = new ArrayList<>();
}
