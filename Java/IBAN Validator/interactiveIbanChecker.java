import java.math.BigInteger;
import java.util.Scanner;

public final class interactiveIbanChecker extends ibanNavigation {

    public static final int IBANNUMBER_MIN_SIZE = 15;
    public static final int IBANNUMBER_MAX_SIZE = 34;
    public static final BigInteger IBANNUMBER_MAGIC_NUMBER = new BigInteger("97");

    public static boolean ibanTest() {
        System.out.println("Enter Account Number");
        Scanner enterAccountNumber = new Scanner(System.in);
        String newAccountNumber = enterAccountNumber.nextLine();
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
