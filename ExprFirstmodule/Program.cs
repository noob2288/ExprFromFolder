using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExprFirstmodule
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "My first app";
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Yellow;

            ExecuteFirstExpr();

            ExecuteSecondExpr();

            ExecuteThirdExpr();

            ExecuteFourthExpr();

            ExecuteFifthExpr();

            ExecuteSixthExpr();
            
            Console.WriteLine("some text to add in web IDE");

            Console.ReadLine();
        }

        #region Expr1
        private static void ExecuteFirstExpr()
        {
            Console.WriteLine("Expr1");
            int a = 5;
            int b = 7;
            Console.WriteLine($"a: {a}");
            Console.WriteLine($"b: {b}");
            Swap(ref a, ref b);
            Console.WriteLine("After swap");
            Console.WriteLine($"a: {a}");
            Console.WriteLine($"b: {b}");
            Console.WriteLine();
            Swap(a, b);
        }

        /// <summary>
        /// Swap without temporary variable
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Swap(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }

        /// <summary>
        /// Swap with temporary variable
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Swap(int a, int b)
        {
            Console.WriteLine($"a: {a}");
            Console.WriteLine($"b: {b}");
            int c = a;
            a = b;
            b = c;
            Console.WriteLine("After Swap");
            Console.WriteLine($"a: {a}");
            Console.WriteLine($"b: {b}");
            Console.WriteLine();

        }
        #endregion

        #region Expr2
        private static void ExecuteSecondExpr()
        {
            Console.WriteLine("Expr2");
            Console.Write("Enter a number to deploy it: ");
            int.TryParse(Console.ReadLine(), out int expr2Num);
            Console.WriteLine($"Before Deploying: {expr2Num}");
            Console.WriteLine($"After Deploying: {DeployNumber(expr2Num)}\n");
        }
        private static int DeployNumber(int number)
        {
            int countDigit = NumberLength(number);
            int result = 0;
            for (int i = 0; i < countDigit; i++)
            {
                int digit = number / (int)Math.Pow(10, (countDigit - i - 1));
                digit = digit % 10;
                result += digit * (int)Math.Pow(10, i);
            }
            return result;
        }

        private static int NumberLength(int number)
        {
            int countDigit = 0;
            while (number != 0)
            {
                number /= 10;
                countDigit++;
            }
            return countDigit;
        }

        #endregion

        #region Expr3
        private static void ExecuteThirdExpr()
        {
            Console.WriteLine("Expr3");
            Console.Write("Enter Hour: ");
            int hour = int.Parse(Console.ReadLine());
            Console.WriteLine($"Angle between hourhand and minutehand {FindAngle(hour)}\n");
        }
        public static int FindAngle(int hour)
        {
            const int oneHourAngle = 30;
            int angle = oneHourAngle * Math.Abs(12 - hour);
            return Math.Min(angle, 360 - angle);
        }
        #endregion

        #region Expr4
        private static void ExecuteFourthExpr()
        {
            Console.WriteLine("Expr4");
            Console.Write("Enter N: ");
            int nN = int.Parse(Console.ReadLine());
            Console.Write("Enter X (prime Number): ");
            int xX = int.Parse(Console.ReadLine());
            Console.Write("Enter Y (prime Number): ");
            int yY = int.Parse(Console.ReadLine());
            Console.WriteLine($"Кількість чисел що мають ці дільники {PrimeNumbers(nN, xX, yY)}");
        }

        public static int PrimeNumbers(int N, int X, int Y)
        {
            int countNumbers = 0;

            try
            {
                if (!(IsPrime(X) && IsPrime(Y) && (N > X && N > Y)))
                {
                    throw new ArgumentException("Числа Х i Y повинні бути простими і меншими ніж N");
                }
                for (int i = 1; i < N; i++)
                {
                    if (i % X == 0 || i % Y == 0) countNumbers++;
                }
                return countNumbers;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }

        }

        private static bool IsPrime(int number)
        {
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Expr5
        /// <summary>
        /// Кількість високосних років на проміжку [a; b]
        /// </summary>
        /// <param name="a">Початковий рік включно</param>
        /// <param name="b">Кінцевий рік включно</param>
        /// <returns>Кількість високосних років</returns>
        public static int LeapYearCount(int a, int b)
        {
            int countLeapYear = 0;

            int firstYearWith4 = a + (4 - a % 4);
            if (a % 4 == 0) firstYearWith4 -= 4;
            int lastYearWith4 = b - b % 4;
            if (firstYearWith4 > lastYearWith4) return 0;
            countLeapYear += (lastYearWith4 - firstYearWith4) / 4 + 1;


            int firstYearWith100 = a + (100 - a % 100);
            if (a % 100 == 0) firstYearWith4 -= 100;
            int lastYearWith100 = b - b % 100;
            if (firstYearWith100 <= lastYearWith100) countLeapYear -= (lastYearWith100 - firstYearWith100) / 100 + 1;

            int firstYearWith400 = a + (400 - a % 400);
            if (a % 400 == 0) firstYearWith4 -= 400;
            int lastYearWith400 = b - b % 400;
            if (firstYearWith400 <= lastYearWith400) countLeapYear += (lastYearWith400 - firstYearWith400) / 400 + 1;


            return countLeapYear;
        }

        private static void ExecuteFifthExpr()
        {
            Console.WriteLine("Expr5");
            Console.Write("Enter first year: ");
            int firstYear = int.Parse(Console.ReadLine());

            Console.Write("Enter second year: ");
            int secondYear = int.Parse(Console.ReadLine());
            Console.WriteLine($"Кількість високосних років на проміжку" +
                $" [{firstYear}; {secondYear}] - {LeapYearCount(firstYear, secondYear)}");
        }
        #endregion

        #region Expr6
        private static void ExecuteSixthExpr()
        {
            Console.WriteLine("Expr6");
            Console.WriteLine("Введіть координати прямої");
            Console.Write("X1: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Y1: ");
            double y1 = double.Parse(Console.ReadLine());
            Console.Write("X2: ");
            double x2 = double.Parse(Console.ReadLine());
            Console.Write("Y2: ");
            double y2 = double.Parse(Console.ReadLine());
            Straight straight = new Straight(x1, y1, x2, y2);
            straight.PrintInfo();

            Console.WriteLine("Введіть координати точки");
            Console.Write("X: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Y: ");
            double y = double.Parse(Console.ReadLine());
            Point point = new Point(x, y);
            point.PrintInfo();

            Console.WriteLine($"Відстань від точки до прямої: {FindDistancePointStraight(point, straight)}");
        }
        public static double FindDistancePointStraight(Point point, Straight straight)
        {
            Point middleStraight = straight.FindMiddleStraight();
            return point.FindDistance(middleStraight);
        }
        #endregion


    }
}
