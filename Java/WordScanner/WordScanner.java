import java.io.File; // Import the File class
import java.io.FileNotFoundException; // Import this class to handle errors
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner; // Import the Scanner class to read text files

public class WordScanner {
    public static void main(String[] args) {
        try {
            File myObj = new File("words.txt");
            String longestWord = "";
            Scanner myReader = new Scanner(myObj);
            while (myReader.hasNextLine()) {
                String data = myReader.nextLine();
                if (validateWord(data) && data.length() > longestWord.length()) {
                    longestWord = data;
                }
            }
            System.out.println(longestWord);
            myReader.close();

        } catch (FileNotFoundException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
    }

    public static boolean validateWord(String data) {
        data = data.toUpperCase();
        List<Character> uniqueLetters = new ArrayList<>();
        if (data.contains("-") || data.contains(" ")) {
            return false;
        }
        if (data.matches(".*\\d.*")) {
            return false;
        }
        for (int i = 0; i < data.length(); i++) {
            // char letter = Character.toUpperCase(data.charAt(i));
            char letter = data.charAt(i);

            if (uniqueLetters.contains(letter)) {
                return false;
            } else {
                uniqueLetters.add(letter);
            }

        }

        return true;
    }
}
