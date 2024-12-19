using IITCalculator;
using Newtonsoft.Json;
using System;

namespace IIT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bestNiuMaList = Calculator.FindBestNiuMaList(TaxManager.TaxManagerChina);
            Console.WriteLine(JsonConvert.SerializeObject(bestNiuMaList, Formatting.Indented));
        }
    }
}