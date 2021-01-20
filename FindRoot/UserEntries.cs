using System;
using System.Reflection;
using org.mariuszgromada.math.mxparser;

namespace FindRoot
{
    class UserEntries
    {
        public static Function GetFunction(string functionName = "")
        {
            Writer.WriteSubHeader("Entre com a função"+ functionName + ": ");
            string buffer = Console.ReadLine();

            if (buffer.ToLower() == "ajuda")
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

                if (buffer.ToLower() == "ajuda")
                {
                    PrintFunctions();
                    Writer.WriteSubHeader("\nEntre com a função" + functionName + ": ");
                    buffer = Console.ReadLine();
                }

                function = new Function(buffer);
            }

            return function;
        }

        public static void PrintFunctions()
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

        public static double GetAccuracy()
        {
            double accuracy;
            Writer.WriteSubHeader("Entre com a acurácia: ");
            while (!double.TryParse(Console.ReadLine(), out accuracy))
            {
                Writer.WriteError("Valor inválido\n");
                Writer.WriteSubHeader("Entre com a acurácia: ");
            }

            return accuracy;
        }

        public static double GetX(int index)
        {
            double x;
            Writer.WriteSubHeader("Entre com x" + index + ": ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Writer.WriteError("Valor inválido\n");
                Writer.WriteSubHeader("Entre com x" + index + ": ");
            }

            return x;
        }
    }
}
