using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;

namespace KlasePodataka
{
    public class UcenikDBClass
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
        }
        // konstruktor
        public UcenikDBClass(string noviStringKonekcije)
        {
               _stringKonekcije = noviStringKonekcije; 
        }

          // privatne metode

          // javne metode
          // metoda koja vraca sve upute iz baze podataka, pozivajuci stored proceduru
          public DataSet DajSveUcenike()
        {
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveUcenikeSaJoin", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
               dataAdapter.SelectCommand = Komanda;
               dataAdapter.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            
            return dsPodaci;
        }

          // metoda koja vraca učenike prema prosledjenom datumu rodjenja
          public DataSet DajUcenikaPoJMBG(string JMBGUcenika)
        {
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajUcenikaPoJMBG", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@JMBGUcenika", SqlDbType.NVarChar).Value = JMBGUcenika.ToString();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
               dataAdapter.SelectCommand = Komanda;
               dataAdapter.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }


          // metoda koja vraca datum rodjenja učenika za prosledjeni JMBG
          public DateTime DajDatumRodjenjaPoJMBG(string JMBGUcenika)
        {
               DateTime datumRodjenja = DateTime.Today;

            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajDatumRodjenjaPoJMBG", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@JMBGUcenika", SqlDbType.Char).Value = JMBGUcenika;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
               dataAdapter.SelectCommand = Komanda;
               dataAdapter.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

               datumRodjenja = DateTime.Parse(dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString());

               return datumRodjenja;
               
        }

          // metoda koja vraca ime i prezime učenika za prosledjeni JMBG
          public string DajImeIPrezimeUcenikaPoJMBG(string JMBGUcenika)
          {
               string imeIPrezime = "";
               DataSet dsPodaci = new DataSet();

               SqlConnection veza = new SqlConnection(_stringKonekcije);
               veza.Open();
               SqlCommand komanda = new SqlCommand("DajImeIPrezimeUcenikaPoJMBG", veza);
               komanda.CommandType = CommandType.StoredProcedure;
               komanda.Parameters.Add("@JMBGUcenika", SqlDbType.Char).Value = JMBGUcenika;
               SqlDataAdapter dataAdapter = new SqlDataAdapter();
               dataAdapter.SelectCommand = komanda;
               dataAdapter.Fill(dsPodaci);
               veza.Close();
               veza.Dispose();

               imeIPrezime = dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString();

                return imeIPrezime;
               
          }

        // metoda koja vraca razred učenika za prosledjeni JMBG
        public string DajRazredPoJMBG(string JMBGUcenika)
        {
            string razred = "";
            DataSet dsPodaci = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajRazredPoJMBG", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@JMBGUcenika", SqlDbType.Char).Value = JMBGUcenika;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(dsPodaci);
            veza.Close();
            veza.Dispose();

            razred = dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString();

            return razred;

        }



        // metoda koja vraca skolu učenika za prosledjeni JMBG
        public string DajSkoluPoJMBG(string JMBGUcenika)
        {
            string skola = "";
            DataSet dsPodaci = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajSkoluPoJMBG", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@JMBGUcenika", SqlDbType.Char).Value = JMBGUcenika;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(dsPodaci);
            veza.Close();
            veza.Dispose();

            skola = dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString();

            return skola;

        }

        // metoda koja vraca adresu učenika za prosledjeni JMBG
        public string DajAdresuUcenikaPoJMBG(string JMBGUcenika)
          {
               string adresa = "";
               DataSet dsPodaci = new DataSet();

               SqlConnection veza = new SqlConnection(_stringKonekcije);
               veza.Open();
               SqlCommand komanda = new SqlCommand("DajAdresuUcenikaPoJMBG", veza);
               komanda.CommandType = CommandType.StoredProcedure;
               komanda.Parameters.Add("@JMBGUcenika", SqlDbType.Char).Value = JMBGUcenika;
               SqlDataAdapter dataAdapter = new SqlDataAdapter();
               dataAdapter.SelectCommand = komanda;
               dataAdapter.Fill(dsPodaci);
               veza.Close();
               veza.Dispose();

               adresa = dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString();

               return adresa;
               
          }

          // metoda koja vraca kontakt telefon učenika za prosledjeni JMBG
          public string DajKontaktTelefonPoJMBG(string JMBGUcenika)
          {
               string kontaktTelefon = "";
               DataSet dsPodaci = new DataSet();

               SqlConnection veza = new SqlConnection(_stringKonekcije);
               veza.Open();
               SqlCommand komanda = new SqlCommand("DajKontaktTelefonPoJMBG", veza);
               komanda.CommandType = CommandType.StoredProcedure;
               komanda.Parameters.Add("@JMBGUcenika", SqlDbType.Char).Value = JMBGUcenika;
               SqlDataAdapter dataAdapter = new SqlDataAdapter();
               dataAdapter.SelectCommand = komanda;
               dataAdapter.Fill(dsPodaci);
               veza.Close();
               veza.Dispose();

               kontaktTelefon = dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString();

               return kontaktTelefon;
               
          }

          // metoda koja vraca dijagnosticki postupak uputa za prosledjeni JMBG
          public string DajNazivStipendijePoJMBG(string JMBGUcenika)
          {
               string nazivStipendije = "";
               DataSet dsPodaci = new DataSet();

               SqlConnection veza = new SqlConnection(_stringKonekcije);
               veza.Open();
               SqlCommand komanda = new SqlCommand("DajNazivStipendijePoJMBG", veza);
               komanda.CommandType = CommandType.StoredProcedure;
               komanda.Parameters.Add("@JMBGUcenika", SqlDbType.Char).Value = JMBGUcenika;
               SqlDataAdapter dataAdapter = new SqlDataAdapter();
               dataAdapter.SelectCommand = komanda;
               dataAdapter.Fill(dsPodaci);
               veza.Close();
               veza.Dispose();

               nazivStipendije = dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString();

               return nazivStipendije;
              
          }

        public int DajIznosStipendijePoJMBG(string JMBGUcenika)
        {
            int iznosStipendije = 0;
            DataSet dsPodaci = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajIznosStipendijePoJMBG", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@JMBGUcenika", SqlDbType.Char).Value = JMBGUcenika;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(dsPodaci);
            veza.Close();
            veza.Dispose();

            iznosStipendije = int.Parse(dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString());

            return iznosStipendije;

        }



        public int DajUkupnoUcenikaZaStipendiju(string stipendijaID)
        {
            int ukupnoUcenika=0;
            DataSet dsPodaci = new DataSet();
            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajBrojUcenikaZaStipendiju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@IDStipendije", SqlDbType.Char).Value = stipendijaID;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

               ukupnoUcenika = int.Parse(dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString());  

               return ukupnoUcenika;

        } 
          

        private UcenikListaClass DajListuSvihUcenika()
        {
               // PRIPREMA PROMENLJIVIH
               UcenikListaClass ucenikListaObject = new UcenikListaClass();
            DataSet podaciUcenikaDataSet = new DataSet();
            UcenikClass ucenikObject;
            StipendijaClass stipendijaObject;

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveUcenikeSaJoinSifromStipendije", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
               dataAdapter.SelectCommand = Komanda;
               dataAdapter.Fill(podaciUcenikaDataSet);
            Veza.Close();
            Veza.Dispose();

            // FORMIRANJE OBJEKATA I UBACIVANJE U LISTU
            for (int brojac = 0; brojac < podaciUcenikaDataSet.Tables[0].Rows.Count; brojac++)
            {
                stipendijaObject = new StipendijaClass();
                stipendijaObject.Sifra = podaciUcenikaDataSet.Tables[0].Rows[brojac].ItemArray[5].ToString();
                stipendijaObject.Naziv = podaciUcenikaDataSet.Tables[0].Rows[brojac].ItemArray[4].ToString();
                stipendijaObject.Iznos =int.Parse (podaciUcenikaDataSet.Tables[0].Rows[brojac].ItemArray[3].ToString());


                ucenikObject = new UcenikClass();
                    ucenikObject.JMBGUcenika = podaciUcenikaDataSet.Tables[0].Rows[brojac].ItemArray [0].ToString ();
                    ucenikObject.ImeIPrezimeUcenika = podaciUcenikaDataSet.Tables[0].Rows[brojac].ItemArray [0].ToString ();
                    ucenikObject.Razred = podaciUcenikaDataSet.Tables[0].Rows[brojac].ItemArray[0].ToString();
                    ucenikObject.Skola = podaciUcenikaDataSet.Tables[0].Rows[brojac].ItemArray[0].ToString();
                    ucenikObject.DatumRodjenja = DateTime.Parse( podaciUcenikaDataSet.Tables[0].Rows[brojac].ItemArray[0].ToString());
                    ucenikObject.AdresaUcenika = podaciUcenikaDataSet.Tables[0].Rows[brojac].ItemArray[0].ToString();
                    ucenikObject.KontaktTelefon = podaciUcenikaDataSet.Tables[0].Rows[brojac].ItemArray[0].ToString();
                    ucenikObject.Stipendija = stipendijaObject;

                ucenikListaObject.DodajElementListe (ucenikObject);
            }

            return ucenikListaObject;
        }
        
          //metoda za snimanje novog učenika u bazu podataka
        public bool SnimiNovogUcenika(UcenikClass noviUcenikObject)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova =0;

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("DodajNovogUcenika", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@JMBGUcenika", SqlDbType.Char).Value = noviUcenikObject.JMBGUcenika;
            Komanda.Parameters.Add("@ImeIPrezimeUcenika", SqlDbType.NVarChar).Value = noviUcenikObject.ImeIPrezimeUcenika;
            Komanda.Parameters.Add("@Razred", SqlDbType.NVarChar).Value = noviUcenikObject.Razred;
            Komanda.Parameters.Add("@Skola", SqlDbType.Char).Value = noviUcenikObject.Skola;
            Komanda.Parameters.Add("@DatumRodjenja", SqlDbType.Date).Value = noviUcenikObject.DatumRodjenja;
            Komanda.Parameters.Add("@AdresaUcenika", SqlDbType.NVarChar).Value = noviUcenikObject.AdresaUcenika;
            Komanda.Parameters.Add("@KontaktTelefon", SqlDbType.NVarChar).Value = noviUcenikObject.KontaktTelefon;
            Komanda.Parameters.Add("@StipendijaID", SqlDbType.Char).Value = noviUcenikObject.Stipendija.Sifra;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();
            return (brojSlogova > 0);

        }

          //metoda za brisanje učenika iz baze
        public bool ObrisiUcenika(string JMBGUcenikaZaBrisanje)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiUcenika", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@JMBGUcenika", SqlDbType.Char).Value = JMBGUcenikaZaBrisanje;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

          //metoda za izmenu podataka o učeniku u bazi
        public bool IzmeniUcenika(UcenikClass stariUcenikObject, UcenikClass noviUcenikObject)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
               //Console.WriteLine(noviUcenikObject.Stipendija.Sifra);

               SqlCommand Komanda = new SqlCommand("IzmeniUcenika", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StariJMBGUcenika", SqlDbType.Char).Value = stariUcenikObject.JMBGUcenika;
            Komanda.Parameters.Add("@JMBGUcenika", SqlDbType.Char).Value = noviUcenikObject.JMBGUcenika;
            Komanda.Parameters.Add("@ImeIPrezimeUcenika", SqlDbType.NVarChar).Value = noviUcenikObject.ImeIPrezimeUcenika;
            Komanda.Parameters.Add("@Razred", SqlDbType.NVarChar).Value = noviUcenikObject.Razred;
            Komanda.Parameters.Add("@Skola", SqlDbType.Char).Value = noviUcenikObject.Skola;
            Komanda.Parameters.Add("@DatumRodjenja", SqlDbType.Date).Value = noviUcenikObject.DatumRodjenja;
            Komanda.Parameters.Add("@AdresaUcenika", SqlDbType.NVarChar).Value = noviUcenikObject.AdresaUcenika;
            Komanda.Parameters.Add("@KontaktTelefon", SqlDbType.NVarChar).Value = noviUcenikObject.KontaktTelefon;
            Komanda.Parameters.Add("@StipendijaID", SqlDbType.Char).Value = noviUcenikObject.Stipendija.Sifra;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        


    }
}
