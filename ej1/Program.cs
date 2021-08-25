using System;
using System.Collections.Generic;

namespace ej1
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
            Console.WriteLine("1. Generar 5 instituciones aleatorias");
            Console.WriteLine("2. Ver instituciones");
            Console.WriteLine("3. Ver mayor numero de recuperados");
            Console.WriteLine("4. Ver Camas UCI disponibles");
            Console.WriteLine("5. Institucion con mas camas UCI disponibles");
            Console.WriteLine("6. Total pacientes recuperados");
            Console.WriteLine("7. Salir\n");

            return leerEntero(1, 8);
        }

        public static string obtenerNombreRandom(Random r)
        {
            // Nos quedamos sin ideas para nombre de las instituciones :(
            string[] ligaNombres = new string[8] { "Baloncesto", "Futbol", "Boleibol", "Beisbol", "Tennis", "Ping Pong", "Squash", "Karate" };
            string[] nombres = new string[10] { "Nixon", "Diego", "Alejandro", "Mariana", "Paulina", "Manuela", "Camilo", "Leonardo", "Laura", "Gildardo" };

            return ligaNombres[r.Next(0, ligaNombres.Length - 1)] + " de " + nombres[r.Next(nombres.Length - 1)];
        }

        static void Main(string[] args)
        {
            Random r = new Random();
            List<Institucion> instituciones = new List<Institucion>();

            int index = menu();
            while (index != 7)
            {
                switch (index)
                {
                    case 1: // Agregar 5 instituciones random
                        for (int i = 0; i < 5; ++i)
                        {
                            Institucion nuevaInstitucion = new Institucion(obtenerNombreRandom(r), r.Next(1, 60), r.Next(1, 60), r.Next(1, 60));
                            instituciones.Add(nuevaInstitucion);
                        }
                        break;
                    case 2: // Ver instituciones
                        foreach (Institucion institucion in instituciones)
                        {
                            Console.WriteLine(institucion.toString());
                        }
                        break;
                    case 3: // Mayor numero de recuperados
                        Institucion mayorRecuperado = instituciones[0];

                        foreach (Institucion institucion in instituciones)
                        {
                            if (mayorRecuperado.PacientesRecuperados < institucion.PacientesRecuperados)
                            {
                                mayorRecuperado = institucion;
                            }
                        }

                        Console.WriteLine("La institucion con el mayor numero de recuperados es:");
                        Console.WriteLine(mayorRecuperado.toString());
                        break;
                    case 4: // Ver camas UCI disponibles
                        Console.WriteLine("Las instituciones con camas UCI disponibles son:");

                        foreach (Institucion institucion in instituciones)
                        {
                            if (institucion.PacientesRecuperados > 0)
                            {
                                Console.WriteLine(institucion.toString());
                            }
                        }
                        break;
                    case 5: // Institucion con mayor numero de camas UCI disponibles
                        Institucion mayorUCI = instituciones[0];

                        foreach (Institucion institucion in instituciones)
                        {
                            if (mayorUCI.UciDisponibles < institucion.UciDisponibles)
                            {
                                mayorUCI = institucion;
                            }
                        }

                        Console.WriteLine("La institucion con el mayor numero de camas UCI disponibles es:");
                        Console.WriteLine(mayorUCI.toString());
                        break;
                    case 6: // Total pacientes recuperados
                        int recuperados = 0;

                        foreach (Institucion institucion in instituciones)
                        {
                            recuperados += institucion.PacientesRecuperados;
                        }

                        Console.WriteLine(string.Format("Total pacientes recuperados es de: {0}", recuperados));
                        break;
                }

                index = menu();
            }
        }
    }
}
