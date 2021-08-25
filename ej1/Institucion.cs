using System;

namespace ej1
{
    class Institucion
    {
        private string nombre;
        private int pacientesCovid = 0;
        private int pacientesRecuperados = 0;
        private int uciDisponibles;
        private int uciOcupadas;

        public string Nombre { get; set; }
        public int PacientesCovid { get; set; }
        public int PacientesRecuperados { get; set; }
        public int UciDisponibles { get; set; }
        public int UciOcupadas { get; set; }

        public Institucion(string nombre, int uci, int covi, int recuperados)
        {
            this.Nombre = nombre;
            this.UciDisponibles = uci;
            this.PacientesCovid = covi;
            this.UciOcupadas = uci - covi;
            this.PacientesRecuperados = recuperados;
        }

        public string toString()
        {
            return string.Format(
                "Nombre: {0}\n\t\tPacientes: {1}\n\t\tUCI Ocupadas: {2}\n\t\tUCI Disponibles: {3}\n\t\tRecuperados {4}",
                this.Nombre, this.PacientesCovid, this.UciOcupadas, this.UciDisponibles, this.PacientesRecuperados);
        }
    }
}