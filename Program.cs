using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberToConvert = ReadFromConsole("Enter number to convert");
            int numberSystemBase = ReadFromConsole("Enter base of the new number system from 2 to 20");

            while (numberSystemBase < 2 || numberSystemBase > 20)
            {
                numberSystemBase = ReadFromConsole("Enter base of the new number system from 2 to 20");
            }

            Console.WriteLine(ConvertToNumberSystem(numberToConvert, numberSystemBase));
        }

        private static int ReadFromConsole(string message)
        {
            Console.WriteLine(message);
            string inputFromConsole = Console.ReadLine();
            int number;

            while (!int.TryParse(inputFromConsole, out number))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                inputFromConsole = Console.ReadLine();
            }

            return number;

        }


        static string ConvertToNumberSystem(int number, int numberSystemBase)
        {
            if (number == 0) return "0";

            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            var result = new StringBuilder();
            int remainder;

            if (number > 0)
            {
                while (number > 0)
                {
                    remainder = number % numberSystemBase;
                    number /= numberSystemBase;

                    if (remainder > 9)
                    {
                        remainder -= 9;
                        result.Insert(0, letters[remainder - 1]);
                    }
                    else
                    {
                        result.Insert(0, remainder);
                    }
                }
            }
            else
            {
                return $"-{ConvertToNumberSystem(Math.Abs(number), numberSystemBase)}";
            }

            return result.ToString();
        }        
    }
}
