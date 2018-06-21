using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop_Alternote.Persistence;

namespace Webshop_Alternote.Business
{
    public class Controller
    {
        //Connectie persistencelaag
        PersistenceCode _persistence = new PersistenceCode();

        //--------------------------------------------------
        //Method die nodig zijn voor de login te verifiëren
        //--------------------------------------------------
        public bool ControleerBestaanKlant(string gebruikersnaam, string wachtwoord)
        {
            return _persistence.CheckBestaanKlant(gebruikersnaam, wachtwoord);
        }

        public int OphalenIDvangebruiker(string gebruikersnaam)
        {
            return _persistence.OphalenIDMetGebruikersnaam(gebruikersnaam);
        }


        //------------------------------------------------------------------------------------------------------
        //Methods die nodig zijn voor catalogus en toevoeg pagina door te geven vanuit de  persistencecode
        //------------------------------------------------------------------------------------------------------

        //Het ophalen van alle artikels
        public List<Artikel> SetAlleArtikels()
        {
            return _persistence.HaalAlleArtikelsOp();
        }
        
        //Eén artikel laten zien
        public Artikel SetEénArtilel(int artikelID)
        {
            return _persistence.HaalEénArtikelOp(artikelID);
        }

        //Controleren of het artikel al in het winkelmandje zit
        public bool SetControleArtikelInHetmandje(int klantid,int artikelid)
        {
            return _persistence.InHetMandjeOfNiet(klantid,artikelid);
        }
       

        //-------------------------------------------------------------------------------------------
        //Methods die we nodig hebben om de gegevens in de winkelmand pagina te tonen en te berekenen
        //-------------------------------------------------------------------------------------------

        //Gegevens van de klant tonen in de winkelmand pagina
        public Klant KlantGegevensOphalen(int klantid)
        {
            return _persistence.HaalKlantOP(klantid);
        }

        //De Gridview in de winkelpagina vullen met de gegevens die staan in de database
        public List<Winkelmand> WinkelmandInDeGridviewTonen(int klantid)
        {
            return _persistence.OphalenWinkelmand(klantid);
        }

        //Controleren of het winkelmandje leeg is 
        public bool ControlerenOfDeWinkelmandLeegIs(int klantid)
        {
            return _persistence.LeegOfNiet(klantid);
        }

        //Vullen van de winkelmand vanuit de catalogus
        public void ArtikelToevoegenAanWinkelmand(int klantid,int artikelid,int aantal)
        {
             _persistence.VulWinkelmandje(klantid, artikelid, aantal);
        }

        //aftrekken van de voorraad
        public void UpdatenVoorraadNaWeiziging(int artikelid, int aantal)
        {
            _persistence.VoorraadAftrekkenNaToevoegen(artikelid, aantal);
        }

        //Toevoegen van de voorraad na verwijderen uit winkelmand
        public void ToevoegenNaVerwijderenUitWinkelmand(int artikelid, int aantal)
        {
            _persistence.VoorraadTerugToevoegen(artikelid, aantal);
        }

        //controleren of de invoer correct is en of de voorraad groot genoeg is
        public string Checkgetal(int klantid,string aantalbesteld)
        {
            if (int.TryParse(aantalbesteld, out int juistgetal))
            {
                if (juistgetal > 0)
                {
                    if (_persistence.HaalEénArtikelOp(klantid).Voorraad >= juistgetal)
                    {
                        return "ok";
                    }
                    else
                    {
                        return "Het getal is groter dan de voorraad.";
                    }            
                }
                else
                {
                    return "De invoer is geen positief getal";
                }
            }
            else
            {
                return "De invoer was geen geheel getal";
            }
        }

        //prijs binnenhalen van alle artikels die in de winkelmand zitten
        public double BedragAllesVanWinkelmand(int klantid)
        {
            return _persistence.TotalePrijsWinkelmand(klantid);
        }

        //verwijderen van een artikel uit de winkelmand
        public void VerwijderenArtikelUitWinkelmand(int klantid, int artikelid)
        {
            _persistence.VerwijderWinkelmand(klantid, artikelid);
        }



        //---------------------------------------------------------------------------------------------
        //Methods die we nodig hebben om het order te berekenen en in de database de tabellen te vullen
        //---------------------------------------------------------------------------------------------

        public void MakenVanOrder(int klantid)
        {
            _persistence.tblOrdersInvullen(klantid);
        }

        public double OphalenTotalePrijs(int klantid)
        {
            return _persistence.TotalePrijsWinkelmand(klantid);
        }

        public ProductPerOrder OphalenInformatieProductPerOrder(int klantid)
        {
            return _persistence.HaalOrderInfoOp(klantid);
        }

        public void OpslaanTBLOrderinformatie(int klantid)
        {
            _persistence.tblOrderInformatieInvullen(klantid);
        }

        public int OphalenLengteWinkelmand(int klantid)
        {
             return _persistence.LengteWinkelmand(klantid);
        }

        public void VerwijderenArtikelsUitWinkelmand(int klantid,int artikelid)
        {
            _persistence.VerwijderWinkelmand(klantid,artikelid);
        }

        public int OphalenLaatsteOrderID()
        {
            return _persistence.OphalenLaatsteOrder();
        }

        public bool NogArtikelsInHetMandje(int klantid)
        {
            return _persistence.ControleerNogInHetMandje(klantid);
        }

        public void VerwijderenArtikelenMandje(int klantid)
        {
            _persistence.VerwijderRowInWinkelmand(klantid);
        }






        public void VerstuurEmail(int klantID,string bericht)
        {
            _persistence.SendEmail(klantID, bericht);
        }
    }
}