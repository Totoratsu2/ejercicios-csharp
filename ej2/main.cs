using System;
using System.Collections.Generic;

namespace ej2
{
    class Program
    {
        public static int leerEntero(int min, int max)
        {
            int numero = 0;

            if (!Int32.TryParse(Console.ReadLine(), out numero) || min > numero || numero > max)
            {
                Console.WriteLine(string.Format("ERROR: Numero invalido, debe de estar en el rango {0} < n < {1}", min - 1, max + 1));
                return -1;
            }

            return numero;
        }

        public static int menu()
        {
            Console.WriteLine("\n### Menu ###");
            Console.WriteLine("1. Generar 4 ligas con 2 atletas c/u");
            Console.WriteLine("2. Ver Atletas");
            Console.WriteLine("3. Deportista con mas titulos");
            Console.WriteLine("4. Ver atletas sin titulos");
            Console.WriteLine("5. Salir\n");

            return leerEntero(1, 5);
        }

        static void Main(string[] args)
        {
            Random r = new Random();
            string[] ligaNombres = new string[8] { "Baloncesto", "Futbol", "Boleibol", "Beisbol", "Tennis", "Ping Pong", "Squash", "Karate" };
            string[] nombres = new string[10] { "Nixon", "Diego", "Alejandro", "Mariana", "Paulina", "Manuela", "Camilo", "Leonardo", "Laura", "Gildardo" };
            List<Liga> ligas = new List<Liga>();

            int index = menu();
            while (index != 5)
            {
                switch (index)
                {
                    case 1: // generar data de prueba
                        for (int i = 0; i < 4; ++i)
                        {
                            List<Atleta> atletas1 = new List<Atleta>();
                            for (int y = 0; y < 2; ++y)
                            {
                                int identificacion1 = (ligas.Count + 1) * (atletas1.Count + 1);
                                int nombre1 = r.Next(0, nombres.Length - 1);

                                Atleta ata1 = new Atleta(nombres[nombre1], identificacion1, r.Next(0, 25));
                                Console.WriteLine(ata1.Imprimir());
                                atletas1.Add(ata1);
                            }

                            int ligaNombre = r.Next(0, ligaNombres.Length - 1);
                            Liga liga1 = new Liga(ligaNombres[ligaNombre], atletas1);
                            Console.WriteLine(liga1.Imprimir());
                            ligas.Add(liga1);
                        }
                        break;
                    case 2: // ver atletas
                        foreach (Liga lig in ligas)
                        {
                            Console.WriteLine(string.Format("\tLiga: {0}", lig.Imprimir()));
                            foreach (Atleta at5 in lig.Atletas)
                            {
                                Console.WriteLine(string.Format("\tAtleta: {0}", at5.Imprimir()));
                            }
                        }
                        break;
                    case 3: // atleta con mas titulos
                        Atleta ganador = ligas[0].Atletas[0];
                        Liga ligaGanador = ligas[0];

                        foreach (Liga lig in ligas)
                        {
                            foreach (Atleta at5 in lig.Atletas)
                            {
                                if (at5.Titulos > ganador.Titulos)
                                {
                                    ganador = at5;
                                    ligaGanador = lig;
                                }
                            }
                        }

                        Console.WriteLine(string.Format("\tLiga: {0}", ligaGanador.Imprimir()));
                        Console.WriteLine(string.Format("\tAtleta: {0}", ganador.Imprimir()));

                        break;
                    case 4: // Atletas sin titulo
                        Console.WriteLine("Atletas sin titulo:");

                        for (int i = 0; i < ligas.Count; ++i)
                        {
                            foreach (Atleta ata6 in ligas[i].Atletas)
                            {
                                if (ata6.Titulos == 0)
                                {
                                    Console.WriteLine(ata6.Imprimir());
                                }
                            }
                        }

                        break;
                }
                index = menu();
            }
        }
    }
}
