using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
//
using KlasePodataka;
using KlaseMapiranja;
using DBUtils;
using System.Data.SqlClient;
using System.Data;




namespace PoslovnaLogika
{
     public class PoslovnaPravilaClass
     {
          // TREBALO BI DA SE PRERADI IZ 3 KLASE:
          // Sistematizacija radnih mesta - izdvaja ogranicenje
          // Opterecenje - stanje u BP povodom broja nastavnika
          // Zaposljavanje - proverava i uporedjuje podatke iz sistematizacije i opterecenja

          // atributi
          private string pStringKonekcije;

          // property

          // konstruktor
          public PoslovnaPravilaClass(string NoviStringKonekcije)
          {
               pStringKonekcije = NoviStringKonekcije;
          }

          // privatne metode

          // public metode
          public bool DaLiImaMestaZaUpis(string SifraIzBazePodataka)
          {
               // POSLOVNO PRAVILO:
               // Na fakultetu ne moze biti zaposleno vise nastavnika u odredjenom
               // zvanju nego sto je dozvoljeno maksimalnim brojem prema Sistematizaciji
               // radnih mesta.

               bool imaMesta = false;


               int MaxBrojUcenika = 0;

               
               // ################################################################
               // 1. IZRACUNAVANJE TRENUTNOG BROJA NASTAVNIKA U BAZI PODATAKA
               // 
               int UkupnoUcenika = 0;
               UcenikDBClass objUcenikDB = new UcenikDBClass(pStringKonekcije);
               UkupnoUcenika = objUcenikDB.DajUkupnoUcenikaZaStipendiju(SifraIzBazePodataka);

               // ################################################################
               // 2. MAPIRANJE SLOJEVA - uskladjivanje ID Zvanja iz raznih delova programa
               // Web servis ima d - docenta, baza podataka ima 1 - docent
               string SifraStipendijeWS = "";
               try
               {
                    MaperClass objMaper = new MaperClass(pStringKonekcije);
                SifraStipendijeWS = objMaper.DajSifruZaWebServis(SifraIzBazePodataka);
               }
               catch (Exception ex)
               {
                    Debug.WriteLine("Problem prilikom pristupa MaperClass: " + ex.Message);
               }
               // ################################################################
               // 3. IZDVAJANJE MAX BROJA NASTAVNIKA ZA ODG ZVANJE
               
                    WSKadrovskiPodaci.OgranicenjaStipendije objOgranicenja = new WSKadrovskiPodaci.OgranicenjaStipendije();
                    MaxBrojUcenika = objOgranicenja.DajMaxBrojUcenika(SifraStipendijeWS);
               



               // ################################################################
               // 4. UPOREDJIVANJE TRENUTNOG BROJA I MAX BROJA NASTAVNIKA

               if (UkupnoUcenika < MaxBrojUcenika)
               {
                    imaMesta = true;
                    Debug.WriteLine("Ima mesta za upis.");
               }
               else
               {
                    imaMesta = false;
                    Debug.WriteLine("Nema mesta za upis.");
                    Debug.WriteLine("Max broj učenika je dostignut.");
               }


               return imaMesta;
          }
     }
}
