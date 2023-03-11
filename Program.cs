using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Reflection;

namespace karacsonyCLI_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<NapiMunka> munkak = new List<NapiMunka>();
            StreamReader sr = new StreamReader("Datas\\diszek.txt");

            while (!sr.EndOfStream)
            {
                munkak.Add(new NapiMunka(sr.ReadLine()));
            }
            sr.Close();

            // Console.WriteLine($" {munkak.Count} napig készültek a díszek.");

 //--------------------------------------------------------------------------------------------------------

             /* 4. Határozza meg és írja ki a képernyőre a minta szerint, hogy összesen hány karácsonyi díszt
                   készített a hölgy! */

            int darab = 0;
            foreach (var db in munkak)
            {
             darab += db.HarangKesz + db.FenyofaKesz + db.AngyalkaKesz;
            }
            Console.WriteLine($"4. feladat: Összesen {darab} db dísz készült.");

//-----------------------------------------------------------------------------------------------------------

            /* 5. Állapítsa meg, hogy volt-e olyan nap, amikor a hölgy egyetlen díszt sem készített!
                  A keresést ne folytassa, ha választ meg tudja adni! A megállapítását írja a képernyőre!*/

            int darab2 = 0;
            foreach (var db in munkak)
            {
                if (db.HarangKesz + db.FenyofaKesz + db.AngyalkaKesz == 0)
                {
                    darab2++;
                    Console.WriteLine("5. feladat: Volt olyan nap, mikor egyetlen dísz sem készült el");
                }
            }

//------------------------------------------------------------------------------------------------------------

               /* 6. Kérjen be a felhasználótól egy 1 és 40 közé eső számot (a határokat is beleértve)! Ismételje
                     addig a nap számának bekérését, míg érvényes értéket nem ad meg a felhasználó! Ha nem
                     tudta megoldani az adatbevitelt, akkor a feladat további részében dolgozzon a 15-ös
                     számmal! Határozza meg, és írja a képernyőre, hogy az adott nap végén melyik díszből
                     hány maradt készleten! */

                Console.WriteLine();
                Console.WriteLine("6. feladat:");
                                
                int harangkeszlet = 0;
                int angyalkakeszlet = 0;
                int fenyofakeszlet = 0;
                int nap;
            do
            {
                Console.Write(" Adja meg a keresett napot [1...40] :");
                //  int.TryParse(Console.ReadLine(), out nap);
                 nap= Convert.ToInt32(Console.ReadLine());

                foreach(var db in munkak)
                {
                    if (db.Nap <= nap)
                    {
                        harangkeszlet += db.HarangKesz + db.HarangEladott;
                        angyalkakeszlet += db.AngyalkaKesz + db.AngyalkaEladott;
                        fenyofakeszlet += db.FenyofaKesz + db.FenyofaEladott;
                    }
                }
            }
            while (nap < 1 && nap > 40);
               
                Console.WriteLine($"A(z) {nap}. napon {harangkeszlet} harang," +
                                  $" {angyalkakeszlet} angyalka és {fenyofakeszlet} fenyőfa maradt készleten.");

            //----------------------------------------------------------------------------------------------------------------------

            /* 7. Határozza meg, és írja a képernyőre, hogy a 40 nap alatt melyik díszből sikerült eladni
                  a legtöbbet!Az eladott mennyiséget is jelenítse meg!Ha több díszből is egyformán
                  a legtöbb lett eladva, akkor mindegyiket jelenítse meg!*/

            Console.WriteLine();
            int harangEladOssz = 0;
            int angyalkaEladOssz = 0;
            int fenyofaEladOssz = 0;
            int maxdarab = 0;

            foreach (var db in munkak)
            {
                harangEladOssz -= db.HarangEladott;
                angyalkaEladOssz -= db.AngyalkaEladott;
                fenyofaEladOssz -= db.FenyofaEladott;


                if(harangEladOssz>=angyalkaEladOssz || harangkeszlet>=fenyofaEladOssz)
                {
                    maxdarab=harangEladOssz;
                }
                else if(angyalkaEladOssz>=fenyofaEladOssz || angyalkaEladOssz>=harangEladOssz)
                {
                    maxdarab=angyalkaEladOssz;
                }
                else if(fenyofaEladOssz>=harangEladOssz || fenyofaEladOssz>=angyalkaEladOssz)
                {
                     maxdarab= fenyofaEladOssz;
                }
             /* Console.WriteLine("harang eladott{0}", harangEladOssz);
                Console.WriteLine("angyal eladott{0}", angyalkaEladOssz);
                Console.WriteLine("fenyő eladott{0}", fenyofaEladOssz);*/

                
            }
            Console.WriteLine($"7. feladat: Legtöbbet eladott dísz:{maxdarab} darab");

            if(harangEladOssz==maxdarab) { Console.WriteLine("\tHarang"); }
            if (angyalkaEladOssz == maxdarab) { Console.WriteLine("\tAngyal"); }
            if (fenyofaEladOssz == maxdarab) { Console.WriteLine("\tFenyofa"); }

            //-------------------------------------------------------------------------------------------------------------

            /*  8. A NapiMunka osztály NapiBevetel() metódusának felhasználásával válogassa ki és írja
                   ki a bevetel.txt fájlba azokat a napi bevételeket, melyek elérték a 10 000 forintot!

                   Minden sorban jelenjen meg a nap száma és az aznapi bevétel egymástól kettősponttal
                   elválasztva.
                   A fájl utolsó sorában jelenítse meg, hogy hány olyan nap volt, amikor a bevétel
                   elérte a 10 000 forintot! „X napon volt legalább 10000 Ft a bevétel.” */

            Console.WriteLine();
            Console.WriteLine("8. feladat: a 'bevetel.txt' állományban van.");
            StreamWriter sw = new StreamWriter("bevetel.txt");            
            int db2 = 0;
            foreach (var db in munkak)
            {
                if (db.NapiBevetel() >= 10000)
                {
                    db2++;
                    sw.WriteLine($"{db.Nap} : {db.NapiBevetel()}");
                }               
            } sw.WriteLine($"{db2} napon volt legalább 10.000 Ft a bevétel.");
            sw.Close();

            //-----------------------------------------------------------------------------------------------------------------------

            /* 9. Készítsen grafikus alkalmazást, amelynek projektjét karacsonyGUI néven mentse el!
                  A grafikus alkalmazást a hölgy arra szeretné használni, hogy a későbbiek során ne fájlba
                  kelljen írnia az adatokat, hanem helyette egy könnyen kezelhető grafikus felületen tudja
                  megadni a napi zárás adatait.A grafikus felületet csak az angyalkák számának kezeléséhez
                  kell elkészítenie. Az alkalmazásban megadhatja, hogy melyik napon hány angyalka készült
                  el és mennyit sikerült eladni.Ezek alapján az alkalmazásnak a készleten lévő angyalkák
                  számát is kell számolnia, és meg kell jelenítenie. */


        } 

    }

        }


