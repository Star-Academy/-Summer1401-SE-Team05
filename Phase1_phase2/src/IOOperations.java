import java.util.ArrayList;
import java.util.Scanner;

public class IOOperations {
    public Scanner scanner = new Scanner(System.in);

    public void endProgramWithNothing() {
        System.out.println("No documents were found!");
        System.exit(0);
    }

    public void printDocuments(ArrayList<String> checkedDocuments){
        for (String documentName : checkedDocuments) {
            System.out.println(documentName);
        }
    }
    public String getLine() {
        return scanner.nextLine();
    }
}
