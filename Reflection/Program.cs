using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(2,3);
            //Console.WriteLine(dortIslem.Topla2());
            //Console.WriteLine(dortIslem.Topla(3, 2));
            var type = typeof(Calc);

            //Calc calc = (Calc)Activator.CreateInstance(type, 2 ,3);
            //Console.WriteLine(calc.Sum(3,5));

            var instance = (Calc)Activator.CreateInstance(type, 2, 3);
            MethodInfo methodInfo = instance.GetType().GetMethod("Sum2");

            Console.WriteLine(methodInfo.Invoke(instance, null));

            Console.WriteLine("------------------");

            var methods = type.GetMethods();

            foreach ( var method in methods )
            {
                Console.WriteLine("Method name: {0}",method.Name);
                foreach (var variable in method.GetParameters())
                {
                    Console.WriteLine("     Parameter: {0}", variable.Name);
                }

                foreach (var attribute in method.GetCustomAttributes())
                {
                    Console.WriteLine("     Attribute: {0}", attribute.GetType().Name);
                }

            }

            Console.ReadLine();
            
        }
    }

    public class Calc 
    {

        private int _num1, _num2;

        public Calc(int num1, int num2)
        {
            _num1 = num1;
            _num2 = num2;
        }


        public int Sum (int num1, int num2)
        {
            return num1 + num2;
        }

        public int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }
        public int Sum2()
        {
            return _num1 + _num2;
        }

        [MethodName("Carpma")]
        public int Multiply2()
        {
            return _num1 * _num2;
        }



    }


    public class MethodNameAttribute : Attribute
    {
        private string _name;

        public MethodNameAttribute(string name)
        {
            this._name = name;
        }
    }

}
