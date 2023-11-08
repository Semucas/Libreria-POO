using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sist_biblioteca
{
    public class Usuario : Persona
    {

        //QUIZA NECESARIO QUE SE TENGA UNA FORMA DE TRACKEAR QUE LIBRO ESTÁ EN SU PODER EN ESTA CLASE. LibrosPreSTADOS puede ser una alternativa a listaTransacciones y que la última sea reemplazada un atributo de instancia Libro que indique el libro está en su poder.

        public List<Transaccion> listaTransacciones;

        public Usuario(string nombre, int numeroid, Libro libroPrestado, List<Transaccion> listaTransacciones)
        {
            this.nombre = nombre;
            this.numeroid = numeroid;
            this.libroPrestado = null;
            this.listaTransacciones = new List<Transaccion>();
        }

        //public void pedirPrestado() { } removido por ahora, próximamente a añadir junto con un sistema de notificaciones del administrador.
        public void regresarLibro(Libro libroPrestado, Biblioteca biblioteca)
        {

            biblioteca.recibirDevolucion(libroPrestado);
            int posicion = this.listaTransacciones.FindIndex(instancia => instancia.libroPrestado == this.libroPrestado);
            this.listaTransacciones[posicion].setEstadoTrue();

        }
        public void verHistorial(List<Transaccion> listaTransacciones)
        {

            if (listaTransacciones != null)
            {
                foreach (Transaccion transaccion in listaTransacciones)
                {
                    //hacer un if else para que cuando esté devuelto diga si y cuando no este devuelto diga no
                    Console.WriteLine($"    Fecha Prestado: {transaccion.fechaPrestado}, \n    Fecha Vencimiento: {transaccion.fechaVencimiento}, \n    Libro Prestado: {transaccion.libroPrestado.titulo}, ");
                    if (transaccion.devuelto == true) { Console.WriteLine($"   Devuelto: Sí"); }
                    else { Console.WriteLine("   Devuelto: No."); }
                }
            }
            else
            {
                Console.WriteLine("No hay transacciones disponibles en el historial.");
            }
        }

    }

}

