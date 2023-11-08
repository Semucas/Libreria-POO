using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sist_biblioteca
{
    public class Libro
    {
        public string titulo;
        public string autor;
        public int iSBN;
        public GeneroEnum GeneroLibro;
        public bool disponibilidad;
        public int copiasEnSede;

        public Libro()
        {

            titulo = "";
            autor = "";

        }

        public Libro(string titulo, string autor, int iSBN, GeneroEnum GeneroLibro, bool disponibilidad, int copiasEnSede)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.iSBN = iSBN;
            this.GeneroLibro = GeneroLibro;
            this.disponibilidad = disponibilidad;
            this.copiasEnSede = copiasEnSede;
        }
        public void setEstado(bool disponibilidad) { this.disponibilidad = true; }
        public void setCantidad(int copiasEnSede) { this.copiasEnSede = copiasEnSede + 1; }
        public void setCantidadResta(int copiasEnSede) { this.copiasEnSede = copiasEnSede - 1; }
    }
}
