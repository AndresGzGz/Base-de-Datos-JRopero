using System;
using System.Collections.Generic;
using System.Text;

namespace AppEstudiantes588
{
    public class menu
    {
        public static List<string> ListaNombres = new List<string>();
        public static void MenuSecundario()
        {
            string opciones;
            int Opcion;
            do
            {
                bool DatoCorrecto = false;

                Console.Clear();
                gui.Marco(1, 110, 1, 25);
                Console.SetCursorPosition(10, 10); Console.WriteLine("1. agregar nombre");
                Console.SetCursorPosition(10, 11); Console.WriteLine("2. listar nombres");
                Console.SetCursorPosition(10, 12); Console.WriteLine("3. buscar nombres");
                Console.SetCursorPosition(10, 13); Console.WriteLine("4. menu principal");

                do
                {

                    Console.SetCursorPosition(10, 14); Console.WriteLine("Seleccione una opcion");
                    Console.SetCursorPosition(10, 15); opciones = Console.ReadLine();

                    if (!verificaciones.Vacio(opciones))
                        if (verificaciones.TipoNumero(opciones))
                            DatoCorrecto = true;


                } while (!DatoCorrecto);


                Opcion = Convert.ToInt32(opciones);

                switch (Opcion)
                {
                    case 1:
                        menu.AgregarNombre();
                        break;
                    case 2:
                        menu.ListarNombre();
                        break;
                    case 3:
                        menu.BuscarNombre();
                        break;
                    case 4:
                        Console.SetCursorPosition(40, 20); Console.WriteLine("volvera al menu anterior");
                        break;
                    default:
                        Console.SetCursorPosition(40, 20); Console.WriteLine("opcion incorrecta");
                        break;
                }

                Console.SetCursorPosition(40, 21); Console.WriteLine("presione una tecla para continuar");
                Console.SetCursorPosition(40, 22); Console.ReadKey();

            } while (Opcion != 4);

        }

        static void AgregarNombre()
        {
            bool DatoValido = false;
            Console.Clear();
            string nombre;

            gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(10, 10); Console.WriteLine("Agrega los nombres");
            do
            {
                Console.SetCursorPosition(10, 11); Console.WriteLine("Digite el nombre");
                Console.SetCursorPosition(10, 12); nombre = Console.ReadLine();

                if (!verificaciones.Vacio(nombre))
                    if (verificaciones.TipoLetra(nombre))
                        DatoValido = true;
            } while (!DatoValido);

            ListaNombres.Add(nombre);
        }

        static void ListarNombre()
        {
            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            Console.WriteLine("lista de nombres");
            foreach (string personaje in ListaNombres)
            {
                Console.WriteLine(personaje);
            }
        }

        static void BuscarNombre()
        {
            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            string NombreABuscar;
            bool DatoValido = false;
            do
            {
                Console.WriteLine("Digite el nombre que desea buscar");
                NombreABuscar = Console.ReadLine();
                if (!verificaciones.Vacio(NombreABuscar))
                    if (verificaciones.TipoLetra(NombreABuscar))
                        DatoValido = true;
            } while (!DatoValido);

            if (verificaciones.Existe(NombreABuscar))
                Console.WriteLine("el nombre " + NombreABuscar + " existe en la base de datos");
            else
                Console.WriteLine("el nombre " + NombreABuscar + " no existe en la base de datos");
        }
    }
}




















    


















