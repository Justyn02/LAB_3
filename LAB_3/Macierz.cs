using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace LAB_3
{
    internal class Macierz
    {
        public int w;
        public int k;
        public int[,] wartosc;

        public Macierz() { }
        public Macierz(int W, int K)
        {
            w = W;
            k = K;
            wartosc = new int[w, k];
        }

        public void GenerujMacierz()
        {
            Random random = new Random();

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    wartosc[i, j] = random.Next(0, 11);
                }
            }
        }

        public void Wyswietl()
        {
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Console.Write(wartosc[i, j]);
                    Console.Write("  ");
                }
                Console.WriteLine("\n");
            }
        }

        public static Macierz Pomnoz(Macierz macierzA, Macierz macierzB)
        {
            if (macierzA.k != macierzB.w)
            {
                throw new ArgumentException("Niepoprawne wymiary macierzy do mnożenia.");
            }

            Macierz wynikowa = new Macierz(macierzA.w, macierzB.k);

            for (int i = 0; i < macierzA.w; i++)
            {
                for (int j = 0; j < macierzB.k; j++)
                {
                    int suma = 0;
                    for (int k = 0; k < macierzA.k; k++)
                    {
                        suma += macierzA.wartosc[i, k] * macierzB.wartosc[k, j];
                    }
                    wynikowa.wartosc[i, j] = suma;
                }
            }

            return wynikowa;
        }

        public static Macierz PomnozWielowatkowoT(Macierz macierzA, Macierz macierzB, int numThreads)
        {
            if (macierzA.k != macierzB.w)
            {
                throw new ArgumentException("Niepoprawne wymiary macierzy do mnożenia.");
            }

            Macierz wynikowa = new Macierz(macierzA.w, macierzB.k);

            Thread[] threads = new Thread[numThreads];

            int elementsPerThread = (macierzA.w * macierzB.k) / numThreads; 

            for (int t = 0; t < numThreads; t++)
            {
                int startIdx = t * elementsPerThread; 
                int endIdx = (t + 1) * elementsPerThread; 

                threads[t] = new Thread(() =>
                {
                    for (int idx = startIdx; idx < endIdx; idx++)
                    {
                        int i = idx / macierzB.k; // Wiersz 
                        int j = idx % macierzB.k; // Kolumna 

                        int suma = 0;
                        for (int k = 0; k < macierzA.k; k++)
                        {
                            suma += macierzA.wartosc[i, k] * macierzB.wartosc[k, j];
                        }
                            wynikowa.wartosc[i, j] = suma; 
                    }
                });

                threads[t].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return wynikowa;
        }
        public static Macierz PomnozWielowatkowoP(Macierz macierzA, Macierz macierzB, int numThreads)
        {
            if (macierzA.k != macierzB.w)
            {
                throw new ArgumentException("Niepoprawne wymiary macierzy do mnożenia.");
            }

            Macierz wynikowa = new Macierz(macierzA.w, macierzB.k);

            int elementsPerThread = (macierzA.w * macierzB.k) / numThreads;

            Parallel.For(0, numThreads, t =>
            {
                int startIdx = t * elementsPerThread;
                int endIdx = (t + 1) * elementsPerThread; 

                for (int idx = startIdx; idx < endIdx; idx++)
                {
                    int i = idx / macierzB.k; // Wiersz
                    int j = idx % macierzB.k; // Kolumna 

                    int suma = 0;
                    for (int k = 0; k < macierzA.k; k++)
                    {
                        suma += macierzA.wartosc[i, k] * macierzB.wartosc[k, j];
                    }

                   
                        wynikowa.wartosc[i, j] = suma; 
                    
                }
            });

            return wynikowa;
        }

        /* public static Macierz PomnozWielowatkowoP(Macierz macierzA, Macierz macierzB, int numThreads)
         {
             if (macierzA.k != macierzB.w)
             {
                 throw new ArgumentException("Niepoprawne wymiary macierzy do mnożenia.");
             }

             Macierz wynikowa = new Macierz(macierzA.w, macierzB.k);

             Parallel.For(0, macierzA.w, i =>
             {
                 for (int j = 0; j < macierzB.k; j++)
                 {
                     int suma = 0;
                     for (int k = 0; k < macierzA.k; k++)
                     {
                         suma += macierzA.wartosc[i, k] * macierzB.wartosc[k, j];
                     }
                     wynikowa.wartosc[i, j] = suma;
                 }

             });


             return wynikowa;
         }*/
    }


}
/*namespace LAB_3
{
        internal class Macierz
        {
            public int w;
            public int k;
            public int[,] wartosc;

            public Macierz() { }
            public Macierz(int W, int K)
            {
                w = W;
                k = K;
                wartosc = new int[w, k];
            }

            public void GenerujMacierz()
            {
                //Macierz macierz = new Macierz();    
                Random random = new Random();

                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        wartosc[i, j] = random.Next(0, 11);
                    }
                }
            }

            public void Wyswietl()
            {

                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        Console.Write(wartosc[i, j]);
                        Console.Write("  ");
                    }
                    Console.WriteLine("\n");
                }
            }

            public static Macierz Pomnoz(Macierz macierzA, Macierz macierzB)
            {
                if (macierzA.k != macierzB.w)
                {
                    throw new ArgumentException("Niepoprawne wymiary macierzy do mnożenia.");
                }

                Macierz wynikowa = new Macierz(macierzA.w, macierzB.k);

                for (int i = 0; i < macierzA.w; i++)
                {
                    for (int j = 0; j < macierzB.k; j++)
                    {
                        int suma = 0;
                        for (int k = 0; k < macierzA.k; k++)
                        {
                            suma += macierzA.wartosc[i, k] * macierzB.wartosc[k, j];
                        }
                        wynikowa.wartosc[i, j] = suma;
                    }
                }

                return wynikowa;
            }

            public static Macierz PomnozWielowatkowo(Macierz macierzA, Macierz macierzB, int numThreads)
            {
                if (macierzA.k != macierzB.w)
                {
                    throw new ArgumentException("Niepoprawne wymiary macierzy do mnożenia.");
                }

                Macierz wynikowa = new Macierz(macierzA.w, macierzB.k);

                int elementsPerThread = (macierzA.w * macierzB.k) / numThreads;

                Task[] tasks = new Task[numThreads];

                for (int t = 0; t < numThreads; t++)
                {
                    int start = t * elementsPerThread;
                    int end = (t == numThreads - 1) ? macierzA.w * macierzB.k : (t + 1) * elementsPerThread;

                    tasks[t] = Task.Run(() =>
                    {
                        for (int index = start; index < end; index++)
                        {
                            int i = index / macierzB.k;
                            int j = index % macierzB.k;

                            int suma = 0;
                            for (int k = 0; k < macierzA.k; k++)
                            {
                                suma += macierzA.wartosc[i, k] * macierzB.wartosc[k, j];
                            }
                            wynikowa.wartosc[i, j] = suma;
                        }
                    });
                }

                Task.WaitAll(tasks);

                return wynikowa;
            }

        }
}*/

