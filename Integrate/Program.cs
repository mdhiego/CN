using System;
using org.mariuszgromada.math.mxparser;

namespace Integrate
{
    class Program
    {
        static void Main()
        {
            // Imprime o cabeçalho
            Writer.WriteHeader("\n\nINTEGRAÇÃO NUMÉRICA - Regra dos trápezios");

            // Executa o programa enquanto a opção sair não for escolhida
            while (true)
            {
                // Imprime as opções para o usuário
                Writer.WriteTitle("\n\nEscolha uma opção:\n");
                Console.Write(
                    "0 - Sair\n" +
                    "1 - Integrar a partir do número de partições\n" +
                    "2 - Integrar a partir do erro máximo permitido\n" +
                    "\nOpção: ");

                // Checa se a opção escolhida é um número inteiro
                if (int.TryParse(Console.ReadLine(), out int chosenWay))
                {
                    // Invoca o procedimento escolhido
                    switch (chosenWay)
                    {
                        case 0:
                            return;
                        case 1:
                            RegraDoTrapezio1();
                            break;
                        case 2:
                            RegraDoTrapezio2();
                            break;
                        default:
                            Writer.WriteError("\nOpção inválida\n");
                            break;
                    }
                }
                else
                {
                    Writer.WriteError("\nOpção inválida\n");
                }
            }
        }

        static void RegraDoTrapezio1()
        {
            // Função para integração
            Function f = UserEntries.GetFunction();
            // Máximo valor da segunda derivada
            double M2 = UserEntries.GetM2();
            // Limite inferior
            double a = UserEntries.GetLowerBound();
            // Limite superior
            double b = UserEntries.GetUpperBound();
            // Altura dos trapézios
            double h = UserEntries.GetTrapezHeight();

            // Calculo da área e do erro cometido
            double somafx = 0;
            for (double x = a + h; x < b; x += h)
            {
                somafx += f.calculate(x);
            }
            double Itr = (h / 2) * (f.calculate(a) + 2 * somafx + f.calculate(b));
            double erro = ((b - a) / 12) * h * h * M2;

            // Impressão do resultado
            Writer.WriteResult("Pela regra dos trapézios, a integral da função dada é: " +
                Itr + "\nO erro cometido é: " + erro);
        }

        static void RegraDoTrapezio2()
        {
            // Função para integração
            Function f = UserEntries.GetFunction();
            // Máximo valor da segunda derivada
            double M2 = UserEntries.GetM2();
            // Limite inferior
            double a = UserEntries.GetLowerBound();
            // Limite superior
            double b = UserEntries.GetUpperBound();
            // Erro máximo
            double erroMax = UserEntries.GetMaxError();

            // Calculo de h
            double m = (int)Math.Sqrt((Math.Pow(b - a, 3) * M2) / (erroMax * 12)) + 1;
            double h = (b - a) / m;
            Writer.WriteResult("m vale " + m + "\nh vale " + h + "\n");

            // Calculo da área
            double somafx = 0;
            for (double x = a + h; x < b; x += h)
            {
                somafx += f.calculate(x);
            }
            double Itr = (h / 2) * (f.calculate(a) + 2 * somafx + f.calculate(b));

            // Impressão do resultado
            Writer.WriteResult("Pela regra dos trapézios, a integral da função dada é: " + Itr);
        }
    }
}
