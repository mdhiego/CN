using System;
using System.Reflection;
using org.mariuszgromada.math.mxparser;

namespace Integrate
{
    class UserEntries
    {
        public static Function GetFunction(string functionName = "")
        {
            Writer.WriteSubHeader("Entre com a função" + functionName + ": ");
            string buffer = Console.ReadLine();

            if (buffer.ToLower() == "funcoes")
            {
                PrintFunctions();
                Writer.WriteSubHeader("\nEntre com a função" + functionName + ": ");
                buffer = Console.ReadLine();
            }

            Function function = new Function(buffer);

            while (!function.checkSyntax() || function.getParametersNumber() != 1)
            {
                if (!function.checkSyntax())
                {
                    Writer.WriteError(function.getErrorMessage());
                }
                if (function.getParametersNumber() != 1)
                {
                    Writer.WriteError("Função inválida");
                }

                Writer.WriteSubHeader("\nEntre com a função" + functionName + ": ");
                buffer = Console.ReadLine();

                if (buffer.ToLower() == "funcoes")
                {
                    PrintFunctions();
                    Writer.WriteSubHeader("\nEntre com a função" + functionName + ": ");
                    buffer = Console.ReadLine();
                }

                function = new Function(buffer);
            }

            return function;
        }

        private static void PrintFunctions()
        {
            Writer.WriteHeader("\nFunções válidas:\n");

            MethodInfo[] mathMethods = typeof(
                org.mariuszgromada.math.mxparser.mathcollection.MathFunctions).GetMethods();

            foreach (MethodInfo methodInfo in mathMethods)
            {
                if (methodInfo.ReturnType.Name == "Double")
                {
                    Console.WriteLine(methodInfo.ToString().Substring(7));
                }
            }
        }

        public static double GetM2()
        {
            double M2;
            Writer.WriteSubHeader("Entre com o valor máximo da segunda derida de f no intervalo dado: ");
            while (!double.TryParse(Console.ReadLine(), out M2))
            {
                Writer.WriteError("Valor inválido\n");
                Writer.WriteSubHeader("Entre com o valor máximo da segunda derida de f no intervalo dado: ");
            }

            return M2;
        }

        public static double GetLowerBound()
        {
            double lowerBound;
            Writer.WriteSubHeader("Entre com o limite inferior: ");
            while (!double.TryParse(Console.ReadLine(), out lowerBound))
            {
                Writer.WriteError("Valor inválido\n");
                Writer.WriteSubHeader("Entre com o limite inferior: ");
            }

            return lowerBound;
        }

        public static double GetUpperBound()
        {
            double upperBound;
            Writer.WriteSubHeader("Entre com o limite superior: ");
            while (!double.TryParse(Console.ReadLine(), out upperBound))
            {
                Writer.WriteError("Valor inválido\n");
                Writer.WriteSubHeader("Entre com o limite superior: ");
            }

            return upperBound;
        }

        public static double GetTrapezHeight()
        {
            double trapezHeight;
            Writer.WriteSubHeader("Entre com a altura dos trapézios: ");
            while (!double.TryParse(Console.ReadLine(), out trapezHeight))
            {
                Writer.WriteError("Valor inválido\n");
                Writer.WriteSubHeader("Entre com a altura dos trapézios: ");
            }

            return trapezHeight;
        }

        public static double GetMaxError()
        {
            double maxError;
            Writer.WriteSubHeader("Entre com o erro máximo permitido: ");
            while (!double.TryParse(Console.ReadLine(), out maxError))
            {
                Writer.WriteError("Valor inválido\n");
                Writer.WriteSubHeader("Entre com o erro máximo permitido: ");
            }

            return maxError;
        }
    }
}
