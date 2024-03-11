using System;
using System.Numerics;
using System.Globalization;

class Program
{
    static void Main()
    {
        while (true) // Bucle principal
        {
            Console.Clear();
            Console.WriteLine("=== La Fórmula de Euler ===\n --> e^ix = cos(x) + i*sin(x) <-- ");
            Console.WriteLine("\n- e es la base de los logaritmos naturales.");
            Console.WriteLine("- i es la unidad imaginaria.");
            Console.WriteLine("- x es el ángulo en radianes.");
            Console.WriteLine("\nIngrese el valor de x para aplicar la Fórmula de Euler.");
            Console.Write("Si desea verificar la Identidad de Euler, ingrese 'pi'. \n --> ");
            string? input;
            double x;

            do
            {
                input = Console.ReadLine();

                if (input?.Trim().ToLower() == "pi") //Aqui se verifica si es PI
                {
                    x = Math.PI;
                    Console.WriteLine("\nHas ingresado 'pi'. Utilizaremos π para las demostraciones.");
                    break; //Sale del bucle
                }
                else if (input?.Trim() == "180") //Aqui se verifica si es 180 grados
                {
                    x = Math.PI; // Convertir 180 grados a radianes (π radianes)
                    Console.WriteLine("\nHas ingresado '180'. Utilizaremos 180° en radianes (π) para las demostraciones.");
                    break; //Sale del bucle
                }
                else
                {
                    if (!double.TryParse(input, out x))
                    {
                        Console.Write("Por favor, ingrese un número válido, 'pi' o '180'. \n --> ");
                    }
                    else
                    {
                        break; //Sale del bucle
                    }
                }
            } while (true);


            Console.WriteLine($"Presione Enter para calcular cos({x}) y sin({x}).");
            Console.ReadLine();
            Console.Clear();


            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");//Esto es para los decimales

            //Calcular cos(x) e i*sin(x)
            double cosX = Math.Round(Math.Cos(x), 4);
            double sinX = Math.Round(Math.Sin(x), 4);
            Console.WriteLine("\nPrimero: Calculamos las partes real e imaginaria según la fórmula. \n");
            Console.WriteLine($"El coseno de {x} (la parte real) es {cosX,4}.");
            Console.WriteLine($"El seno de {x} (la parte imaginaria) es {sinX,4}.");
            Console.WriteLine("\nPresione Enter para continuar con el siguiente paso.");
            Console.ReadLine();
            Console.Clear();

            //Crear el número complejo con la parte real e imaginaria.
            Complex complexNumber = new Complex(cosX, sinX);
            Console.WriteLine($"\nDespues: El número complejo formado es {complexNumber, 4}.");
            Console.WriteLine("Presione Enter para aplicar la Fórmula de Euler.");
            Console.ReadLine();
            Console.Clear();

            //Calcular e^ix usando la Fórmula de Euler.
            Complex eulerResult = Complex.Exp(new Complex(0, x));
            eulerResult = new Complex(Math.Round(eulerResult.Real), Math.Round(eulerResult.Imaginary, 8));
            Console.WriteLine($"\nLuego: Usando la Fórmula de Euler, e^i({x}) es aproximadamente {eulerResult}.");
            Console.WriteLine("\nPresione Enter para continuar con el siguiente paso.");
            Console.ReadLine();
            Console.Clear();

            //Comparar con la Identidad de Euler si x es pi.
            if (x == Math.PI)
            {
                Complex identityResult = new Complex(eulerResult.Real + 1, eulerResult.Imaginary);
                Console.WriteLine($"La Identidad de Euler nos dice que e^iπ es aproximadamente {eulerResult}.");
                Console.WriteLine($"Al sumar 1, obtenemos: {Math.Round(identityResult.Real, 4)} + {Math.Round(identityResult.Imaginary, 4)}i");
                Console.WriteLine("Esto se espera que sea cercano a 0 debido a la precisión de punto flotante.");
                Console.WriteLine("Así mismo, e^iπ + 1 = 0");
                Console.WriteLine("\nPresione Enter para finalizar o escriba 'exit' para salir.");
                string exitCommand = Console.ReadLine();
                if (exitCommand?.ToLower() == "exit")
                {
                    break; // Sale del bucle principal
                }
            }
            else //Sino es pi
            {
                double result = Math.Cos(x) + Math.Sin(x);
                Console.WriteLine("La Identidad de Euler (e^iπ + 1 = 0) solo se demuestra cuando x es π.");
                Console.WriteLine($"La suma del coseno de {x} ({Math.Cos(x)}), 4) es y el seno de {x} ({Math.Sin(x)}) es:");
                Console.WriteLine($"-->  {result }");
                Console.WriteLine("\nPresione Enter para finalizar o escriba 'exit' para salir.");
                string exitCommand = Console.ReadLine();
                if (exitCommand?.ToLower() == "exit")
                {
                    break; // Sale del bucle principal
                }
            }
        }
    }
}