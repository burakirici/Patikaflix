using System;
using System.Collections.Generic;
using System.Linq;

class Dizi
{
    public string Ad { get; set; }
    public string Tur { get; set; }
    public string Yoneten { get; set; }
    public int Yil { get; set; }
    public string IlkPlatform { get; set; }

    public Dizi(string ad, string tur, string yoneten, int yil, string ilkPlatform)
    {
        Ad = ad;
        Tur = tur;
        Yoneten = yoneten;
        Yil = yil;
        IlkPlatform = ilkPlatform;
    }
}

class KomediDizi
{
    public string Ad { get; set; }
    public string Tur { get; set; }
    public string Yoneten { get; set; }

    public KomediDizi(string ad, string tur, string yoneten)
    {
        Ad = ad;
        Tur = tur;
        Yoneten = yoneten;
    }

    public override string ToString()
    {
        return $"Ad: {Ad}, Tür: {Tur}, Yönetmen: {Yoneten}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Dizi> diziListesi = new List<Dizi>();
        string devam = "E";

        while (devam.ToUpper() == "E")
        {
            Console.Write("Dizi Adı: ");
            string ad = Console.ReadLine();

            Console.Write("Dizi Türü: ");
            string tur = Console.ReadLine();

            Console.Write("Yönetmen: ");
            string yoneten = Console.ReadLine();

            Console.Write("Yapım Yılı: ");
            int yil = int.Parse(Console.ReadLine());

            Console.Write("Yayınlandığı İlk Platform: ");
            string ilkPlatform = Console.ReadLine();

            diziListesi.Add(new Dizi(ad, tur, yoneten, yil, ilkPlatform));

            Console.Write("Başka bir dizi eklemek ister misiniz? (E/H): ");
            devam = Console.ReadLine();
        }

        // Komedi türündeki dizileri seç ve yeni listeye ekle
        List<KomediDizi> komediListesi = diziListesi
            .Where(d => d.Tur.ToLower().Contains("komedi"))
            .Select(d => new KomediDizi(d.Ad, d.Tur, d.Yoneten))
            .ToList();

        // Listeyi önce dizi adı, sonra yönetmen adına göre sırala
        var siraliKomediListesi = komediListesi
            .OrderBy(k => k.Ad)
            .ThenBy(k => k.Yoneten)
            .ToList();

        // Listeyi ekrana yazdır
        Console.WriteLine("\nSıralı Komedi Dizileri:");
        foreach (var komediDizi in siraliKomediListesi)
        {
            Console.WriteLine(komediDizi);
        }
    }
}
