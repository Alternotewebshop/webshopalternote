using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop_Alternote.Business
{
    public class Artikel
    {
        private int _artikelid;
        private string _naam;
        private string _omschrijving;
        private int _voorraad;
        private double _prijs;
        private string _foto;

        public int artikelID
        {
            set { _artikelid = value; }
            get { return _artikelid; }
        }

        public string Naam
        {
            set { _naam = value; }
            get { return _naam; }
        }

        public string Omschrijving
        {
            set { _omschrijving = value; }
            get { return _omschrijving; }
        }
        public int Voorraad
        {
            set { _voorraad = value; }
            get { return _voorraad; }
        }

        public double Prijs  
        {
            set { _prijs = value; }
            get { return _prijs; }
        }

        public string Foto
        {
            set { _foto = value; }
            get { return _foto; }
        }

    }
}