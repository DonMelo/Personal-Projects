import java.io.FileNotFoundException;
import java.util.Scanner;

public class ibanNavigation {
    public static void main(String[] args) throws FileNotFoundException {
        System.out.println("Press 1 or press 2");
        Scanner input = new Scanner(System.in);
        int a = Integer.parseInt(input.nextLine());
        // Interaktyvus IBAN numerių tikrinimas. Vartotojo paprašoma įvesti sąskaitos
        // numerį ir programa išveda ar numeris yra teisingas
        if (a == 1) {
            interactiveIbanChecker.ibanTest();
        }
        // IBAN numerių iš tekstinio failo tikrinimas. Vartotojo paprašoma įvesti failo
        // kelią ir pavadinimą. Programa nuskaito failą ir sutikrina sąskaitos numerius.
        // Rezultatus išveda į tokio pat pavadinimo failą su plėtiniu .out.
        else if (a == 2) {
            ibanWriter.ibanWrite();

        }
        input.close();
    }

}
