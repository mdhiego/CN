using System;

namespace Integrate
{
    class Writer
    {
        public static void WriteTitle(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteHeader(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteSubHeader(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteResult(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
