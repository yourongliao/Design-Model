using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 依赖倒置
{
    class Program
    {
        static void Main(string[] args)
        {
            TestA a = new TestA();

            Console.WriteLine(a.Add(1,2));

            TestB b = new TestB();

            Console.WriteLine(b.Minus(4, 2));

            Console.ReadKey();
        }

        public class TestA
        {

            public int Add(int a,int b)
            {
                return a + b;
            }
        }

        public class TestB
        {
            public int Minus(int a, int b)
            {
                return a - b;
            }
        }
    }

}
