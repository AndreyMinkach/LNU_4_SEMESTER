using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        private static double eps = 0.001;

        private static double f(double x)
        {
            return (Math.Sin(x + 2) - x*x + 2 *x - 1);
        }
        private static double df(double x)
        {
            double dx = eps / 100;
            return (f(x + dx) - f(x)) / dx;
        }
        private static double d2f(double x)
        {
            double dx = eps / 100;
            return (f(x + dx) + f(x - dx) - 2 * f(x)) / (double)Math.Pow(dx, 2);
        }
        private static void Newton(double a, double b, double eps, int kmax)
        {
            double dx, x0; int i;
            if (a > b)
            {
                Console.WriteLine("A is bigger than B");
                return;
            }
            if (f(a) * d2f(a) > 0)
                x0 = a;
            else
                x0 = b;
            for (i = 1; i < kmax; i++)
            {
                dx = f(x0) / df(x0);
                x0 -= dx;
                if (Math.Abs(dx) < eps)
                {
                    Console.WriteLine("Result:");
                    Console.WriteLine("\tX = " + x0);
                    Console.WriteLine("\tf(x) = " + f(x0));
                    Console.WriteLine("\tNumber of iteration = " + i);
                    return;
                }
            }
            Console.WriteLine("The root is not found");
            return;
        }

        private static void MPD(double a, double b, double eps)
        {
            double c, fa, fb, fc;
            int i = 0;

            fa = f(a);
            fb = f(b);

            if (Math.Abs(fa) < eps)
            {
                Console.WriteLine("Result:");
                Console.WriteLine("\tX = " + a);
                Console.WriteLine("\tf(x) = " + f(a));
                Console.WriteLine("\tNumber of iteration = " + i);
                return;
            }
            if (Math.Abs(fb) < eps)
            {
                Console.WriteLine("Result:");
                Console.WriteLine("\tX = " + b);
                Console.WriteLine("\tf(x) = " + f(b));
                Console.WriteLine("\tNumber of iteration = " + i);
                return;
            }
            if (b > a)
            {
                if (fa * fb < 0)
                {
                    i = 0;
                    while (b - a > eps)
                    {
                        c = a + 0.5f * (b - a);
                        i += 1;
                        fc = f(c);
                        if (Math.Abs(fc) < eps)
                        {
                            Console.WriteLine("Result:");
                            Console.WriteLine("\tX = " + c);
                            Console.WriteLine("\tf(x) = " + f(c));
                            Console.WriteLine("\tNumber of iteration = " + i);
                            return;
                        }
                        else if (fa * fc > 0)
                        {
                            a = c;
                            fa = fc;
                        }
                        else b = c;
                    }
                    c = a + 0.5f * (b - a);
                    Console.WriteLine("Result:");
                    Console.WriteLine("\tX = " + c);
                    Console.WriteLine("\tf(x) = " + f(c));
                    Console.WriteLine("\tNumber of iteration = " + i);
                    return;
                }
                else
                    Console.WriteLine("There is no root");
            }
            else
                Console.WriteLine("A is bigger than B");
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1 - MPD  0 - Newton");
                bool isMPD = (int.Parse(Console.ReadLine()) == 1) ? true : false;

                Console.WriteLine("A and B");
                var str = Console.ReadLine().Split(' ');
                double a = double.Parse(str[0]);
                double b = double.Parse(str[1]);
                
                if (isMPD)
                {
                    MPD(a, b, eps);
                }
                else
                {
                    Console.WriteLine("enter max iterations");
                    var kmax = int.Parse(Console.ReadLine());
                    Newton(a, b, eps, kmax);
                }
                Console.WriteLine("Write somth");
            } while (Console.ReadLine() != "");
        }

    }
}
