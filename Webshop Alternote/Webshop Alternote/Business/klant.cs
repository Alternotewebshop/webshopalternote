using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop_Alternote.Business
{
    public class Klant
    {
        private int _klantid;
        private string _naam;
        private string _voornaam;
        private string _adres;
        private string _postcode;
        private string _gemeente;
        private string _mail;

        public int KlantID
        {
            set { _klantid = value;}
            get { return _klantid; }
        }

        public string Naam
        {
            set { _naam = value; }
            get { return _naam; }
        }

        public string Voornaam
        {
            set { _voornaam = value; }
            get { return _voornaam; }
        }
        public string Adres
        {
            set { _adres = value; }
            get { return _adres; }
        }
        public string Postcode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        public string Gemeente
        {
            set { _gemeente = value; }
            get { return _gemeente; }
        }
        public string Mail
        {
            set { _mail = value; }
            get { return _mail; }
        }




    }
}