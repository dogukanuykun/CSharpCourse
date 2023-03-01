using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

    }

    interface IProduct
    {
        List<Product> GetAll();
        Product Get(int id);
    }

}
