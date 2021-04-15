using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AppEstudiantes588.Modelo;

namespace AppEstudiantes588
{
    class Program
    {
        static void Main(string[] args)
        {
            var datos = new bd_estudiantesContext();
            var Estudiantes = datos.Estudiantes.ToList();

            foreach (var MyEstudiante in Estudiantes)
            {
                Console.WriteLine($"\t{MyEstudiante.Codigo}\t{MyEstudiante.Nombre}\t\t{MyEstudiante.Correo}\t{MyEstudiante.Nota1}\t{MyEstudiante.Nota2}\t{MyEstudiante.Nota3}");
            }
            int Opcion;
            string opciones;

            do
            {
                bool DatoCorrecto = false;

                Console.Clear();
                gui.Marco(5, 118, 6, 12);
                Console.SetCursorPosition(7, 8); Console.WriteLine("App Estudiante");
                Console.SetCursorPosition(93, 8); Console.WriteLine("Escoja una opcion [ ]");
                Console.SetCursorPosition(7, 10); Console.WriteLine("1. Agregar ");
                Console.SetCursorPosition(27, 10); Console.WriteLine("2. Listar ");
                Console.SetCursorPosition(47, 10); Console.WriteLine("3. Buscar ");
                Console.SetCursorPosition(67, 10); Console.WriteLine("4. Editar ");
                Console.SetCursorPosition(87, 10); Console.WriteLine("5. Borrar ");
                Console.SetCursorPosition(107, 10); Console.WriteLine("0. Salir ");

                gui.Marco(5, 118, 14, 35);
                Console.SetCursorPosition(57, 17); Console.WriteLine("BIENVENIDOS");

                Console.SetCursorPosition(7, 27); Console.Write(".¶¶¶¶¶¶..¶¶¶¶¶..¶¶.....¶¶...¶¶¶¶...");
                Console.SetCursorPosition(7, 28); Console.Write(".¶¶......¶¶.....¶¶¶....¶¶..¶¶..¶¶..");
                Console.SetCursorPosition(7, 29); Console.Write(".¶¶¶¶¶...¶¶¶¶¶..¶¶.¶...¶¶..¶¶¶¶¶¶..");
                Console.SetCursorPosition(7, 30); Console.Write(".....¶¶..¶¶.....¶¶..¶..¶¶..¶¶..¶¶..");
                Console.SetCursorPosition(7, 31); Console.Write(".....¶¶..¶¶.....¶¶...¶.¶¶..¶¶..¶¶..");
                Console.SetCursorPosition(7, 32); Console.Write(".¶¶¶¶¶...¶¶¶¶¶..¶¶....¶¶¶..¶¶..¶¶..");
                Console.SetCursorPosition(7, 34); Console.Write("Centro De Mercados Logistica y Tecnologias De Informacion");

                Program program = new Program();
                do
                {
                    Console.SetCursorPosition(93, 8); Console.WriteLine("Escoja una opcion [ ]");
                    Console.SetCursorPosition(112, 8); opciones = Console.ReadLine();

                    if (!verificaciones.Vacio(opciones))
                        if (verificaciones.TipoNumero(opciones))
                            DatoCorrecto = true;
                } while (!DatoCorrecto);

                Opcion = Convert.ToInt32(opciones);
                switch (Opcion)
                {
                    case 1:
                        program.Agregar();
                        break;
                    case 2:
                        program.Listar();
                        break;
                    case 3:
                        program.Buscar();
                        break;
                    case 4:
                        program.Editar();
                        break;
                    case 5:
                        /*program.Borar();
                        break;*/
                    case 0:
                        program.Salir();
                        break;
                   default:
                        Console.WriteLine("Dato incorrecto");
                        break;
                }

                Console.SetCursorPosition(47, 33); Console.WriteLine("Presione una tecla para continuar");
                Console.SetCursorPosition(57, 34); Console.ReadKey();

            } while (Opcion > 0);
        }
        public void Agregar()
        {
            bool DatoValido = false;
            Console.Clear();
            String agregarCodigo = "";
            String agregarNombre = "";
            String agregarCorreo = "";
            String agregarNota1 = "";
            String agregarNota2 = "";
            String agregarNota3 = "";

            Console.Clear();
            gui.Marco(5, 118, 6, 12);
            Console.SetCursorPosition(7, 8); Console.WriteLine("App Estudiante");
            Console.SetCursorPosition(93, 8); Console.WriteLine("Escoja una opcion [ ]");
            Console.SetCursorPosition(7, 10); Console.WriteLine("1. Agregar ");
            Console.SetCursorPosition(27, 10); Console.WriteLine("2. Listar ");
            Console.SetCursorPosition(47, 10); Console.WriteLine("3. Buscar ");
            Console.SetCursorPosition(67, 10); Console.WriteLine("4. Editar ");
            Console.SetCursorPosition(87, 10); Console.WriteLine("5. Borrar ");
            Console.SetCursorPosition(107, 10); Console.WriteLine("0. Salir ");

            gui.Marco(5, 118, 14, 35);
            Console.SetCursorPosition(57, 16); Console.WriteLine("AGREGAR ESTUDIANTE");

            EmpezarCiclo(agregarCodigo, agregarNombre, agregarCorreo, agregarNota1, agregarNota2, agregarNota3, DatoValido);
        }
        public void EmpezarCiclo(String agregarCodigo, String agregarNombre, String agregarCorreo,
            String agregarNota1, String agregarNota2, String agregarNota3, bool DatoValido)
        {
            do
            {
                Console.SetCursorPosition(46, 20); Console.WriteLine("Digite su Codigo  = ");
                Console.SetCursorPosition(46, 22); Console.WriteLine("Digite su Nombre  = ");
                Console.SetCursorPosition(46, 24); Console.WriteLine("Digite su Correo  = ");
                Console.SetCursorPosition(46, 26); Console.WriteLine("Digite su Nota 1  = ");
                Console.SetCursorPosition(46, 28); Console.WriteLine("Digite su Nota 2  = ");
                Console.SetCursorPosition(46, 30); Console.WriteLine("Digite su Nota 3  = ");

                Console.SetCursorPosition(68, 20); agregarCodigo = Console.ReadLine();
                if (!verificaciones.TipoNumero(agregarCodigo))
                {
                    EmpezarCiclo("", "", "", "", "", "", true);
                    break;
                }
                Console.SetCursorPosition(68, 22); agregarNombre = Console.ReadLine();
                Console.SetCursorPosition(68, 24); agregarCorreo = Console.ReadLine();
                Console.SetCursorPosition(68, 26); agregarNota1 = Console.ReadLine();
                Console.SetCursorPosition(68, 28); agregarNota2 = Console.ReadLine();
                Console.SetCursorPosition(68, 30); agregarNota3 = Console.ReadLine();

                var bddatos = new bd_estudiantesContext();
                Estudiantes estu = new Estudiantes();

                estu.Codigo = Convert.ToInt32(agregarCodigo);
                estu.Nombre = agregarNombre;
                estu.Correo = agregarCorreo;
                estu.Nota1 = double.Parse(agregarNota1);
                estu.Nota2 = double.Parse(agregarNota2);
                estu.Nota3 = double.Parse(agregarNota3);

                bddatos.Estudiantes.Add(estu);
                if (bddatos.SaveChanges() > 0)
                {
                    Console.SetCursorPosition(47, 33); Console.WriteLine("ESTUDIANTE CREADO EXITOSAMENTE");
                    Console.SetCursorPosition(47, 34); agregarNota3 = Console.ReadLine();
                }
            } while (DatoValido);
        }
        public void Listar()
        {
            bool DatoValido = false;
            Console.Clear();
            String listaCodigo = "";
            String listaNombre = "";
            String listaCorreo = "";
            String listaNota1 = "";
            String listaNota2 = "";
            String listaNota3 = "";
            String lNf = "";
            String listaConcepto = "";

            Console.Clear();
            gui.Marco(5, 118, 6, 12);
            Console.SetCursorPosition(7, 8); Console.WriteLine("App Estudiante");
            Console.SetCursorPosition(93, 8); Console.WriteLine("Escoja una opcion [ ]");
            Console.SetCursorPosition(7, 10); Console.WriteLine("1. Agregar ");
            Console.SetCursorPosition(27, 10); Console.WriteLine("2. Listar ");
            Console.SetCursorPosition(47, 10); Console.WriteLine("3. Buscar ");
            Console.SetCursorPosition(67, 10); Console.WriteLine("4. Editar ");
            Console.SetCursorPosition(87, 10); Console.WriteLine("5. Borrar ");
            Console.SetCursorPosition(107, 10); Console.WriteLine("0. Salir ");

            gui.Marco(5, 118, 14, 35);
            Console.SetCursorPosition(57, 15); Console.WriteLine("LISTA DE ESTUDIANTES");

            Empezarlistar(listaCodigo, listaNombre, listaCorreo, listaNota1, listaNota2, listaNota3, DatoValido, lNf, listaConcepto);
        }
        public void Empezarlistar(String listaCodigo, String listaNombre, String listaCorreo,
                    String listaNota1, String listaNota2, String listaNota3, bool DatoValido, String lNf, String listaConcepto)
        {
            do
            {
                Console.SetCursorPosition(7, 17); Console.WriteLine("Codigo");
                Console.SetCursorPosition(22, 17); Console.WriteLine("Nombre");
                Console.SetCursorPosition(45, 17); Console.WriteLine("Correo");
                Console.SetCursorPosition(73, 17); Console.WriteLine("Nota-1");
                Console.SetCursorPosition(80, 17); Console.WriteLine("Nota-2");
                Console.SetCursorPosition(88, 17); Console.WriteLine("Nota-3");
                Console.SetCursorPosition(97, 17); Console.WriteLine("Nota Final");
                Console.SetCursorPosition(109, 17); Console.WriteLine("Concepto");

                var bddatos = new bd_estudiantesContext();
                List<Estudiantes> estu = bddatos.Estudiantes.ToList();

                int i = 0;

                foreach (var MyEstudiante in estu)
                {
                    Double listaNotafinal = (MyEstudiante.Nota1 + MyEstudiante.Nota2 + MyEstudiante.Nota3) / 3;

                    string concepto = string.Empty;
                    if (listaNotafinal > 3)
                    {
                        concepto = "Paso";
                    }
                    else
                    {
                        concepto = "Perdio";
                    }
                    Console.SetCursorPosition(7, (19 + i)); Console.WriteLine(MyEstudiante.Codigo);
                    Console.SetCursorPosition(22, (19 + i)); Console.WriteLine(MyEstudiante.Nombre);
                    Console.SetCursorPosition(45, (19 + i)); Console.WriteLine(MyEstudiante.Correo);
                    Console.SetCursorPosition(73, (19 + i)); Console.WriteLine(MyEstudiante.Nota1);
                    Console.SetCursorPosition(80, (19 + i)); Console.WriteLine(MyEstudiante.Nota2);
                    Console.SetCursorPosition(88, (19 + i)); Console.WriteLine(MyEstudiante.Nota3);
                    Console.SetCursorPosition(97, (19 + i)); Console.WriteLine(Decimal.Round(Convert.ToDecimal(listaNotafinal)));
                    Console.SetCursorPosition(109, (19 + i)); Console.WriteLine(concepto);

                    Console.WriteLine("\n");
                    i++;
                    //bddatos.Estudiantes.Add(MyEstudiante);
                }
                //if (bddatos.SaveChanges() > 0)
                //{
                //    Console.SetCursorPosition(56, 30); Console.WriteLine("ESTUDIANTE CREADO EXITOSAMENTE");
                //    Console.SetCursorPosition(56, 31); listaConcepto = Console.ReadLine();
                //}
            } while (DatoValido);
        }
        public void Buscar()
        {
            bool DatoValido = false;
            Console.Clear();
            String BuscarCodigo = "";
            String BuscarNombre = "";
            String BuscarCorreo = "";
            String BuscarNota1 = "";
            String BuscarNota2 = "";
            String BuscarNota3 = "";

            Console.Clear();
            gui.Marco(5, 118, 6, 12);
            Console.SetCursorPosition(7, 8); Console.WriteLine("App Estudiante");
            Console.SetCursorPosition(93, 8); Console.WriteLine("Escoja una opcion [ ]");
            Console.SetCursorPosition(7, 10); Console.WriteLine("1. Agregar ");
            Console.SetCursorPosition(27, 10); Console.WriteLine("2. Listar ");
            Console.SetCursorPosition(47, 10); Console.WriteLine("3. Buscar ");
            Console.SetCursorPosition(67, 10); Console.WriteLine("4. Editar ");
            Console.SetCursorPosition(87, 10); Console.WriteLine("5. Borrar ");
            Console.SetCursorPosition(107, 10); Console.WriteLine("0. Salir ");

            gui.Marco(5, 118, 14, 35);
            Console.SetCursorPosition(47, 16); Console.WriteLine("CODIGO DEL ESTUDIANTE A BUSCAR [    ]");
            Console.SetCursorPosition(79, 16); BuscarCodigo = Console.ReadLine();

            EmpezarBuscar(BuscarCodigo, BuscarNombre, BuscarCorreo, BuscarNota1, BuscarNota2, BuscarNota3, DatoValido);
        }
        public void EmpezarBuscar(String BuscarCodigo, String BuscarNombre, String BuscarCorreo,
            String BuscarNota1, String BuscarNota2, String BuscarNota3, bool DatoValido)
        {
            do
            {
                Console.SetCursorPosition(46, 20); Console.WriteLine("Codigo  = ");
                Console.SetCursorPosition(46, 22); Console.WriteLine("Nombre  = ");
                Console.SetCursorPosition(46, 24); Console.WriteLine("Correo  = ");
                Console.SetCursorPosition(46, 26); Console.WriteLine("Nota 1  = ");
                Console.SetCursorPosition(46, 28); Console.WriteLine("Nota 2  = ");
                Console.SetCursorPosition(46, 30); Console.WriteLine("Nota 3  = ");

                var bddatos = new bd_estudiantesContext();
                List<Estudiantes> estu = bddatos.Estudiantes.ToList();
                var cod = int.Parse(BuscarCodigo);
                var MyEstudiante = bddatos.Estudiantes.Find(cod);
               
                
                 
                    if (!verificaciones.TipoNumero(BuscarCodigo))
                    {
                        EmpezarBuscar("", "", "", "", "", "", true);
                        break;
                    }

                        Console.SetCursorPosition(68, 20); Console.WriteLine(MyEstudiante.Codigo);
                        Console.SetCursorPosition(68, 22); Console.WriteLine(MyEstudiante.Nombre);
                        Console.SetCursorPosition(68, 24); Console.WriteLine(MyEstudiante.Correo);
                        Console.SetCursorPosition(68, 26); Console.WriteLine(MyEstudiante.Nota1);
                        Console.SetCursorPosition(68, 28); Console.WriteLine(MyEstudiante.Nota2);
                        Console.SetCursorPosition(68, 30); Console.WriteLine(MyEstudiante.Nota3);
                

            } while (DatoValido);
        }
        public void Editar()
        {
                bool DatoValido = false;
                Console.Clear();
                String EditarCodigo = "";
                String EditarNombre = "";
                String EditarCorreo = "";
                String EditarNota1 = "";
                String EditarNota2 = "";
                String EditarNota3 = "";

                Console.Clear();
                gui.Marco(5, 118, 6, 12);
                Console.SetCursorPosition(7, 8); Console.WriteLine("App Estudiante");
                Console.SetCursorPosition(93, 8); Console.WriteLine("Escoja una opcion [ ]");
                Console.SetCursorPosition(7, 10); Console.WriteLine("1. Agregar ");
                Console.SetCursorPosition(27, 10); Console.WriteLine("2. Listar ");
                Console.SetCursorPosition(47, 10); Console.WriteLine("3. Buscar ");
                Console.SetCursorPosition(67, 10); Console.WriteLine("4. Editar ");
                Console.SetCursorPosition(87, 10); Console.WriteLine("5. Borrar ");
                Console.SetCursorPosition(107, 10); Console.WriteLine("0. Salir ");

                gui.Marco(5, 118, 14, 35);
                Console.SetCursorPosition(17, 16); Console.WriteLine("CODIGO DEL ESTUDIANTE A EDITAR [    ]");
                Console.SetCursorPosition(49, 16); EditarCodigo = Console.ReadLine();

            EmpezarEditar(EditarCodigo, EditarNombre, EditarCorreo, EditarNota1, EditarNota2, EditarNota3, DatoValido);
        }
        public void EmpezarEditar(String EditarCodigo, String EditarNombre, String EditarCorreo,
                String EditarNota1, String EditarNota2, String EditarNota3, bool DatoValido)
        {
            do
            {
                Console.SetCursorPosition(11, 20); Console.WriteLine("Digite su Codigo  = ");
                Console.SetCursorPosition(11, 22); Console.WriteLine("Digite su Nombre  = ");
                Console.SetCursorPosition(11, 24); Console.WriteLine("Digite su Correo  = ");
                Console.SetCursorPosition(11, 26); Console.WriteLine("Digite su Nota 1  = ");
                Console.SetCursorPosition(11, 28); Console.WriteLine("Digite su Nota 2  = ");
                Console.SetCursorPosition(11, 30); Console.WriteLine("Digite su Nota 3  = ");

                
                Console.SetCursorPosition(68, 20); Console.WriteLine("Digite Nuevos Datos  ");
                Console.SetCursorPosition(68, 22); EditarNombre = Console.ReadLine();
                Console.SetCursorPosition(68, 24); EditarCorreo = Console.ReadLine();
                Console.SetCursorPosition(68, 26); EditarNota1 = Console.ReadLine();
                Console.SetCursorPosition(68, 28); EditarNota2 = Console.ReadLine();
                Console.SetCursorPosition(68, 30); EditarNota3 = Console.ReadLine();

                var bddatos = new bd_estudiantesContext();
                Estudiantes estu = new Estudiantes();
                var cod = int.Parse(EditarCodigo);
                var MyEstudiante = bddatos.Estudiantes.Find(cod);

                estu.Codigo = Convert.ToInt32(EditarCodigo);
                estu.Nombre = EditarNombre;
                estu.Correo = EditarCorreo;
                estu.Nota1 = double.Parse(EditarNota1);
                estu.Nota2 = double.Parse(EditarNota2);
                estu.Nota3 = double.Parse(EditarNota3);

                bddatos.Estudiantes.Add(estu);
                if (bddatos.SaveChanges() > 0)
                {
                    Console.SetCursorPosition(57, 33); Console.WriteLine("ESTUDIANTE EDITADO CORRECTAMENTE");
                    Console.SetCursorPosition(57, 34); EditarNota3 = Console.ReadLine();
                }
            } while (DatoValido);
        }

