using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Konuk
    {
        public string ad;
        public string soyad;
        public string dil;
        public int no=-1;
        public int dno;
    }
    class Otel
    {
        public string ad;
        public int kont;
        public float oran;
        public int max;
    }
    
    class Program
    {   
    static void otel(Otel[] o,int sayi)
    {
        for (int i = 0; i < sayi; i++)
            {
                o[i] = new Otel();
                Console.Write("\t"+(i+1)+". Otelin ismini giriniz:");
                o[i].ad=Console.ReadLine();
                Console.Write("\t"+(i + 1) + ". Otelin kapasitesini giriniz:");
                o[i].kont =Convert.ToInt32(Console.ReadLine());
            }    
    }
    static void konuk(Konuk[] k, int N)
    {
        int i, j, x;
        string[] isim = { "Ali", "Veli", "Aykut", "Orhan", "Müslüm", "Ferdi", "İbrahim", "Hakan", "Güçlü", "Emrah", "Kamuran", "Gülden", "Zerrin", "Şaban", "Kemal", "Tuncay", "Mehmet", "Emel", "Bülent", "Cüneyt" };
        string[] soyad = { "Kurt", "Yılmaz", "Gencebay", "Kocaman", "Uygun", "Tatlıses", "Gürses", "Taşıyan", "Kaya", "Şanlı", "Şentürk", "Korkmaz", "Günok", "Topuz", "Topal", "Demirel", "Pekmez", "Özkan", "Gönül", "Kaldırım" };
        string[] dil = { "TR", "ENG", "GER", "FRE", "JAP", "CHN", "RUS" };
        Random rnd = new Random();
        for (int sayi = 0; sayi < N; sayi++)
        {
            k[sayi] = new Konuk();
            i = rnd.Next(0, 20);
            j = rnd.Next(0, 20);
            x = rnd.Next(0, 7);
            k[sayi].ad = isim[i];
            k[sayi].soyad = soyad[j];
            k[sayi].dil = dil[x];
            k[sayi].dno = x;
        }
    }
    static void doluluk(Otel[] o)
    {
        for (int i = 0; i < o.GetLength(0); i++)
        {
            o[i].oran = (float)((100 * o[i].max) / o[i].kont);
        }
    }
    static void ayar(Otel[] o, int n)
    {
        float min;
        int x=0,j;
        for (int i = 0; i < n; i++)
        {
            min = 100;
            for (j = 0; j < o.GetLength(0); j++)
                if (o[j].oran <= min)
                {
                    min = o[j].oran;
                    x=j;
                }   
            o[x].max++;
            doluluk(o);
        }
    }
    static void say(Konuk[] k, int[] d)
    {
        for (int i = 0; i < k.GetLength(0); i++)
            d[k[i].dno]++;
    }
    static void ata(Konuk[] k, Otel[] o)
    {
        int s =0;
        for (int i = 0; i < o.GetLength(0); i++)
        {
            for (int j = 0; j < o[i].max; j++)
            {
                k[s].no = i;
                s++;
            }
        }
    }
    static void yaz(Otel[] o,Konuk[] k)
    {
        string[] b = { "AD", "SOYAD", "DİL", "" };

        for (int i = 0; i < o.GetLength(0); i++)
        {
            Console.WriteLine("\t"+o[i].ad+" Otelinde kalan konuklar");
            Console.WriteLine("\t\t"+b[3].PadRight(35, '-'));
            Console.WriteLine("\t\t"+b[0].PadRight(15, '+') + b[1].PadRight(15, '+') + b[2].PadRight(5,'+'));
            Console.WriteLine("\t\t"+b[3].PadRight(35, '-'));
            for (int j = 0; j < k.GetLength(0); j++)
            {
                if (k[j].no == i)
                {
                    Console.WriteLine("\t\t" + k[j].ad.PadRight(15) + k[j].soyad.PadRight(15) + k[j].dil.PadRight(15));
                    Console.WriteLine("\t\t" + b[3].PadRight(35, '-'));
                }
            }
            Console.WriteLine("\n");
        }
            
    }
    static int toplam(Otel[] o)
    {
        int t = 0;
        for (int i = 0; i < o.GetLength(0); i++)
            t += o[i].kont;
        return t;
    }
    static void Main(string[] args)
        {
            int top=0;
            int[] d = new int[7];
            Console.Write("\tOtel sayısını giriniz:");
            int sayi = Convert.ToInt32(Console.ReadLine());
            Otel[] o = new Otel[sayi];
            otel(o, sayi);
            top = toplam(o);
            Console.Write("\tKonuk sayısını giriniz:");
            sayi = Convert.ToInt32(Console.ReadLine());
            while (sayi > top)
            {
                Console.Write("\tLimiti aştınız... Lütfen konuk sayısını (0-{0}) arasında giriniz:", top+1);
                sayi = Convert.ToInt32(Console.ReadLine());
            }
            Konuk[] k = new Konuk[sayi];
            Console.WriteLine("\n\n");
            konuk(k, sayi);
            ayar(o, sayi);
            say(k, d);
            ata(k, o);
            yaz(o, k);
            Console.ReadKey();
        }
    }
}
