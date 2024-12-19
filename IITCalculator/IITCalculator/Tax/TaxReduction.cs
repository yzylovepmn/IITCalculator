using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IITCalculator
{
    public abstract class TaxReduction
    {
        public abstract double GetReduction();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public class FixedTaxReduction : TaxReduction
    {
        public FixedTaxReduction(string name, double reduction)
        {
            _name = name;
            _reduction = reduction;
        }

        public string Name { get { return _name; } }
        private string _name;

        public double Reduction { get { return _reduction; } }
        private double _reduction;

        public override double GetReduction()
        {
            return _reduction;
        }
    }
}