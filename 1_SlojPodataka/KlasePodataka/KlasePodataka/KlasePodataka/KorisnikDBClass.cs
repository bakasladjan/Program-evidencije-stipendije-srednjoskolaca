using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;

namespace KlasePodataka
{
    public class KorisnikDBClass
    {

         // atributi
        private string _stringKonekcije;

        // property
        public string StringKonekcije
        {
            get
            {
                return _stringKonekcije;
            }
            set 
            {
                if (this._stringKonekcije != value)
                    this._stringKonekcije = value;
            }
        }
        // konstruktor
        // prijema vrednosti stringa konekcije spolja i dodele atributu
        public KorisnikDBClass(string noviStringKonekcije)
        // OVO JE DOBRO JER OBAVEZUJE DA SE PRILIKOM INSTANCIRANJA OVE KLASE
        // MORA OBEZBEDITI STRING KONEKCIJE
        {
               _stringKonekcije = noviStringKonekcije; 
        }

          // privatne metode

          // javne metode
          // metoda koja vraca korisnikove podatke, pozivajuci stored proceduru
          public DataSet DajKorisnikaPoKorisnickomImenuISifri(string pomKorisnickoIme, string pomSifra)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajKorisnikaPoKorisnickomImenuISifri", Veza);
            Komanda.Parameters.Add("@KorisnickoIme", SqlDbType.NVarChar).Value = pomKorisnickoIme;
            Komanda.Parameters.Add("@Sifra", SqlDbType.NVarChar).Value = pomSifra;
            Komanda.CommandType = CommandType.StoredProcedure;

               // SqlCommand komanda = new SqlCommand("SELECT * FROM Korisnik WHERE KorisnickoIme='" + pomKorisnickoIme + "' AND Sifra='" + pomSifra + "'", veza);
               //  komanda.CommandType = CommandType.Text;
               SqlDataAdapter dataAdapter = new SqlDataAdapter();
               dataAdapter.SelectCommand = Komanda;
               dataAdapter.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            
            return dsPodaci;
        }
     }
}
