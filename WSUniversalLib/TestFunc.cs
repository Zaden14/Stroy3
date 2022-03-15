using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    class TestFunc
    {
        public int summ(int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            TestFunc tf = new TestFunc();
            int rez;
            rez = tf.summ(5,7);
            Console.WriteLine(Convert.ToString(rez));
            Console.ReadLine();
        }
    }
}
