using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CapaDatos
{
    public class OCKO_ListaCustomizada
    {
        private decimal desempeno;
        private decimal actitud;
        private decimal habilidad;
        private int evaluacion;
        private int codEmpleado;

        public decimal Desempeno { get => desempeno; set => desempeno = value; }
        public decimal Actitud { get => actitud; set => actitud = value; }
        public decimal Habilidad { get => habilidad; set => habilidad = value; }
        public int Evaluacion { get => evaluacion; set => evaluacion = value; }
        public int CodEmpleado { get => codEmpleado; set => codEmpleado = value; }
    }
}
