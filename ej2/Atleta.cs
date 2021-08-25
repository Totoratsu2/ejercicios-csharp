using System;

namespace ej2
{
    class Atleta
    {
        public int Identificacion;
        public string Nombre;
        public int Titulos;

        public Atleta(string nombre, int identificacion, int titulos)
        {
            this.Nombre = nombre;
            this.Identificacion = identificacion;
            this.Titulos = titulos;
        }

        public string Imprimir()
        {
            return string.Format("\t\t{0}\t{1}\t{2}", this.Nombre, this.Identificacion, this.Titulos);
        }
    }
}