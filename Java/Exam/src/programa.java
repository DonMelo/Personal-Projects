import java.sql.*;
import java.util.Scanner;


public class programa {
    public static void main (String[] args){
        String nuorodaIDB = "jdbc:mysql://localhost:3306/";
        String loginDB = "root";
        String passwordDB = "";
        try {
            Connection jungtis = DriverManager.getConnection(nuorodaIDB, loginDB, passwordDB);
            Statement sakinys = jungtis.createStatement();

            sukurtiDB(sakinys);
            dbNaudojimas(sakinys);
            recepLent(sakinys);
            pavadinimoDBIrasai(sakinys);
            System.out.println("Connected");
            dbNavigacija(sakinys);


        }


        catch (SQLException e) {
            e.printStackTrace();
            System.out.println("Error happened");

        }
    }

    public static void sukurtiDB(Statement sakinys) throws SQLException {
        String dbSukurimas = "CREATE DATABASE IF not EXISTS receptai" ;
        sakinys.execute(dbSukurimas);
    }
    public static void dbNaudojimas(Statement sakinys) throws SQLException {
        String dbNaudojimas = "USE receptai;";
        sakinys.execute(dbNaudojimas);
    }
    public static void recepLent(Statement sakinys) throws SQLException {
        String recepLent = "CREATE TABLE IF not EXISTS recep " +
                "(pavadinimas_id INTEGER(6) UNSIGNED AUTO_INCREMENT not NULL, " +
                " pavadinimas VARCHAR(20)  not NULL, " +
                " ingridientai VARCHAR(20) not NULL," +
                " nurodymai VARCHAR(20) not NULL, " +
                " PRIMARY KEY ( pavadinimas_id ))";
        sakinys.execute(recepLent);
    }

    public static void pavadinimoDBIrasai(Statement sakinys) throws SQLException
    {

        String pirmiDBIrasai =
                "INSERT INTO recep (pavadinimas, ingridientai, nurodymai) " +
                        "VALUES " +
                        "('Vaistas1', 'lkajsd', 'varoti per burna'), " +
                        "('Vaistas2', 'jkla', 'lasiukai'), " +
                        "('Vaistas3', 'asddasd', '3kart dienoj'), " +
                        "('Vaistas4', 'Ingri, dien, tai6505', 'pries valgi'), " +
                        "('Vaistas5', 'Ingridientai, ASDKJ', 'miegot'), " +
                        "('Vaistas6', 'In, gri, dien, tai777', 'sausgysles'), " +
                        "('Vaistas7', 'Ingri, dient, aia, SDJKH', 'nuo streso'), " +
                        "('Vaistas8', 'Ingridientai, 216', 'nuo nemigos'), " +
                        "('Vaistas9', 'Ingridi, entai9999', 'asdjhasd') ";
        sakinys.executeUpdate(pirmiDBIrasai);
    }

    public static void dbNavigacija(Statement sakinys) throws SQLException {
        System.out.println("paspauskite 1 ivesti nauja irasa");
        System.out.println("paspauskite 2 atlikti veiksmams su esanciais irasais");
        System.out.println("paspauskite 9 uzdaryti programai");
        System.out.println("Jusu pasirinkimas:");
        Scanner scanner = new Scanner(System.in);
        int a = Integer.parseInt(scanner.nextLine());
        if (a == 1) {
            System.out.println("Naujo iraso ivedimas");
            System.out.println("iveskite pavadinima:");
            Scanner pavadinimoIvedimas = new Scanner(System.in);
            String pavadinimas = pavadinimoIvedimas.nextLine();
            System.out.println("iveskite ingridientus:");
            Scanner ingridientuIvedimas = new Scanner(System.in);
            String ingridientai = ingridientuIvedimas.nextLine();
            System.out.println("iveskite nurodymus:");
            Scanner nurodymuIvedimas = new Scanner(System.in);
            String nurodymai = nurodymuIvedimas.nextLine();

            String ivedimas = "INSERT INTO recep (pavadinimas, ingridientai, nurodymai) VALUES ('" + pavadinimas + "','" + ingridientai + "','" + nurodymai + "')";
            sakinys.executeUpdate(ivedimas);
            System.out.println("Sekmingai ivesta");

        }
        else if (a == 2) {
            System.out.println("Iveskite '1' kad isvesti visus receptu irasus");
            System.out.println("Iveskite '2' kad atliktumete paieska pagal pavadinima");
            System.out.println("Iveskite '3' kad ieskotumete ingridientu pagal 'id'");
            int korekcijosPasirinkimas= Integer.parseInt(scanner.nextLine());
            if (korekcijosPasirinkimas == 1) {
                ResultSet gautosEilutes = sakinys.executeQuery("SELECT * FROM recep");
                System.out.println("pavadinimas  ingridientai    nurodymai");

                while (gautosEilutes.next()) {
                    String pavadinimas = gautosEilutes.getString("pavadinimas");
                    String ingridientai = gautosEilutes.getString("ingridientai");
                    String nurodymai = gautosEilutes.getString("nurodymai");
                    System.out.println(pavadinimas+"   "+ingridientai+"    "+nurodymai);
                }
            }
            if (korekcijosPasirinkimas == 2)
//                Įvedus dvejetą – duoti įvesti dar vieną parametrą “pavadinimą” ir po to išvesti
//                receptą, kurio “pavadinimas” sutampa su įvestu. Išvesti “Tokio nėra”, jei tokio nėra.
            {
                System.out.println("Iveskite pavadinima:");
                String vardoPaieska = scanner.nextLine();
                ResultSet vardoPaieskosEilutes = sakinys.executeQuery("SELECT * FROM recep WHERE pavadinimas = '"+ vardoPaieska +"'");
                ResultSetMetaData rsmd = vardoPaieskosEilutes.getMetaData();
                int columnsNumber = rsmd.getColumnCount();
//                if (!vardoPaieskosEilutes.) {
//                    System.out.println("Tokio nera");
//                } fixme
                while (vardoPaieskosEilutes.next()) {
                    for(int i = 1 ; i <= columnsNumber; i++){
                        System.out.println(vardoPaieskosEilutes.getString(i) + " ");
                    }
                }
            }

            if (korekcijosPasirinkimas == 3) // Įvedus trejetą – duoti įvesti dar vieną parametrą “id” ir po to išvesti kiek receptas
            //(kurio ID sutampa) turi ingredientų (juos suskaičiuoti java programoje)
            {

                System.out.println("Iveskite ID:");
                Scanner idIvedimas = new Scanner(System.in);
                String id = idIvedimas.nextLine();
                ResultSet idPaieska = sakinys.executeQuery("SELECT ingridientai FROM recep WHERE pavadinimas_id = '"+ id +"'");

                while (idPaieska.next()) {
                    String ingridientai = idPaieska.getString("ingridientai");
                    System.out.println(ingridientai.split(",").length);

                }

            }

        }
        else if (a == 9){
            return;
        }
        else {
            System.out.println("nezinomas irasas");
        }
        dbNavigacija(sakinys);

    }
}