            public void Borrar()
        {
                    bool DatoValido = false;
                    Console.Clear();
                    String BorrarCodigo = "";
                    String BorrarNombre = "";
                    String BorrarCorreo = "";
                    String BorrarNota1 = "";
                    String BorrarNota2 = "";
                    String BorrarNota3 = "";

                    Console.Clear();
                    gui.Marco(5, 118, 6, 12);
                    Console.SetCursorPosition(7, 8); Console.WriteLine("App Estudiante");
                    Console.SetCursorPosition(93, 8); Console.WriteLine("Escoja una opcion [ ]");
                    Console.SetCursorPosition(7, 10); Console.WriteLine("1. Agregar ");
                    Console.SetCursorPosition(27, 10); Console.WriteLine("2. Listar ");
                    Console.SetCursorPosition(47, 10); Console.WriteLine("3. Buscar ");
                    Console.SetCursorPosition(67, 10); Console.WriteLine("4. Editar ");
                    Console.SetCursorPosition(87, 10); Console.WriteLine("5. Borrar ");
                    Console.SetCursorPosition(107, 10); Console.WriteLine("0. Salir ");

                    gui.Marco(5, 118, 14, 35);
                    Console.SetCursorPosition(57, 16); Console.WriteLine("AGREGAR ESTUDIANTE");

                    EmpezarBorrar(BorrarCodigo, BorrarNombre, BorrarCorreo, BorrarNota1, BorrarNota2, BorrarNota3, DatoValido);
        }
        public void EmpezarBorrar(String agregarCodigo, String agregarNombre, String agregarCorreo,
                    String agregarNota1, String agregarNota2, String agregarNota3, bool DatoValido)
        {
                do
                {
                    Console.SetCursorPosition(46, 20); Console.WriteLine("Digite su Codigo  = ");
                    Console.SetCursorPosition(46, 22); Console.WriteLine("Digite su Nombre  = ");
                    Console.SetCursorPosition(46, 24); Console.WriteLine("Digite su Correo  = ");
                    Console.SetCursorPosition(46, 26); Console.WriteLine("Digite su Nota 1  = ");
                    Console.SetCursorPosition(46, 28); Console.WriteLine("Digite su Nota 2  = ");
                    Console.SetCursorPosition(46, 30); Console.WriteLine("Digite su Nota 3  = ");

                    Console.SetCursorPosition(68, 20); agregarCodigo = Console.ReadLine();
                    if (!verificaciones.TipoNumero(agregarCodigo))
                    {
                        EmpezarCiclo("", "", "", "", "", "", true);
                        break;
                    }
                    Console.SetCursorPosition(68, 22); agregarNombre = Console.ReadLine();
                    Console.SetCursorPosition(68, 24); agregarCorreo = Console.ReadLine();
                    Console.SetCursorPosition(68, 26); agregarNota1 = Console.ReadLine();
                    Console.SetCursorPosition(68, 28); agregarNota2 = Console.ReadLine();
                    Console.SetCursorPosition(68, 30); agregarNota3 = Console.ReadLine();

                    var bddatos = new bd_estudiantesContext();
                    Estudiantes estu = new Estudiantes();

                    estu.Codigo = Convert.ToInt32(agregarCodigo);
                    estu.Nombre = agregarNombre;
                    estu.Correo = agregarCorreo;
                    estu.Nota1 = double.Parse(agregarNota1);
                    estu.Nota2 = double.Parse(agregarNota2);
                    estu.Nota3 = double.Parse(agregarNota3);

                    bddatos.Estudiantes.Add(estu);
                    if (bddatos.SaveChanges() > 0)
                    {
                        Console.SetCursorPosition(57, 33); Console.WriteLine("ESTUDIANTE CREADO EXITOSAMENTE");
                        Console.SetCursorPosition(57, 34); agregarNota3 = Console.ReadLine();
                    }
                } while (DatoValido);
        }

        public void Salir()
        {

                        Console.Clear();
                        gui.Marco(5, 118, 6, 12);
                        Console.SetCursorPosition(7, 8); Console.WriteLine("App Estudiante");
                        Console.SetCursorPosition(93, 8); Console.WriteLine("Escoja una opcion [ ]");
                        Console.SetCursorPosition(7, 10); Console.WriteLine("1. Agregar ");
                        Console.SetCursorPosition(27, 10); Console.WriteLine("2. Listar ");
                        Console.SetCursorPosition(47, 10); Console.WriteLine("3. Buscar ");
                        Console.SetCursorPosition(67, 10); Console.WriteLine("4. Editar ");
                        Console.SetCursorPosition(87, 10); Console.WriteLine("5. Borrar ");
                        Console.SetCursorPosition(107, 10); Console.WriteLine("0. Salir ");

                        gui.Marco(5, 118, 14, 35);
                        Console.SetCursorPosition(47, 24); Console.WriteLine("GRACIAS POR USAR NUESTRO PROGRAMA");
                        Console.SetCursorPosition(57, 34); Console.ReadLine();
                       
        }

    }
}



