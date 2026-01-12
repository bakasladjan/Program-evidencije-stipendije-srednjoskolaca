using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaStipendijaDetaljiEditClass
    {
   // atributi i property
        private string pStringKonekcije;
        private StipendijaDBClass objStipendijaDB;

        private StipendijaClass objPreuzetaStipendija;
        private StipendijaClass objIzmenjenaStipendija;

        private string pSifraPreuzeteStipendije;
        private string pNazivPreuzeteStipendije;
        private string pIznosPreuzeteStipendije;


        private string pSifraIzmenjeneStipendije;
        private string pNazivIzmenjeneStipendije;
        private string pIznosIzmenjeneStipendije;


        // PROPERTY

        public string SifraPreuzeteStipendije
        {
            get { return pSifraPreuzeteStipendije; }
            set {
                pSifraPreuzeteStipendije = value;
                pNazivPreuzeteStipendije = DajNaziv(pSifraPreuzeteStipendije);
                pIznosPreuzeteStipendije = DajIznos(pSifraPreuzeteStipendije);

            }
          }

          public string NazivPreuzeteStipendije
          {
          get { return pNazivPreuzeteStipendije; }
          }

        public string IznosPreuzeteStipendije
        {
            get { return pIznosPreuzeteStipendije; }
        }

    


        public string SifraIzmenjeneStipendije
        {
           get { return pSifraIzmenjeneStipendije; }
           set { pSifraIzmenjeneStipendije = value; }

           }

          public string NazivIzmenjeneStipendije
          {
            get { return pNazivIzmenjeneStipendije; }
            set { pNazivIzmenjeneStipendije = value; }
          }

        public string IznosIzmenjeneStipendije
        {
            get { return pIznosIzmenjeneStipendije; }
            set { pIznosIzmenjeneStipendije = value; }
        }





        // konstruktor
        public FormaStipendijaDetaljiEditClass(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
            objStipendijaDB = new StipendijaDBClass(pStringKonekcije);
        }

        // privatne metode
        private string DajNaziv(string pomSifra)
        {
            string pomNaziv ="";
            DataSet dsPodaci = new DataSet();
            pomNaziv = objStipendijaDB.DajNazivStipendijePremaSifri(pomSifra); 

            return pomNaziv;
        }

        private string DajIznos(string pomSifra)
        {
            string pomIznos = "";
            DataSet dsPodaci = new DataSet();
            pomIznos = objStipendijaDB.DajIznosStipendijePremaSifri(pomSifra).ToString();

            return pomIznos;
        }





        // javne metode
        public bool ObrisiStipendiju()
        {
            // zvanje koje je trenutno u atributima dato, TJ. preuzeta sifra je bitna
            bool uspehBrisanja = false;
            uspehBrisanja = objStipendijaDB.ObrisiStipendiju(pSifraPreuzeteStipendije);  

            return uspehBrisanja;

        }

        public bool IzmeniStipendiju()
        {
            bool uspehIzmene = false;
            objPreuzetaStipendija = new StipendijaClass();
            objIzmenjenaStipendija = new StipendijaClass();

            objPreuzetaStipendija.Sifra = pSifraPreuzeteStipendije;
            objPreuzetaStipendija.Naziv = pNazivPreuzeteStipendije;
            objPreuzetaStipendija.Iznos = int.Parse(pIznosPreuzeteStipendije.ToString());


            objIzmenjenaStipendija.Sifra = pSifraIzmenjeneStipendije;
            objIzmenjenaStipendija.Naziv = pNazivIzmenjeneStipendije;
            objIzmenjenaStipendija.Iznos = int.Parse(pIznosIzmenjeneStipendije.ToString());


            uspehIzmene = objStipendijaDB.IzmeniStipendiju(objPreuzetaStipendija, objIzmenjenaStipendija);  

            return uspehIzmene;
        }
    }
}
