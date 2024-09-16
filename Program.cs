using System.Text.RegularExpressions;

namespace CachingServer
{
    using System.Text.RegularExpressions;

    internal class Program
    {
        static string strCommand = "";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Caching Server. Please write a command:");

            // Valida y procesa comandos
            while (!ValidateCommand(Console.ReadLine()))
            {
                Console.WriteLine("Command not found. Please try again:");
            }

            // Si el comando es válido, se procesa
            ReadConsole(strCommand);
        }

        internal static void ReadConsole(string strtext)
        {
            if (strtext == "exit")
            {
                Console.WriteLine("Exiting the program.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"Processing command: {strtext}");
               ValidateCommand(strtext);
            }
        }

        internal static bool ValidateCommand(string input)
        {
            Regex regex = new(@"^caching-proxy(\s+--port\s+\d{1,5}\s+--origin\s+https?:\/\/[^\s]+)?(\s+--clear-cache)?$");

            if (!string.IsNullOrEmpty(input) && regex.IsMatch(input))
            {
                strCommand = input; // Almacena el comando válido
                return true;
            }

            return false;
        }
    }
}