import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.math.BigInteger;
import java.util.Scanner;

public final class ibanWriter extends ibanNavigation {

    public static final int IBANNUMBER_MIN_SIZE = 15;
    public static final int IBANNUMBER_MAX_SIZE = 34;
    public static final BigInteger IBANNUMBER_MAGIC_NUMBER = new BigInteger("97");

    static Scanner scan = new Scanner(System.in);

    public static void ibanWrite() {
        try {
            // File name search
            // TODO - get fileName without extension
            System.out.println("Enter the file to be searched.. ");
            String fileName = scan.nextLine();
            // File directory search
            System.out.println("Enter the directory where to search ");
            String fileDirectory = scan.nextLine();

            File fileOpen = new File(fileDirectory, fileName);
            Scanner myReader = new Scanner(new FileReader(fileOpen));

            FileWriter myWriter = new FileWriter(fileName + ".out");

            String newAccountNumber = "";
            while (myReader.hasNextLine()) {
                newAccountNumber = myReader.nextLine();
                System.out.println(newAccountNumber);
                if (ibanWriter.ibanTest(newAccountNumber) == true) {
                    myWriter.write(newAccountNumber + ";true" + System.getProperty("line.separator"));

                } else {
                    myWriter.write(newAccountNumber + ";false" + System.getProperty("line.separator"));

                }
            }
            myWriter.close();
            System.out.println("writer closed");
        } catch (Exception ex) {
            ex.printStackTrace();
        }

    }

    public static boolean ibanTest(String newAccountNumber) {

        // TODO - Add Trim

        // Check that the total IBAN length is correct as per the country. If not, the
        // IBAN is invalid. We could also check
        // for specific length according to country, but for now we won't
        if (newAccountNumber.length() < IBANNUMBER_MIN_SIZE || newAccountNumber.length() > IBANNUMBER_MAX_SIZE) {
            System.out.println("IBAN length is wrong");
            return false;
        }

        // Move the four initial characters to the end of the string.
        newAccountNumber = newAccountNumber.substring(4) + newAccountNumber.substring(0, 4);

        // Replace each letter in the string with two digits, thereby expanding the
        // string, where A = 10, B = 11, ..., Z = 35.
        StringBuilder numericAccountNumber = new StringBuilder();
        int numericValue;
        for (int i = 0; i < newAccountNumber.length(); i++) {
            numericValue = Character.getNumericValue(newAccountNumber.charAt(i));
            if (-1 >= numericValue) {
                return false;
            } else {
                numericAccountNumber.append(numericValue);
            }
        }

        // Interpret the string as a decimal integer and compute the remainder of that
        // number on division by 97.
        BigInteger ibanNumber = new BigInteger(numericAccountNumber.toString());
        if (ibanNumber.mod(IBANNUMBER_MAGIC_NUMBER).intValue() == 1) {
            System.out.println("Valid IBAN");
            return true;
        } else {
            System.out.println("Invalid IBAN");
            return false;
        }

    }

}
