using System;
using System.Collections.Generic;

namespace instruccionesControl
{
    class MainClass
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

        public static double leerFlotante()
        {
            double flotante;
            if (!double.TryParse(Console.ReadLine(), out flotante))
            {
                Console.WriteLine("ERROR: Valor flotante invalido");
                return -1;
            }

            return flotante;
        }

        public static int buscarUsuario(int cuenta, List<CuentaAhorro> usuarios)
        {
            foreach (CuentaAhorro usuario in usuarios)
            {
                if (usuario.Cuenta == cuenta)
                {
                    return usuario.Cuenta;
                }
            }

            Console.WriteLine("ERROR: Usuario no encontrado");
            return -1;
        }

        public static int menu()
        {
            Console.WriteLine("\n### Menu ###");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Ver usuarios");
            Console.WriteLine("3. Retiro de dinero");
            Console.WriteLine("4. Transferencia de dinero");
            Console.WriteLine("5. Generar 50 usuarios aleatorios");
            Console.WriteLine("6. Salir\n");

            return leerEntero(1, 6);
        }

        public static void Main(string[] args)
        {
            Random r = new Random();
            string[] nombres = new string[10] { "Nixon", "Diego", "Alejandro", "Mariana", "Paulina", "Manuela", "Camilo", "Leonardo", "Laura", "Gildardo" };

            List<CuentaAhorro> usuarios = new List<CuentaAhorro>();

            int index = menu();
            while (index != 6)
            {
                switch (index)
                {
                    case 1: // Registrar usuario
                        Console.WriteLine("Ingrese el numero de cuenta del nuevo usuario");
                        int cuenta1 = leerEntero(1, 999999999);
                        if (cuenta1 == -1) break;

                        Console.WriteLine("Ingrese el numbre del nuevo usuario");
                        string titular1 = Console.ReadLine();

                        Console.WriteLine("Ingrese el numero de identificacion del nuevo usuario");
                        int identificacion1 = leerEntero(1, 999999999);
                        if (identificacion1 == -1) break;

                        Console.WriteLine("Ingrese el monto inicial de la cuenta");
                        double saldo1 = leerFlotante();
                        if (saldo1 == -1) break;

                        CuentaAhorro usuario1 = new CuentaAhorro(cuenta1, titular1, identificacion1, saldo1);
                        usuarios.Add(usuario1);
                        Console.WriteLine(usuario1.Imprimir());
                        Console.WriteLine("Operacion terminada");

                        break;
                    case 2: // ver usuarios
                        Console.WriteLine(string.Format("Ingrese cantidad de usuarios que desea ver, 1 < n < {0}", usuarios.Count));
                        int numeroUsuarios = leerEntero(1, usuarios.Count);
                        if (numeroUsuarios == -1) break;

                        Console.WriteLine("\tCuenta\tNombre\tIdentificacion");
                        for (int i = 0; i < numeroUsuarios; ++i)
                        {
                            Console.WriteLine(usuarios[i].Imprimir());
                        }
                        break;
                    case 3: // retiro de dinero
                        Console.WriteLine("Ingrese el numero de cuenta del usuario");
                        int cuenta3 = leerEntero(1, usuarios.Count);
                        if (cuenta3 == -1) break;

                        int resultado = buscarUsuario(cuenta3, usuarios);
                        if (resultado == -1) break;
                        CuentaAhorro usuario3 = usuarios[resultado];

                        Console.WriteLine("Ingrese la cantidad de dinero a retirar");
                        int valor3 = leerEntero(1, (int)usuario3.Saldo);
                        if (valor3 == -1) break;

                        usuario3.Retirar(valor3);
                        Console.WriteLine(usuario3.Imprimir());
                        Console.WriteLine("Operacion terminada");

                        break;
                    case 4: // transferencia de dinero
                        List<CuentaAhorro> temp = new List<CuentaAhorro>();
                        Console.WriteLine("0 = Receptor, 1 = Emisor");
                        for (int i = 0; i < 2; ++i)
                        {
                            Console.WriteLine(string.Format("Ingrese el numero de cuenta del usuario {0}", i));
                            int cuenta4 = leerEntero(1, usuarios.Count);
                            if (cuenta4 == -1) break;

                            int resultado4 = buscarUsuario(cuenta4, usuarios);
                            if (resultado4 == -1) break;
                            temp.Add(usuarios[resultado4]);
                        }
                        if (temp.Count < 2)
                        {
                            Console.WriteLine("Transaccion cancelada");
                            break;
                        }

                        Console.WriteLine("Ingrese el valor a consignar");
                        int valor4 = leerEntero(1, (int)temp[1].Saldo);
                        if (valor4 == -1) break;

                        temp[0].Consignar(valor4, temp[1]);
                        Console.WriteLine(temp[0].Imprimir());
                        Console.WriteLine("Operacion terminada");

                        break;
                    case 5: // usuarios aleatorios
                        for (int i = 0; i < 50; ++i)
                        {
                            int identificacion5 = r.Next(usuarios.Count, 101);
                            double saldo5 = r.Next(1, 300000000) / 10;
                            int nombre5 = r.Next(0, nombres.Length - 1);

                            CuentaAhorro usuario5 = new CuentaAhorro(i, nombres[nombre5], identificacion5, saldo5);
                            usuarios.Add(usuario5);
                            Console.WriteLine(usuario5.Imprimir());
                        }
                        Console.WriteLine("\tUsuarios creados correctamente :)\n");

                        break;
                }

                index = menu();
            }
        }
    }
}