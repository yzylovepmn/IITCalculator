using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IITCalculator
{
    public class NiuMa
    {
        public NiuMa(string name, TotalIncome income, List<IncomeReduction> incomeReductions, List<TaxReduction> taxReductions)
        {
            _name = name;
            _income = income;
            _incomeReductions = incomeReductions;
            _taxReductions = taxReductions;
        }

        public string Name { get { return _name; } }
        private string _name;

        public TotalIncome Income { get { return _income; } }
        private TotalIncome _income;

        public IReadOnlyList<IncomeReduction> IncomeReductions { get { return _incomeReductions; } }
        private List<IncomeReduction> _incomeReductions;

        public IReadOnlyList<TaxReduction> TaxReductions { get { return _taxReductions; } }
        private List<TaxReduction> _taxReductions;

        public double GetIncomeMonthlyToBeTaxed()
        {
            var incomeToBeTaxed = _income.GetIncomeMonthlyToBeTaxed(_incomeReductions);
            foreach (var taxReduction in _taxReductions)
                incomeToBeTaxed -= taxReduction.GetReduction();
            return Math.Max(incomeToBeTaxed, 0);
        }

        public double GetIncomeAnnualOneTimeToBeTaxed()
        {
            return Math.Max(_income.GetIncomeAnnualOneTimeToBeTaxed(_incomeReductions), 0);
        }
    }
}