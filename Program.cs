using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingTriangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<double> calculatingArea = null;
            double triangleHeight;
            double triangleBase;

            CheckInput(out triangleHeight, "height");
            CheckInput(out triangleBase, "base");

            calculatingArea = new Task<double>(() =>
            {
                return (triangleHeight * triangleBase) / 2;
            });

            calculatingArea.Start();
            calculatingArea.Wait();

            Console.Clear();
            Console.WriteLine($"  Result: {calculatingArea.Result}\n");
            Console.ReadKey();
        }

        static void CheckInput(out double value, string valueName)
        {
            bool incorrect = false;

            do
            {
                Console.Clear();
                if (incorrect) Console.WriteLine(" Your previous input was incorrect, check your input and try again!");
                Console.Write($"\n Enter triangle {valueName}: ");
            } while (incorrect = !Double.TryParse(Console.ReadLine(), out value));
        }
    }
}
