using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sist_biblioteca
{
    public class Biblioteca
    {
        //Estos serán los atributos que tendrá biblioteca
        public List<Libro> listaLibros;
        public List<Administrador> listaAdministradores;
        public List<Usuario> listaUsuarios;

        //Constructor de la clase biblioteca, no necesitamos ningún parámetro porque todas son listas que se inicializan vacías.
        public Biblioteca(List <Libro> listaLibros, List<Administrador> listaAdministradores, List<Usuario> listaUsuarios)
        {

            this.listaLibros = new List<Libro>();
            this.listaAdministradores = new List<Administrador>();
            this.listaUsuarios = new List<Usuario>();

        }

        //Método para buscar un libro, las anotaciones son para recordar a futuro.
        public void buscarLibro(int libroId)
        {

            //encontrar el primer libro que tenga el ISBN
            Libro encontrarLibro = listaLibros.FirstOrDefault(libro => libro.iSBN == libroId);

            //Si encontrar no es nulo, devolver la info del libro.
            if (encontrarLibro != null)
            {
                Console.WriteLine($"Libro encontrado con ISBN {libroId}: {encontrarLibro.titulo} by {encontrarLibro.autor}");
                //A futuro pensar como devolver el libro de forma de que sea conveniente para la interfaz.
            }

            //En caso de que sea nulo, avisar.
            else
            {
                Console.WriteLine($"El libro de ISBN {libroId} no fue encontrado.");
            }

        }

        public void darPrestamo(Usuario Usu, Libro LibroPrestar, Biblioteca biblioteca)
        {

            if (LibroPrestar.disponibilidad == true)
            {
                Transaccion TransaccionLibro = new Transaccion(LibroPrestar, Usu, false, DateTime.Now, DateTime.Now.AddDays(20));
                Usu.listaTransacciones.Add(TransaccionLibro);
                int iSBNLibro = LibroPrestar.iSBN;
                Libro libroEncontrado = biblioteca.listaLibros.FirstOrDefault(libro => libro.iSBN == iSBNLibro);

                //IF ELSE CONTROL ERRORES
                if (libroEncontrado != null)
                {
                    libroEncontrado.setCantidadResta(libroEncontrado.copiasEnSede);
                    Console.WriteLine("El libro ha sido prestado efectivamente.");
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error.");
                }
            }
        }

        public void recibirDevolucion(Libro libroPrestado)
        {
            //Aumentamos la cantidad de copias en sede en 1 porque el libro ha sido devuelto.
            libroPrestado.setCantidad(libroPrestado.copiasEnSede);

        }

    }

}

