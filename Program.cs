using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Caso___sem_11____Tema_6
{
    internal class Program
    {
        static int Max_estudiante = 40;
        static int max_curso = 4;
        static string[] NomCursos = {"Matematicas", "Programacion", "Fisica", "Base de datos"};
        static string[] estudiante=new string[Max_estudiante]; 
        static double[,] matrizNotas=new double[Max_estudiante , max_curso];
        static int total_estudiantes = 0;
        static string ruta_Archivo = "notas_curso.txt";

        public static void RegistrarEstudiante()
        {
            Console.WriteLine("REGISTRO DE ESTUDIANTE");
            if (total_estudiantes >= Max_estudiante)
            {
                Console.WriteLine("Se alcanzo la capacidad maxima");
                return;
            }
            string nombre = Validador.LeerTexto("Ingresar nombres y apellidos: ").ToUpper();
            estudiante[total_estudiantes] = nombre;
            Console.WriteLine("Ingresar las notas de 0 a 20");
            for(int i = 0; i < max_curso ; i++)
            {
                matrizNotas[total_estudiantes, i] = Validador.LeerDecimales
                    ($"Ingresar nota de {NomCursos[i]}:");
            }
            total_estudiantes++;
            Console.WriteLine("Estudiante registrado...!!");
        }
        public static void guardarArchivos()
        {
            Console.WriteLine("Guardar registros en archivo");
            if (total_estudiantes == 0)
            {
                Console.WriteLine("Guardar registros en archivos");
                return;
            }
            using (StreamWriter escritor=new StreamWriter(ruta_Archivo))
            {
                for (int i = 0; i < Max_estudiante; i++)
                {
                    string Linea = estudiante[i];
                    for (int j = 0; j < max_curso; j++)
                    {
                        Linea += "," + matrizNotas[i, j];
                    }
                    escritor.WriteLine(Linea);
                }

            }
            Console.WriteLine("Registros guardados...!!");
        }
        public static void CargarRegistros()
        {
            Console.WriteLine("CARGAR REGISTROS DESDE ARCHIVO");
            if (!File.Exists(ruta_Archivo))
            {
                Console.WriteLine("No existe el archivo");
                return;
            }
            total_estudiantes = 0;
            using(StreamReader lector=new StreamReader(ruta_Archivo))
            {
                string linea;
                while (( linea = lector.ReadLine()) != null && total_estudiantes < Max_estudiante)
                {
                    string[] partes= linea.Split(',');
                    if (partes.Length == max_curso + 1)
                    {
                        estudiante[total_estudiantes] = partes[0];
                        for(int i = 0; i < max_curso; i++)
                        {
                            matrizNotas[total_estudiantes, i] = Convert.ToDouble(partes[i + 1]);
                        }
                        total_estudiantes++;
                    }
                }
            }
            Console.WriteLine("Se cargaron los registro de archivo");
        }

        public static void mostrarRegistros()
        {
            Console.WriteLine(new string('=',100));
            Console.WriteLine("\t\tREGISTRO DE NOTAS POR CURSO");
            Console.WriteLine(new string('=', 100));
            if (total_estudiantes == 0)
            {
                Console.WriteLine("No existe Registros.....!!");
                return;
            }
            Console.Write($"{"ESTUDIANTE",-25}|");
            for (int i = 0; i < max_curso; i++)
            {
                Console.Write($"{NomCursos[i],-12}|");
            }
            Console.WriteLine("PROMEDIO");
            Console.WriteLine(new string('-', 100));
            for(int i = 0;i<total_estudiantes; i++)
            {
                Console.Write($"{estudiante[i],-25}|");
                double suma = 0;
                for(int j = 0; j < max_curso; j++)
                {
                    Console.Write($"{matrizNotas[i, j],-12}|");
                    suma += matrizNotas[i, j];
                }
                double promedio=suma/max_curso;
                string estado = promedio >= 12 ? "Aprobado" : "Desaprobado" ;
                Console.WriteLine($"{promedio:F2}({estado})");
            }
        }
        static void Main(string[] args)
        {
            int opc = 0;
            while (opc != 5)
            {
                Console.Clear();
                Console.WriteLine("[1]Registrar Estudiante");
                Console.WriteLine("[2]Guardar en Archivo");
                Console.WriteLine("[3]Cargar Registros en archivo");
                Console.WriteLine("[4]Mostrar Registros");
                Console.WriteLine("[5]Salir");
                opc = Validador.LeerEntero("seleccionar opcion [1-5]: ");
                switch(opc)
                {
                    case 1:
                        RegistrarEstudiante(); break;
                    case 2:
                        guardarArchivos(); break;
                    case 3:
                        CargarRegistros(); break;
                    case 4:
                        mostrarRegistros(); break;
                    case 5:
                        Console.WriteLine("Muchos existo para el nuevo semestre"); break;

                }
                Console.ReadKey();
            }
        }
    }
}
