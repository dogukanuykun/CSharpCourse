using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{

    public delegate void MyDelegate();
    public delegate void MyDelegate2(string text);
    public delegate int MyDelegate3(int num1, int num2);

    internal class Program  
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();


            MyDelegate myDelegate = customerManager.SendMessage;
            myDelegate += customerManager.ShowAlert;

            myDelegate -= customerManager.SendMessage;

            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2 += customerManager.ShowAlert2;


            myDelegate2 -= customerManager.SendMessage2;


            myDelegate2("mister");

            Math math  = new Math();
            MyDelegate3 myDelegate3 = math.Sum;
            myDelegate3 += math.Multiply;
            var result = myDelegate3(3,2);//The last delegate function will be returned (Multiply). 
            Console.WriteLine(result);

            //myDelegate();



            Console.ReadLine();
        }
    }

    public class Math
    {
        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }
    }

    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello!");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Be careful!");
        }

        public void SendMessage2(string message)
        {
            Console.WriteLine("Hello {0}!", message);
        }

        public void ShowAlert2( string message )
        {
            Console.WriteLine("Be careful {0}", message);
        }

    }



}