/*
namespace LAB_3
{
    internal class Macierz
    {
        public int w;
        public int k;
        public int[,] wartosc;

        public Macierz() { }
        public Macierz(int W, int K) { 
            w = W; 
            k = K; 
            wartosc = new int[w, k];
        }

        public void GenerujMacierz()
        {
            //Macierz macierz = new Macierz();    
            Random random = new Random();

            for (int i = 0; i<w; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    wartosc[i,j] = random.Next(0,11);
                }
            }
        }

        public void Wyswietl()
        {

            for (int i = 0; i<w; i++)
            {
                for (int j = 0;j < k; j++)
                {
                    Console.Write(wartosc[i,j]);
                    Console.Write("  ");
                }
                Console.WriteLine("\n");
            }
        }

        public static Macierz Pomnoz(Macierz macierzA, Macierz macierzB)
        {
            if (macierzA.k != macierzB.w)
            {
                throw new ArgumentException("Niepoprawne wymiary macierzy do mnożenia.");
            }

            Macierz wynikowa = new Macierz(macierzA.w, macierzB.k);

            for (int i = 0; i < macierzA.w; i++)
            {
                for (int j = 0; j < macierzB.k; j++)
                {
                    int suma = 0;
                    for (int k = 0; k < macierzA.k; k++)
                    {
                        suma += macierzA.wartosc[i, k] * macierzB.wartosc[k, j];
                    }
                    wynikowa.wartosc[i, j] = suma;
                }
            }

            return wynikowa;
        }

          public static Macierz PomnozWielowatkowo(Macierz macierzA, Macierz macierzB, int numThreads)
        {
            if (macierzA.k != macierzB.w)
            {
                throw new ArgumentException("Niepoprawne wymiary macierzy do mnożenia.");
            }

            Macierz wynikowa = new Macierz(macierzA.w, macierzB.k);

            int elementsPerThread = (macierzA.w * macierzB.k) / numThreads;

            Task[] tasks = new Task[numThreads];

            for (int t = 0; t < numThreads; t++)
            {
                int start = t * elementsPerThread;
                int end = (t == numThreads - 1) ? macierzA.w * macierzB.k : (t + 1) * elementsPerThread;

                tasks[t] = Task.Run(() =>
                {
                    for (int index = start; index < end; index++)
                    {
                        int i = index / macierzB.k;
                        int j = index % macierzB.k;

                        int suma = 0;
                        for (int k = 0; k < macierzA.k; k++)
                        {
                            suma += macierzA.wartosc[i, k] * macierzB.wartosc[k, j];
                        }
                        wynikowa.wartosc[i, j] = suma;
                    }
                });
            }

            Task.WaitAll(tasks);

            return wynikowa;
        }

    }
}*/
