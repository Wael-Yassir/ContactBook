using System;
using ContactBook.Data.Models;
using System.Collections.Generic;
using ContactBook.Data.DataProvider;

namespace ContactBook.Data
{
    internal class Program
    {
        static void Main()
        {
            JsonGeneraor.CreateJsonFile();

            Console.ReadLine();
        }
    }
}
