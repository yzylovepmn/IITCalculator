using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IITCalculator
{
    public abstract class IncomeReduction
    {
        public abstract double CalculateReduction(TotalIncome totalIncome);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public class FixedIncomeReduction : IncomeReduction
    {
        public FixedIncomeReduction(string name, double reduction)
        {
            _name = name;
            _reduction = reduction;
        }

        public string Name { get { return _name; } }
        private string _name;

        public double Reduction { get { return _reduction; } }
        private double _reduction;

        public override double CalculateReduction(TotalIncome totalIncome)
        {
            return _reduction;
        }
    }

    public class RatioIncomeReduction : IncomeReduction
    {
        public RatioIncomeReduction(string name, double ratio, double baseValue)
        {
            _name = name;
            _ratio = ratio;
            _baseValue = baseValue;
        }

        public string Name { get { return _name; } }
        private string _name;

        public double Ratio { get { return _ratio; } }
        private double _ratio;

        public double BaseValue { get { return _baseValue; } }
        private double _baseValue;

        public override double CalculateReduction(TotalIncome totalIncome)
        {
            return _reduction;
        }
    }
}