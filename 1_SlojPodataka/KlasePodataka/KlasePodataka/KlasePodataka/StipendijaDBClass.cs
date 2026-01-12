using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;
//OVO SE KORISTI KOD WEB APP using System.Configuration; 

namespace KlasePodataka
{
    public class StipendijaDBClass
    {
        // atributi
        private string _stringKonekcije;

        // property
        // 1. nacin
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
        public StipendijaDBClass(string noviStringKonekcije)
        // OVO JE DOBRO JER OBAVEZUJE DA SE PRILIKOM INSTANCIRANJA OVE KLASE
        // MORA OBEZBEDITI STRING KONEKCIJE
        {
               _stringKonekcije = noviStringKonekcije; 
        }

          // privatne metode

          // javne metode
          // metoda koja poziva stored proceduru i vraca sve stipendije koje postoje u bazi
          public DataSet DajSveStipendije()
        {
            DataSet dsPodaci = new DataSet();
            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveStipendije", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
               dataAdapter.SelectCommand = Komanda;
               dataAdapter.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            
            return dsPodaci;
        }

          // poziva se procedura koja prema prosledjenoj šifri škole, vraća naziv škole
          public string DajNazivStipendijePremaSifri(string sifraStipendije)
        {
            string nazivStipendije = "";

            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajNazivStipendijePoSifri", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
               //treba char umesto nvarchar
            Komanda.Parameters.Add("@Sifra", SqlDbType.NVarChar).Value = sifraStipendije;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
               dataAdapter.SelectCommand = Komanda;
               dataAdapter.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            nazivStipendije = dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString();

            return nazivStipendije;
        }

        public string DajSifruStipendijePoNazivu(string Naziv)
        {
            string sifraStipendije = "";

            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSifruStipendijePoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            //treba char umesto Nazi
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = Naziv;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = Komanda;
            dataAdapter.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            sifraStipendije = dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString();

            return sifraStipendije;
        }
        public int DajIznosStipendijePremaSifri(string sifraStipendije)
        {
            int iznosStipendije = 0;

            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajIznosStipendijePoSifri", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            //treba char umesto nvarchar
            Komanda.Parameters.Add("@Sifra", SqlDbType.NVarChar).Value = sifraStipendije;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = Komanda;
            dataAdapter.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            iznosStipendije =int.Parse(dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString());

            return iznosStipendije;
        }




          // metoda vraca školu, na osnovu prosledjenog naziva
          public DataSet DajStipendijuPoNazivu(string nazivStipendije)
        {
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajStipendijuPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = nazivStipendije;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

          // overloading metoda - isto se zove, ima drugaciji parametar
          // vraca školu po prosledjenom nazivu, koji predstavlja filter

          public DataSet DajStipendijuPoNazivu(StipendijaClass stipendijaZaFilterObject)
        {
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajStipendijuPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = stipendijaZaFilterObject.Naziv;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
               dataAdapter.SelectCommand = Komanda;
               dataAdapter.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

          // refaktorisanje - direktno pisanje sql upita u klasi

          // metoda koja poziva stored proceduru za snimanje nove škole
          public bool SnimiNovuStipendiju(StipendijaClass novaStipendijaObject)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
               int brojSlogova =0;
               string sifra = novaStipendijaObject.Sifra;
               string naziv = novaStipendijaObject.Naziv;
               int iznos = novaStipendijaObject.Iznos;


            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("INSERT INTO STIPENDIJA(Sifra, Naziv, Iznos) VALUES('" + sifra + "', '" + naziv + "', '" + iznos + "')", Veza);
            Komanda.Parameters.AddWithValue("@Sifra", sifra);
            Komanda.Parameters.AddWithValue("@Naziv", naziv);
            Komanda.Parameters.AddWithValue("@Iznos", iznos);
            Komanda.CommandType = CommandType.Text;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);
            
        }

          //metoda za brisanje škole
        public bool ObrisiStipendiju(StipendijaClass stipendijaZaBrisanjeObject)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiStipendiju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Sifra", SqlDbType.NVarChar).Value = stipendijaZaBrisanjeObject.Sifra;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

         }

        // method overloading - ista procedura sa razlicitim parametrom
        public bool ObrisiStipendiju(string sifraStipendijeZaBrisanje)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiStipendiju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Sifra", SqlDbType.NVarChar).Value = sifraStipendijeZaBrisanje;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

          //metoda za izmenu podataka
        public bool IzmeniStipendiju(StipendijaClass staraStipendijaObject, StipendijaClass novaStipendijaObject)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniStipendiju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StaraSifra", SqlDbType.NVarChar).Value = staraStipendijaObject.Sifra;
            Komanda.Parameters.Add("@Sifra", SqlDbType.NVarChar).Value = novaStipendijaObject.Sifra;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = novaStipendijaObject.Naziv;
            Komanda.Parameters.Add("@Iznos", SqlDbType.Int).Value = novaStipendijaObject.Iznos;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        // method overloading - ista metoda, samo drugaciji parametri
        public bool IzmeniStipendiju(string sifraStareStipendije, StipendijaClass novaStipendijaObject)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(_stringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniStipendiju", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StaraSifra", SqlDbType.NVarChar).Value = sifraStareStipendije;
            Komanda.Parameters.Add("@Sifra", SqlDbType.NVarChar).Value = novaStipendijaObject.Sifra;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = novaStipendijaObject.Naziv;
            Komanda.Parameters.Add("@Iznos", SqlDbType.Int).Value = novaStipendijaObject.Iznos;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }


    }
}
