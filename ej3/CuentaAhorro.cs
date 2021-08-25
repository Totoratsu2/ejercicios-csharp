using System;

namespace instruccionesControl
{
    class CuentaAhorro
    {
        double minRetiro = 1;
        double minConsignacion = 1;

        public int Cuenta;
        public double Saldo = 0;
        public string Titular;
        public int Identificacion;

        // Intente hacerlo de esta manera pero me daban muchos errores :(
        /* public int Id = { get { return _id;
    }
    set
    { _id = value; } }; };
    public double Saldo = { get, set };
    public string Titular = { get, set };
    public int Identificacion = { get, set }; */

        public CuentaAhorro(int cuenta, string titular, int identificacion, double saldoInicial)
        {
            this.Cuenta = cuenta;
            this.Titular = titular;
            this.Identificacion = identificacion;
            this.Saldo = PromoSaldo(saldoInicial);
        }

        double PromoSaldo(double saldo)
        {
            if (saldo < 0)
            {
                Console.WriteLine("ERROR: Saldo invalido, se almacenara como un 0");
                return 0.0;
            }

            if (saldo >= 2000000)
            {
                Console.WriteLine("BONO Del 5% agregado al saldo de la cuenta!");
                return saldo + saldo * 0.05;
            }

            return saldo;
        }

        public string Imprimir()
        {
            return string.Format("\t{0}\t{1}\t{2}\n\t\tSaldo: {3}", this.Cuenta, this.Titular, this.Identificacion, this.Saldo);
        }

        public void Consignar(double valor, CuentaAhorro emisor)
        {
            if (valor < minConsignacion)
            {
                Console.WriteLine("ERROR: Valor a consignar invalido");
                return;
            }

            if (emisor.Saldo < valor)
            {
                Console.WriteLine("ERROR: El emisor no tiene la cantidad a consignar");
                return;
            }

            emisor.Saldo -= valor;
            this.Saldo += valor;
        }

        public void Retirar(double valor)
        {
            if (valor < minRetiro)
            {
                Console.WriteLine("ERROR: Valor a retirar invalido");
                return;
            }

            if (this.Saldo < valor)
            {
                Console.WriteLine("ERROR: Usuario no tiene suficiente dinero para retirar");
                return;
            }

            this.Saldo -= valor;
        }
    }
}