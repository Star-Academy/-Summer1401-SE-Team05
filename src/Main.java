import java.util.*;

public class Main {
    public static void init() {
        InvertedIndex.showFiles(FileReader.readFiles("C:\\Users\\moham\\Desktop\\Summer1401-SE-Team05\\Resources"));
    }
    public static void endProgramWithNothing() {
        System.out.println("No documents were found!");
        System.exit(0);
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String words = scanner.nextLine();
        words = words.toUpperCase();
        String[] wordsToFind = words.split("\\s");

        init();

        ArrayList<String> documentNames = FileReader.getFileNames("C:\\Users\\moham\\Desktop\\Summer1401-SE-Team05\\Resources");
        ArrayList<String> plusWords = new ArrayList<>();
        ArrayList<String> minusWords = new ArrayList<>();
        ArrayList<String> normalWords = new ArrayList<>();

        for (String word : wordsToFind) {
            if (word.startsWith("+")) {
                plusWords.add(word.substring(1));
            } else if (word.startsWith("-")) {
                minusWords.add(word.substring(1));
            } else {
                normalWords.add(word);
            }
        }

        for (String normalWord : normalWords) {
            if (!InvertedIndex.wordToDocumentMap.containsKey(normalWord)){
                endProgramWithNothing();
            }
        }

        documentNames.removeIf(documentName -> {
            boolean flg = false;
            for (String normalWord : normalWords) {
                if (!InvertedIndex.wordToDocumentMap.get(normalWord).contains(documentName)) {
                    flg = true;
                }

            }
            return flg;
        });


        ArrayList<String> documentsWithPlusWords = new ArrayList<>();
        for (String word : plusWords) documentsWithPlusWords.addAll(InvertedIndex.wordToDocumentMap.get(word));

        if (!documentsWithPlusWords.isEmpty())
            documentNames.removeIf(s -> !documentsWithPlusWords.contains(s));


        ArrayList<String> documentsWithMinusWords = new ArrayList<>();
        for (String word : minusWords) documentsWithMinusWords.addAll(InvertedIndex.wordToDocumentMap.get(word));

        documentNames.removeIf(documentsWithMinusWords::contains);

        if (documentNames.isEmpty()){
            endProgramWithNothing();
        }

        Collections.sort(documentNames);
        for (String documentName : documentNames) {
            System.out.println(documentName);
        }

    }
}
