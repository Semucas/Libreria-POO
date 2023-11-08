using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sist_biblioteca
{
    public class Transaccion
    {

        public Libro libroPrestado;
        public Usuario UsuarioBenef;
        public bool devuelto;
        public DateTime fechaPrestado;
        public DateTime fechaVencimiento;

        public Transaccion(Libro libroPrestado, Usuario UsuarioBenef, bool devuelto, DateTime fechaPrestado, DateTime fechaVencimiento)
        {
            this.libroPrestado = libroPrestado;
            this.UsuarioBenef = UsuarioBenef;
            this.devuelto = devuelto;
            this.fechaPrestado = fechaPrestado;
            this.fechaVencimiento = fechaVencimiento;
        }

        //método que calcula la multa que recibe el usuario en caso de que no entregue el libro a tiempo
        public int calcularMulta(DateTime fechaVencimiento)
        {

            DateTime fechaActual = DateTime.Now;
            TimeSpan multa = fechaVencimiento.Subtract(fechaActual);

            return multa.Days;
        }

        public void setEstadoTrue() { devuelto = true; }

    }
}
