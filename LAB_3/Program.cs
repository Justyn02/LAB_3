using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("App"), InternalsVisibleTo("GUI")]

namespace LAB_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int w1 = 500;
            int k1 = 500;
            int w2 = 500;
            int k2 = 500;

            Macierz macierzA = new Macierz(w1, k1);
            Macierz macierzB = new Macierz(w2, k2);
            macierzA.GenerujMacierz();
            macierzB.GenerujMacierz();

            double[] czasyThread = new double[5];
            double[] czasyParallel = new double[5];

            int liczbaProb = 5;

            int[] liczbaWatku = { 1, 2, 4, 8, 16 };

            for (int i = 0; i < liczbaWatku.Length; i++)
            {
                double sumaThread = 0;
                double sumaParallel = 0;

                for (int j = 0; j < liczbaProb; j++)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    Stopwatch stopwatch2 = new Stopwatch();
                    stopwatch.Start();
                    Macierz wynikThread = Macierz.PomnozWielowatkowoT(macierzA, macierzB, liczbaWatku[i]);
                    stopwatch.Stop();
                    sumaThread += stopwatch.ElapsedMilliseconds;

                    stopwatch2.Start();
                    Macierz wynikParallel = Macierz.PomnozWielowatkowoP(macierzA, macierzB, liczbaWatku[i]);
                    stopwatch2.Stop();
                    sumaParallel += stopwatch2.ElapsedMilliseconds;
                }

                czasyThread[i] = sumaThread / liczbaProb;
                czasyParallel[i] = sumaParallel / liczbaProb;
            }

            Console.WriteLine("Liczba wątków |  Średni czas (Thread)   |   Średni czas (Parallel)");
            for (int i = 0; i < liczbaWatku.Length; i++)
            {
                Console.WriteLine($"{liczbaWatku[i],-13} | {czasyThread[i],20:F2} ms | {czasyParallel[i],20:F2} ms");
            }
        }
    }
}

/*using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Diagnostics;
using System;

namespace LAB_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Podaj ilość wierszy dla pierwszej macierzy: ");
            int w1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj ilość kolumn dla pierwszej macierzy: ");
            int k1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj ilość wierszy dla drugiej macierzy: ");
            int w2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj ilość kolumn dla drugiej macierzy: ");
            int k2 = int.Parse(Console.ReadLine());
            
            Macierz macierzA = new Macierz(w1, k1);
            Macierz macierzB = new Macierz(w2, k2);
            */
    /*  Macierz macierzA = new Macierz(200, 200);
      Macierz macierzB = new Macierz(200, 200);
      Console.WriteLine("Pierwsza macierz:");
      macierzA.GenerujMacierz();
     // macierzA.Wyswietl();*/

      /*Console.WriteLine("Druga macierz:");
      macierzB.GenerujMacierz();
*/      // macierzB.Wyswietl();

      //Console.WriteLine("Podaj ilość wątków do obliczenia dla dzielenia na elementy: ");
      //int numThreadsElements = int.Parse(Console.ReadLine());
  /*    int numThreadsElements = 10;
      try
      {
          Stopwatch stopwatch = new Stopwatch();
          stopwatch.Start();

          Macierz wynik = Macierz.PomnozWielowatkowoT(macierzA, macierzB, numThreadsElements);

          stopwatch.Stop();

          Console.WriteLine("Wynik mnożenia macierzy (dzielenie na elementy):");
          //wynik.Wyswietl();
          Console.WriteLine($"Czas wykonania operacji (wielowątkowo): {stopwatch.ElapsedMilliseconds} ms");

*/


  /*        Stopwatch stopwatch2 = new Stopwatch();
          stopwatch2.Start();

          Macierz wynik2 = Macierz.PomnozWielowatkowoP(macierzA, macierzB, numThreadsElements);

          stopwatch2.Stop();

          Console.WriteLine("Wynik mnożenia macierzy (dzielenie na elementy):");
          //wynik.Wyswietl();
          Console.WriteLine($"Czas wykonania operacji (wielowątkowo): {stopwatch.ElapsedMilliseconds} ms");

      }
      catch (ArgumentException e)
      {
          Console.WriteLine(e.Message);
      }
  }
}
}
  */