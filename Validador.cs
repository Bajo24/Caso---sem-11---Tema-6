using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Caso___sem_11____Tema_6
{
    internal class Validador
    {
        public static int LeerEntero(String mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < 1 && valor > 5)
                    {
                        Console.WriteLine("Error: El valor es entre [1 a 5]");
                        continue;
                    }
                    return valor;
                }
                Console.WriteLine("Error: El valor debe ser numerico");
            }
        }
        public static double LeerDecimales(String mensaje)
        {
            double valor;
            while (true)
            {
                Console.Write(mensaje);
                if(double.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor<0 && valor > 20)
                    {
                        Console.WriteLine("Error: La nota es entre [ 0,  20 ]");
                        continue;                        
                    }
                    return valor;
                }
                Console.WriteLine("Error: El valor debe ser numerico decimal");
            }
            
        }
        public static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(texto))
                    return texto;
                Console.WriteLine("Error: Este campo no puede ser vacio...!!");

            }
        }
    }
}
