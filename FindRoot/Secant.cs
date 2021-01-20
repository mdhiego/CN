using System;
using org.mariuszgromada.math.mxparser;

namespace FindRoot
{
    class Secant
    {
        public static void TryFindRoot()
        {
            // Variables
            Function f;
            double x0, x1, x2, epsilon;

            // Get the user entries
            f = UserEntries.GetFunction();
            x0 = UserEntries.GetX(0);
            x1 = UserEntries.GetX(1);
            epsilon = UserEntries.GetAccuracy();

            // Check if x0 is a root
            if (Math.Abs(f.calculate(x0)) < epsilon)
            {
                Writer.WriteResult("\nO valor da raiz é: " + x0);
                return;
            }

            // Check if x1 is a root
            if (Math.Abs(f.calculate(x1)) < epsilon || Math.Abs(x1- x0) < epsilon)
            {
                Writer.WriteResult("\nO valor da raiz é: " + x1);
                return;
            }

            // Finding the root
            for (int i = 1; i <= 100; i++)
            {
                x2 = x1 - f.calculate(x1) * (x1- x0) / (f.calculate(x1) - f.calculate(x0));

                // Check if x2 is a root
                if (Math.Abs(f.calculate(x2)) < epsilon || Math.Abs(x2 - x1) < epsilon)
                {
                    Writer.WriteResult("O valor da raiz é: " + x2);
                    Writer.WriteSubHeader("\nNúmero de iterações: " + i);
                    return;
                }

                x0 = x1;
                x1 = x2;
            }

            Writer.WriteError("O número de iterações máximas permitidas (100) foi atingido");
        }
    }
}

