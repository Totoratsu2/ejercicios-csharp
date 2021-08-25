using System;
using System.Collections.Generic;

namespace ej2
{
    class Liga
    {
        public string Nombre;
        public List<Atleta> Atletas;

        public Liga(string nombre, List<Atleta> atletas)
        {
            this.Nombre = nombre;
            this.Atletas = atletas;
        }

        public string Imprimir()
        {
            return string.Format("\t{0}", this.Nombre);
        }
    }
}