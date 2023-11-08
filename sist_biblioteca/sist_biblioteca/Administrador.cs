using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sist_biblioteca
{
    public class Administrador : Persona
    {
        private byte librosPrestados;

        public Administrador()
        {
            nombre = "";
            librosPrestados = 0;
        }

        public Administrador(string nombre, int numeroid, byte librosPrestados)
        {
            this.nombre = nombre;
            this.numeroid = numeroid;
            this.librosPrestados = librosPrestados;
        }

        //Aún no está en uso los libros prestados, pero será usado cuanto tenga interfaz el programa.
        public byte LibrosPrestados
        {
            get { return librosPrestados; }
            set { librosPrestados = value; }
        }

        //Método que le permite al administrador añadir libros
        public void AñadirLibros(Biblioteca biblioteca)
        {
            //creamos una instancia de libro
            Libro nuevoLibro = new Libro("Libro De Prueba", "Yo", 1, GeneroEnum.Romance, true, 2);
            //la metemos en la biblioteca.
            biblioteca.listaLibros.Add(nuevoLibro);
        }

        //Método que permite al admin editar el contenido de un libro
        public void EditarLibro(Libro libroEditar, Biblioteca biblioteca)
        {
            //condiciones para los do while
            bool condicion = true;
            bool condicion1 = true;

            do
            {
                //bloque de impresión de texto para manejo por consola (PRÓXIMAMENTE SERÁ MIGRADO A INTERFAZ GRÁFICA)
                Console.WriteLine("¿Qué deseas editar del libro seleccionado?");
                Console.WriteLine(" 1. La cantidad de copias en sede.");
                Console.WriteLine(" 2. Otro aspecto.");
                Console.WriteLine(" 3. Salir.");

                //hacemos control de errores de la selección del admin

                byte seleccionAdmin;

                if (byte.TryParse(Console.ReadLine(), out seleccionAdmin))
                {

                    switch (seleccionAdmin)
                    {
                        case 1:
                            Console.WriteLine("¿Cuántas copias en sede deseas añadir?");
                            byte adminCantidad = byte.Parse(Console.ReadLine());

                            for (int j = 0; j < adminCantidad; j++)
                            {
                                libroEditar.CopiasEnSede++;
                            }
                            Console.WriteLine($"{adminCantidad} copias han sido añadidas a la biblioteca.");
                            break;

                        case 2:
                            Console.WriteLine("Ingresa el ISBN del libro a editar:");

                            //mismo caso de control de errores.
                            int adminISBN = int.Parse(Console.ReadLine());

                            if (int.TryParse(Console.ReadLine(), out adminISBN))
                            {
                                //Buscamos el libro que tiene el ISBN que requerimos en caso de que sea un int valido.
                                Libro libroEncontrado = biblioteca.ListaLibros.FirstOrDefault(libro => libro.ISBN == adminISBN);

                                //ciclo para que sólo salga cuando el usuario lo necesite.
                                do
                                {
                                    Console.WriteLine("¿Qué deseas editar del libro seleccionado?");
                                    Console.WriteLine(" 1. El título.");
                                    Console.WriteLine(" 2. El autor.");
                                    Console.WriteLine(" 3. El ISBN.");
                                    Console.WriteLine(" 4. El género.");
                                    Console.WriteLine(" 5. Salir.");

                                    int adminSelec;

                                    //Mismo controll de errores
                                    if (int.TryParse(Console.ReadLine(), out adminSelec))
                                    {

                                        //Si el usuario ingresa 5, el usuario se sale del sistema de edición.
                                        if (adminSelec == 5)
                                        {
                                            condicion1 = false;
                                        }
                                        else if (libroEncontrado != null)
                                        {
                                            switch (adminSelec)
                                            {
                                                case 1:
                                                    Console.WriteLine("Ingrese el nuevo título para el libro:");
                                                    string nuevoTitulo = Console.ReadLine();
                                                    libroEncontrado.Titulo = nuevoTitulo;
                                                    Console.WriteLine("El título del libro fue actualizado con éxito.");
                                                    break;

                                                case 2:
                                                    Console.WriteLine("Ingrese el nuevo autor para el libro:");
                                                    string nuevoAutor = Console.ReadLine();
                                                    libroEncontrado.Autor = nuevoAutor;
                                                    Console.WriteLine("El autor del libro fue actualizado con éxito.");
                                                    break;

                                                case 3:
                                                    Console.WriteLine("Ingrese el nuevo ISBN para el libro:");
                                                    int nuevoISBN = int.Parse(Console.ReadLine());
                                                    libroEncontrado.ISBN = nuevoISBN;
                                                    Console.WriteLine("El ISBN del libro fue actualizado con éxito.");
                                                    break;

                                                case 4:
                                                    int indice = 1;
                                                    foreach (GeneroLibro genero in Enum.GetValues(typeof(GeneroLibro)))
                                                    {
                                                        Console.WriteLine($"{indice}. {genero}");
                                                        indice++;
                                                    }

                                                    Console.Write("Ingresa el número del género deseado: ");

                                                    int numeroSeleccionado;

                                                    if (int.TryParse(Console.ReadLine(), out numeroSeleccionado))
                                                    {

                                                        if (numeroSeleccionado >= 1 && numeroSeleccionado <= Enum.GetValues(typeof(GeneroLibro)).Length)
                                                        {
                                                            //con el numero que ingresemos, buscamos la posicion en el enum generolibro y ese genero lo guardamos en una variable.
                                                            GeneroLibro generoSeleccionado = (GeneroLibro)(numeroSeleccionado - 1);
                                                            libroEncontrado.GeneroLibro = generoSeleccionado;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Número de género no válido.");
                                                        }

                                                    }

                                                    else
                                                    {

                                                        Console.WriteLine("Ha ocurrido un error.");

                                                    }

                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("El ISBN ingresado no fue encontrado.");
                                        }
                                    }
                                    //Imprime que ha ocurrido un error si sucede alguno.
                                    else
                                    {

                                        Console.WriteLine("Ha ocurrido un error.");

                                    }

                                } while (condicion1 == true);

                            }
                            //Imprime que ha ocurrido un error si sucede alguno.
                            else
                            {

                                Console.WriteLine("Ha ocurrido un error.");

                            }
                            break;

                        case 3:
                            condicion = false;
                            Console.WriteLine("Has salido del sistema de edición.");
                            break;
                    }


                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error.");
                }


            } while (condicion == true);
        }

        public void RegistrarUsuario(Biblioteca biblioteca)
        {
            string nuevoNombre = "Nuevo Usuario"; // Cambia esto al nombre deseado
            Usuario nuevoUsuario = new Usuario(nuevoNombre, biblioteca.listaUsuarios.Count + 1, null);
            biblioteca.listaUsuarios.Add(nuevoUsuario);
        }

        public void BorrarUsuario(Biblioteca biblioteca)
        {
            Console.WriteLine("Ingresa el ID del usuario a borrar.");
            int usuarioBorrar = int.Parse(Console.ReadLine());

            // Busca el usuario en la lista de usuarios de la Biblioteca por su ID
            Usuario usuarioAEliminar = biblioteca.listaUsuarios.FirstOrDefault(usuario => usuario.numeroid == usuarioBorrar);

            // Verifica si se encontró el usuario y elimínalo si es así
            if (usuarioAEliminar != null)
            {
                biblioteca.listaUsuarios.Remove(usuarioAEliminar);

                // Luego, puedes llamar a ReorganizarIDs() para actualizar los IDs secuenciales si es necesario
                this.ReorganizarIDs(biblioteca);
            }
            else
            {
                // El usuario con el ID especificado no se encontró en la lista
                Console.WriteLine("El usuario con el ID especificado no existe en la Biblioteca.");
            }
        }

        public void ReorganizarIDs(Biblioteca biblioteca)
        {
            //cambiamos todos los valores de numeroID por el contador mas 1.
            for (int i = 0; i < biblioteca.listaUsuarios.Count; i++)
            {
                biblioteca.listaUsuarios[i].numeroid = i + 1;
            }
        }
    }
}
