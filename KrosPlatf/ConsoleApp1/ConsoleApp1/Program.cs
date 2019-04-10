using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Newton
{
    class Program
    {
        static double e = 0.01;
        static double func(double x)
        {
            return x - 2;
        }
        static double deriveredFunc(double x)
        {
            double d = e / 100;
            return (func(x + d) - func(x)) / d;
        }
        static void newton(double x)
        {
            double h = func(x) / deriveredFunc(x);
            int cnt = 0;
            while (Math.Abs(h) >= e)
            {
                cnt++;
                h = func(x) / deriveredFunc(x);
                x = x - h;
            }
            Console.WriteLine("korin" + (x * 100.0 / 100.0));
            Console.WriteLine("Kilkist iteraciy : " + cnt);
        }
        public static void Main()
        {
            Console.WriteLine("vvedit x0");
            double x0 = double.Parse(Console.ReadLine());
            newton(x0);
        }
    }

}