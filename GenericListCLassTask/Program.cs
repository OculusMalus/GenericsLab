using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListCLassTask
{
    class Program
    {

        static void Main(string[] args)
        {
            GenericList<string> vegetables = new GenericList<string>()
            {
                "carrot", "onion", "broccoli", "beets", "okra","tomato", "celery" 
            };

            GenericList<string> randomWords = new GenericList<string>()
            {
                "belch", "lichen", "brother", "quartz", "carafe"
            };


            vegetables.Add("cucumber");


            Console.WriteLine("");
            Console.ReadKey();

            vegetables.Remove("broccoli");
            Console.ReadKey();

            vegetables.ToString();
            Console.ReadKey();

            vegetables.SortList(vegetables);
       
        }
    }
}
