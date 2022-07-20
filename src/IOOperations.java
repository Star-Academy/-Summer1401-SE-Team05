import java.util.ArrayList;
import java.util.Scanner;

public class IOOperations {
    public static Scanner scanner = new Scanner(System.in);

    public static void endProgramWithNothing() {
        System.out.println("No documents were found!");
        System.exit(0);
    }

    public static void printDocuments(ArrayList<String> checkedDocuments){
        for (String documentName : checkedDocuments) {
            System.out.println(documentName);
        }
    }
    public static String getLine() {
        return scanner.nextLine();
    }
}
