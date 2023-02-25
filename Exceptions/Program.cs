using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
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

        private static void Find()
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
