using System;

namespace FindRoot
{
    class Program
    {
        enum Method
        {
            None,
            Bissection,
            FalsePosition,
            MPF,
            NewtonHapshon,
            Secant
        }

        public static void Main()
        {
            Writer.WriteTitle("\nENCONTRE A RAIZ DE UMA FUNÇÃO!");

            int chosenMethod;
            do
            {
                Writer.WriteHeader("\n\nEscolha o método de refinamento:\n");
                Console.Write(
                    "0 - Nenhum\n" +
                    "1 - Bissecção\n" +
                    "2 - Posição Falsa\n" +
                    "3 - Ponto Fixo\n" +
                    "4 - Newton Hapshon\n" +
                    "5 - Secante\n\n" +
                    "Método: ");

                // Check if the user entry is not a integer number
                if (!int.TryParse(Console.ReadLine(), out chosenMethod))
                {
                    chosenMethod = -1;
                }

                switch ((Method)chosenMethod)
                {
                    case Method.None:
                        Writer.WriteSubHeader("\nSaindo...");
                        break;
                    case Method.Bissection:
                        Bissection.TryFindRoot();
                        break;
                    case Method.FalsePosition:
                        FalsePosition.TryFindRoot();
                        break;
                    case Method.MPF:
                        MPF.TryFindRoot();
                        break;
                    case Method.NewtonHapshon:
                        NewtonHapshon.TryFindRoot();
                        break;
                    case Method.Secant:
                        Secant.TryFindRoot();
                        break;
                    default:
                        Writer.WriteError("\nOpção inválida\n");
                        break;
                }
            } while ((Method)chosenMethod != Method.None);
        }
    }
}

