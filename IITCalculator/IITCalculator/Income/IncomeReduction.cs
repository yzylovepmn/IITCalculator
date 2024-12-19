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
        public IncomeReduction(TimePeriod type)
        {
            _type = type;
        }

        public TimePeriod Type { get { return _type; } }
        protected TimePeriod _type;

        public abstract double CalculateReduction(Income income);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public class FixedIncomeReduction : IncomeReduction
    {
        public FixedIncomeReduction(string name, double reduction, TimePeriod incomeReductionType = TimePeriod.Month) : base(incomeReductionType)
        {
            _name = name;
            _reduction = reduction;
        }

        public string Name { get { return _name; } }
        private string _name;

        public double Reduction { get { return _reduction; } }
        private double _reduction;

        public override double CalculateReduction(Income income)
        {
            return _reduction;
        }
    }

    public class RatioIncomeReduction : IncomeReduction
    {
        public RatioIncomeReduction(string name, double ratio, double baseValue, TimePeriod incomeReductionType = TimePeriod.Month) : base(incomeReductionType)
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

        public override double CalculateReduction(Income income)
        {
            if (income != null)
            {
                var value = Math.Min(income.IncomeMonthly, _baseValue);
                return value * _ratio;
            }
            return 0;
        }
    }
}