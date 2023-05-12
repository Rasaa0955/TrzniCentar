using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrzniCentar
{
    class TrzniCentar
    {
       public string nazivTrznogCentra;
       public string adresaTrznogCentra;
       public string radnoVreme;
        public TrzniCentar(string naziv,string adresa,string radno)
        {
            this.nazivTrznogCentra = naziv;
            this.adresaTrznogCentra = adresa;
            this.radnoVreme = radno;
        }
        List<Prodavnica> prodavnice = new List<Prodavnica>();
        public void Addprodavnicu(Prodavnica prodavnica)
        {
            prodavnice.Add(prodavnica);
        }
        public void PretragaProdavnica(string nazivProdavnice)
        {
            foreach(Prodavnica prodavnica in prodavnice)
            {
                if (nazivProdavnice == prodavnica.nazivProdavnice)
                {
                    Console.WriteLine("Imamo {0} u trznom cetnru {1}",nazivProdavnice,nazivTrznogCentra);
                    break;
                }
                else Console.WriteLine("Ne postoji {0} u trznom centru {1}",nazivProdavnice,nazivTrznogCentra);
            }
        }
        public void IspisSvihProdavnica()
        {
            int i = 1;
            foreach(Prodavnica prodavnica in prodavnice)
            {
                Console.WriteLine("{0}-{1}",prodavnica.nazivProdavnice,prodavnica.kategorija);
                i++;
            }
        }
     
    }
    class Prodavnica
    {
        public string nazivProdavnice;
        public KategorijaProdavnica kategorija;
        string randoVreme;
        public Prodavnica(string naziv,KategorijaProdavnica kateg,string radnoVreme)
        {
            this.nazivProdavnice = naziv;
            this.kategorija = kateg;
            this.randoVreme  = radnoVreme;

        }
        List<Proizvod> proizvodi = new List<Proizvod>();
        public void AddProizvod(Proizvod proizvod)
        {
            proizvodi.Add(proizvod);
        }
        public void Ipisi()
        {
            foreach(Proizvod proiz in proizvodi)
            {
                Console.WriteLine();
            }
        }
        public void DostupnostPorizvoda(string brand , KategorijaProizvoda kategorija )
        {
           foreach(Proizvod proizvod in proizvodi)
           {
                if(brand==proizvod.brand && kategorija == proizvod.vrstaProizvoda)
                {
                    Console.WriteLine("Dostupnost proizvoda={0}", proizvod.dostupnost);
                }
           }
        }
        public void Popust(KategorijaProdavnica kategorija)
        {
            if (KategorijaProdavnica.Obuca == kategorija)
            {
                Console.WriteLine("Ove nedelje je obuca na popustu");
                Console.WriteLine("i imate 10% popust na njih");
            }
        }
    }
    class Proizvod
    {
        public string brand;
        public int cena;
        public KategorijaProizvoda vrstaProizvoda;
        public bool dostupnost;
        public Proizvod(string brand, int cena,KategorijaProizvoda vrsta)
        {
            this.brand = brand;
            this.cena = cena;
            this.vrstaProizvoda = vrsta;
            dostupnost = true;
        }
    }
    class Kupac
    {
        string imeKupca;
        string prezimeKupca;
        int brojMobilnog;
        int ukupnaCena = 0;
        public Kupac(string ime,string prezime,int brojMob)
        {
            this.imeKupca = ime;
            this.prezimeKupca = prezime;
            this.brojMobilnog = brojMob;
        }
        List<Proizvod> korpa = new List<Proizvod>();
        public void DodajProizvodUkorpu(Proizvod proizvod)
        {
            korpa.Add(proizvod);
            proizvod.dostupnost = false;
        }
        public void UkupnaCenaIzKorpe()
        {
            bool popust = false;
           
            foreach(Proizvod proizvod in korpa)
            {
                if (proizvod.vrstaProizvoda == KategorijaProizvoda.Patike)
                {
                    proizvod.cena =proizvod.cena-( proizvod.cena / 10);
                    popust = true;
                }
                ukupnaCena = ukupnaCena + proizvod.cena;
            }
            if (popust) Console.WriteLine("Imate popust na obucu ove nedelje i ukupna cena sa popustom je {0}",ukupnaCena);
            else Console.WriteLine("Nemate popust ni na jedan artikal i ukupna cena je {0}",ukupnaCena);
        }
        public void Racun()
        {
            foreach(Proizvod proizvod in korpa)
            {
                Console.WriteLine("Artikal branda {0}  i vrstaArtikla je {1} i njegova cena je {2}",proizvod.brand,proizvod.vrstaProizvoda,proizvod.cena);
                ukupnaCena = ukupnaCena + proizvod.cena;
            }
            Console.WriteLine("Ukupna cena vasih proizvoda je {0}",ukupnaCena);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            TrzniCentar trznicentar = new TrzniCentar("Promenada", "Bulevar Oslobodjenja", "20-h");
            trznicentar.Addprodavnicu(new Prodavnica("Sport Vision", KategorijaProdavnica.Obuca, "20-h"));
            trznicentar.Addprodavnicu(new Prodavnica("Feshion&Frends", KategorijaProdavnica.Odeca, "20-h"));
            trznicentar.Addprodavnicu(new Prodavnica("PanSport", KategorijaProdavnica.Suplementacija, "20-h"));
            trznicentar.IspisSvihProdavnica();
            trznicentar.PretragaProdavnica("Sport Vision");
            Prodavnica prodavnica1 = new Prodavnica("Gigatron", KategorijaProdavnica.Elektronika, "20-h");
            prodavnica1.AddProizvod(new Proizvod("Samsung", 1000, KategorijaProizvoda.Televizor));
            prodavnica1.Popust(KategorijaProdavnica.Obuca);
            Kupac kupac1 = new Kupac("Rasa", "Aradjanin", 0677296951);
            Proizvod proizvod1 = new Proizvod("Gucci", 500, KategorijaProizvoda.Duks);
            Proizvod proizvod2 = new Proizvod("Nike", 500, KategorijaProizvoda.Patike);
            Proizvod proizvod3 = new Proizvod("Addidas", 500, KategorijaProizvoda.Majica);
            kupac1.DodajProizvodUkorpu(proizvod1);
            kupac1.DodajProizvodUkorpu(proizvod2);
            kupac1.DodajProizvodUkorpu(proizvod3);
            kupac1.UkupnaCenaIzKorpe();


            Console.ReadLine();
          
        }
    }
    enum KategorijaProdavnica
    {
        Odeca,
        Obuca,
        Elektronika,
        Hrana,
        Suplementacija
    }
    enum KategorijaProizvoda
    {
        Duks,
        Majica,
        Sorc,
        Patike,
        Papuce,
        Laptop,
        Televizor,
        Burger,
        Pizza,
        Protein,
        Kreatin
    }
}
