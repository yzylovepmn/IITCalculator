using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IITCalculator
{
    public abstract class Income
    {
        public abstract double IncomeMonthly { get; }

        public abstract double IncomeAnnualOneTime { get; }

        public abstract double GetIncomeMonthlyToBeTaxed(List<IncomeReduction> incomeReductions);

        public abstract double GetIncomeAnnualOneTimeToBeTaxed(List<IncomeReduction> incomeReductions);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}