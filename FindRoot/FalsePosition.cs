using System;
using org.mariuszgromada.math.mxparser;

namespace FindRoot
{
    class FalsePosition
    {
        public static void TryFindRoot()
        {
            // Variables
            Function f;
            double a, fa, b, fb, x, fx, epsilon;

            // Get the user entries
            f = UserEntries.GetFunction();
            a = UserEntries.GetLowerBound();
            b = UserEntries.GetUpperBound();
            epsilon = UserEntries.GetAccuracy();

            // Check if any of the limits are root
            fa = f.calculate(a);
            if (Math.Abs(fa) < epsilon)
            {
                Writer.WriteResult("\nO valor da raiz é: " + a);
                return;
            }
            fb = f.calculate(b);
            if (Math.Abs(fb) < epsilon)
            {
                Writer.WriteResult("\nO valor da raiz é: " + b);
                return;
            }

            // Finding the root
            for (int i = 1; i <= 100; i++)
            {
                x = (a * fb - b * fa) / (fb - fa);
                fx = f.calculate(x);

                // Check if x is a root
                if (Math.Abs(fx) < epsilon || Math.Abs(b - a) < epsilon)
                {
                    Writer.WriteResult("O valor da raiz é: " + x);
                    Writer.WriteSubHeader("\nNúmero de iterações: " + i);
                    return;
                }

                if (Math.Sign(fx) == Math.Sign(fa))
                {
                    a = x;
                    fa = fx;
                }
                else if (Math.Sign(fx) == Math.Sign(fb))
                {
                    b = x;
                    fb = fx;
                }
            }

            Writer.WriteError("O número de iterações máximas permitidas (100) foi atingido");
        }
    }
}

