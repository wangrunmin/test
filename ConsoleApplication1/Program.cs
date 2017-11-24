using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var flag = 1;
            string a = null ?? flag++.ToString();
            string b = a ?? flag++.ToString();
            Console.WriteLine(flag);
        }
    }
}

