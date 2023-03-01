using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Func<int, int, int> add = Sum;
            
            Console.WriteLine(add(3,5));

            Func<int> getRandomNumber = delegate ()
            {
                Random random = new Random();
                return random.Next(1, 100);
            };

            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);

            Console.WriteLine(getRandomNumber());
            Thread.Sleep(1000);
            Console.WriteLine(getRandomNumber2());
            //Console.WriteLine(Sum(2, 3));

        }

        static int Sum(int x, int y)
        {
            return x + y;
        }

        private static void ActionDemo()
        {
            HandleException(() =>
            {
                Find();
            });
        }

        private static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static void Find() //Basic function for handling errors
        {
            List<string> students = new List<string> { "Doğukan", "Tuna", "Ömer"};
            if (!students.Contains("Ahmet"))
            {
                throw new RecordNotFoundException("Record not Found!");

            }
            else
            {
                Console.WriteLine("REcord Found!");
            }
        }
    }
}
