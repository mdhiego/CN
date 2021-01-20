using System;
using org.mariuszgromada.math.mxparser;

namespace FindRoot
{
    class MPF
    {
        public static void TryFindRoot()
        {
            // Variables
            Function f, gamma;
            double x0, x1, epsilon;

            // Get the user entries
            f = UserEntries.GetFunction();
            gamma = UserEntries.GetFunction(" Gama");
            x0 = UserEntries.GetX(0);
            epsilon = UserEntries.GetAccuracy();

            // Check if x0 is a root
            if (Math.Abs(f.calculate(x0)) < epsilon)
            {
                Writer.WriteResult("\nO valor da raiz é: " + x0);
                return;
            }

            // Finding the root
            for (int i = 1; i <= 100; i++)
            {
                x1 = gamma.calculate(x0);

                // Check if x1 is a root
                if (Math.Abs(f.calculate(x1)) < epsilon || Math.Abs(x1 - x0) < epsilon)
                {
                    Writer.WriteResult("O valor da raiz é: " + x1);
                    Writer.WriteSubHeader("\nNúmero de iterações: " + i);
                    return;
                }

                x0 = x1;
            }

            Writer.WriteError("O número de iterações máximas permitidas (100) foi atingido");
        }
    }
}

