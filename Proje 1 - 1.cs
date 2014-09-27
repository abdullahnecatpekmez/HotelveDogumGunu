using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calisma_2
{
class Tarih
{
    public int gun;
    public int ay;
    public int yil;
}
class Program
{
    static void Main(string[] args)
    {
        int[] degerler = { 5, 10, 50, 100, 500 };
        int[][][] tar_dizisi = new int[10][][];         // düzensiz dizi oluşturuluyor...
        int secim,n;
        int[] aylar = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        for (int k = 0; k < 10; k++)
        {
            tar_dizisi[k] = new int[12][];
            for (int i = 0; i < 12; i++)                //düzensiz dizinin sutun sayiları belirleniyor.
                tar_dizisi[k][i] = new int[aylar[i]];
        }
        do
        {
            menu();
            Console.Write("\tSeçiminizi giriniz:");
            secim = Convert.ToInt32(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    {
                        Console.Write("\tN sayısını giriniz:");
                        n = Convert.ToInt32(Console.ReadLine());
                        Tarih[] t = new Tarih[n];
                        d_sifirla(tar_dizisi);
                        rgun(t, tar_dizisi, n);
                        Console.WriteLine("\n\tTakvimdeki çakışma miktarı:");
                        yaz(tar_dizisi);
                    } break;
                case 2:
                    {
                        float[,] tablo = new float[11, 5];
                        d_sifirla(tar_dizisi);
                        for (int d = 0; d < 5; d++)
                        {
                            d_sifirla(tar_dizisi);
                            Tarih[] t = new Tarih[degerler[d]];
                            rgun(t, tar_dizisi, degerler[d]);
                            tablool(tar_dizisi, tablo, d);
                        }
                        yaz1(tablo);
                    } break;
                case 3:
                    {
                        Tarih[] t1 = new Tarih[120];
                        rgun2(t1);
                    } break;
            }
        } while (secim != 4);
        Console.ReadKey();
    }
    static void rgun(Tarih[] t, int[][][] d, int n)
    {
        Random rnd = new Random();
        int[] yil = { 1993, 1994, 1995 };
        for (int k = 0; k < 10; k++)
            for (int i = 0; i < n; i++)
            {
                t[i] = new Tarih();
                t[i].ay = rnd.Next(0, 12);
                if (t[i].ay == 0 || t[i].ay == 2 || t[i].ay == 4 || t[i].ay == 6 || t[i].ay == 7 || t[i].ay == 9 || t[i].ay == 11)
                    t[i].gun = rnd.Next(0, 31);
                else if (t[i].ay == 3 || t[i].ay == 5 || t[i].ay == 8 || t[i].ay == 10)
                    t[i].gun = rnd.Next(0, 30);
                else
                    t[i].gun = rnd.Next(0, 28);
                t[i].yil = rnd.Next(0, 4);
                d[k][t[i].ay][t[i].gun]++;
            }
    }
    static void yaz(int[][][] d)
    {
        int k = 0,top=0;
            for (int i = 0; i < d[k].GetLength(0); i++)
            {
                Console.WriteLine("\n");
                if (i < 9) Console.Write(" ");
                Console.Write((i + 1) + ". AY->\t");
                for (int j = 0; j < d[k][i].GetLength(0); j++)
                {
                    if (d[k][i][j] != 0)
                    {
                        Console.Write(" " + (d[k][i][j] - 1));
                        top += d[k][i][j] - 1;
                    }
                        else
                        Console.Write(" " + d[k][i][j]);
                }
            }
            Console.WriteLine("\n\n\tTOPLAM ÇAKIŞMA SAYISI:"+top+"\n\n");
    }

    static void d_sifirla(int[][][] d)
    {
        for (int k = 0; k < 10; k++)
            for (int i = 0; i < d[k].GetLength(0); i++)
            {
                for (int j = 0; j < d[k][i].GetLength(0); j++)
                        d[k][i][j] = 0;
            }
    }
    static void tablool(int[][][] d, float[,] t, int sutun)
    {
        float toplam = 0;
        for (int k = 0; k < d.GetLength(0); k++)
        {
            for (int i = 0; i < d[k].GetLength(0); i++)
            {
                for (int j = 0; j < d[k][i].GetLength(0); j++)
                    if (d[k][i][j] != 0)
                        t[k, sutun] += d[k][i][j] - 1;
            }
            toplam += t[k, sutun];
        }
        t[10, sutun] = toplam / 10;
    }
    static void yaz1(float[,] t)
    {
        string[] b = { "5", "10", "50","100","500", "", "KİŞİLER" };
        Console.WriteLine("\t"+b[5].PadRight(52, '-'));
        Console.WriteLine("\t"+b[6] + b[0].PadLeft(10, '+') + b[1].PadLeft(8, '+') + b[2].PadLeft(8, '+')+b[3].PadLeft(9,'+')+b[4].PadLeft(9,'+'));
        Console.WriteLine("\t"+b[5].PadRight(52, '-'));
        for (int i = 0; i < t.GetLength(0); i++)
        {
            if (i < 9)
                Console.Write("\t ");
            else
                Console.Write("\t");
            if (i != 10)
                Console.Write((i + 1) + ". DENEY");
            else Console.Write("ORTALAMA");
            for (int j = 0; j < 5; j++)
                Console.Write("\t" + t[i, j]);
            Console.WriteLine("\n\t" + b[5].PadRight(52, '-'));
        }
    }
    static void tablool2(int[, , ,] d, float[,] t)
    {
        float toplam = 0;
        for (int m = 0; m < 3; m++)
        {
            for (int k = 0; k < 10; k++)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 31; j++)
                        if (d[m, k, i, j] != 0)
                            t[k, m] += d[m, k, i, j] - 1;
                }
                toplam += t[k, m];
            }
            t[10, m] = toplam / 10;
            toplam = 0;
        }
    }
    static void rgun2(Tarih[] t)
    {
        Random rnd = new Random();
        float[,] tablo = new float[11, 3];
        int[, , ,] a = new int[3, 10, 12, 31];
        for (int k = 0; k < 10; k++)
            for (int i = 0; i < 120; i++)
            {
                t[i] = new Tarih();
                t[i].ay = rnd.Next(0, 12);
                if (t[i].ay == 0 || t[i].ay == 2 || t[i].ay == 4 || t[i].ay == 6 || t[i].ay == 7 || t[i].ay == 9 || t[i].ay == 11)
                    t[i].gun = rnd.Next(0, 31);
                else if (t[i].ay == 3 || t[i].ay == 5 || t[i].ay == 8 || t[i].ay == 10)
                    t[i].gun = rnd.Next(0, 30);
                else
                    t[i].gun = rnd.Next(0, 28);
                t[i].yil = rnd.Next(0, 3);
                a[t[i].yil, k, t[i].ay, t[i].gun]++;
            }
        tablool2(a, tablo);
        yaz2(tablo);
    }
    static void yaz2(float[,] t)
    {
        string[] b={"1993","1994","1995","","YILLAR"};
        Console.WriteLine("\t\t"+b[3].PadRight(35, '-'));
        Console.WriteLine("\t\t"+b[4]+b[0].PadLeft(13, '+') + b[1].PadLeft(8, '+') + b[2].PadLeft(8,'+'));
        Console.WriteLine("\t\t"+b[3].PadRight(35, '-'));
        for (int i = 0; i < t.GetLength(0); i++)
        {
            if (i < 9)
            Console.Write("\t\t ");
            else Console.Write("\t\t");
            if (i != 10)
                Console.Write((i + 1) + ". DENEY");
            else Console.Write("ORTALAMA");
            for (int j = 0; j < 3; j++)
                Console.Write("\t"+t[i,j]);
            Console.WriteLine("\n\t\t"+b[3].PadRight(35, '-'));
        }
    }
    static void menu()
    {
        Console.WriteLine("****************************MENU****************************\n");
        Console.WriteLine("\t1: Herhangi bir N değeri için...\t\t\t");
        Console.WriteLine("\t2: N=(5,10,50,100,500) için deneylerin sonuçları...");
        Console.WriteLine("\t3: N=120 için yıllara göre deney sonuçları...");
        Console.WriteLine("\t4: ÇIKIŞ...\n");
        Console.WriteLine("****************************MENU****************************\n");
    }
}
}
