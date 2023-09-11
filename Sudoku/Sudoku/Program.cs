using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //3.feladat
            List<Feladvany> feladvanyok = new List<Feladvany>();
            
            foreach (string feladvany in File.ReadAllLines("feladvanyok.txt"))
            {
                feladvanyok.Add(new Feladvany(feladvany));
            }
            Console.WriteLine($"3. feladat: Beolvasva {feladvanyok.Count} feladvány");

            //4.feladat
            int meret;
            do
            {
                Console.Write("\n4. feladat: Kérem a feladvány méretét [4..9]: ");
                meret = Convert.ToInt32(Console.ReadLine());
            } while (meret < 4 || meret > 9);
            int szam = 0;
            foreach (var number in feladvanyok)
            {
                if (number.Meret == meret)
                {
                    szam++;
                }
            }
            Console.WriteLine($"{meret}x{szam} méretű feladványból {szam} darab van tárolva");

            //5.feladat
            Random veletlenszam = new Random();
            int valasztott;
            do
            {
                valasztott = veletlenszam.Next(0, feladvanyok.Count);
            } while (feladvanyok[valasztott].Meret != meret);
            Console.WriteLine("\n5. feladat: A kiválasztott feladvány:\n", feladvanyok[valasztott].Kezdo);

            //6.feladat
            int feltotottSzam = 0;
            foreach(char szamjegy in feladvanyok[valasztott].Kezdo)
            {
                if(szamjegy != '0')
                {
                    feltotottSzam++;
                }
            }
            double szazalek = Math.Round((double)100 * feltotottSzam / feladvanyok[valasztott].Kezdo.Length);
            Console.WriteLine($"\n6. feladat: A feladvány kitöltöttsége: {szazalek}%");
            //7.feladat
            Console.WriteLine("\n7. feladat: A feladvány kirajzolva:");
            feladvanyok[valasztott].Kirajzol();
            //8.feladat
            StreamWriter kiir = new StreamWriter("sudoku" + meret + ".txt");
            foreach (var szamok in feladvanyok)
            {
                if (szamok.Meret == meret)
                {
                    kiir.WriteLine(szamok.Kezdo);
                }
            }
            kiir.Close();

            Console.WriteLine($"\n8. feladat: sudoku{meret}.txt állomány {szam} darab feladvánnyal létrehozva");
            Console.ReadKey();
        }
        
    }

}
