using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class UcenikListaClass
    {

        // atributi
        private List<UcenikClass> _listaUcenika; 

        // property
        public List<UcenikClass> ListaUcenika
        {
            get
            {
                return _listaUcenika;
            }
            set
            {
                if (this._listaUcenika != value)
                    this._listaUcenika = value;
            }
        }

        // konstruktor
        public UcenikListaClass()
        {
               _listaUcenika = new List<UcenikClass>(); 

        }

        // privatne metode

        // javne metode
        public void DodajElementListe(UcenikClass noviUcenikObject)
        {
               _listaUcenika.Add(noviUcenikObject);
        }

        public void ObrisiElementListe(UcenikClass ucenikZaBrisanjeObject)
        {
               _listaUcenika.Remove(ucenikZaBrisanjeObject);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
               _listaUcenika.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(UcenikClass stariUcenikObject, UcenikClass noviUcenikObject)
        {
            int indexStarogUcenika = 0;
               indexStarogUcenika = _listaUcenika.IndexOf(stariUcenikObject);
               _listaUcenika.RemoveAt(indexStarogUcenika);
               _listaUcenika.Insert(indexStarogUcenika, noviUcenikObject);   
        }

           
    }
}
