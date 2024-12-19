using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IITCalculator
{
    public class TotalIncome : Income
    {
        public TotalIncome(List<MonthIncome> monthIncomes, AnnualOneTimeIncome annualOneTimeIncome)
        {
            _monthIncomes = monthIncomes;
            _annualOneTimeIncome = annualOneTimeIncome;
        }

        private List<MonthIncome> _monthIncomes;
        private AnnualOneTimeIncome _annualOneTimeIncome;

        public override double IncomeMonthly
        {
            get
            {
                var value = 0d;
                foreach (var monthIncome in _monthIncomes)
                    value += monthIncome.IncomeMonthly;
                return value;
            }
        }

        public override double IncomeAnnualOneTime { get { return _annualOneTimeIncome.IncomeAnnualOneTime; } }

        public override double GetIncomeMonthlyToBeTaxed(List<IncomeReduction> incomeReductions)
        {
            var value = 0d;

            foreach (var monthIncome in _monthIncomes)
                value += monthIncome.GetIncomeMonthlyToBeTaxed(incomeReductions);
            return value;
        }

        public override double GetIncomeAnnualOneTimeToBeTaxed(List<IncomeReduction> incomeReductions)
        {
            return _annualOneTimeIncome.GetIncomeAnnualOneTimeToBeTaxed(incomeReductions);
        }

        public static TotalIncome CreateBy(double avaergeMonthIncome, double annualOneTimeIncome)
        {
            var monthIncomes = new List<MonthIncome>();
            for (int i = 1; i <= 12; i++)
                monthIncomes.Add(new MonthIncome((Month)i, avaergeMonthIncome));
            return new TotalIncome(monthIncomes, new AnnualOneTimeIncome(annualOneTimeIncome));
        }
    }
}