using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class MathClass
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    class FuncActionPredicate
    {
        public delegate TResult Func2<out TResult>();
        public delegate TResult Func2<in T1, out TResult>(T1 t1);
        public delegate TResult Func2<in T1, in T2, out TResult>(T1 t1, T2 t2);

        public FuncActionPredicate()
        {
            MathClass mathClass = new MathClass();

            Func<int, int, int> calc = mathClass.Sum;
            Func<int, int, int> calc2 = delegate (int a, int b) { return a + b; };
            Func<int, int, int> calc3 = (a, b) => a + b;

            var calCustom = (int a, int b) => a + b;

            Console.WriteLine($"Soma: {calCustom(1, 2)}");

            Action<int> imprime = (a) => { Console.WriteLine("ÉOQUE!"); } ;
            imprime(10);

            Predicate<int> isEven = (a) => a % 2 == 0;
            Console.WriteLine($"Is 10 even? {isEven(10)}");
        }
        
    }
}
