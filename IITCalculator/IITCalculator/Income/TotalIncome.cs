using Newtonsoft.Json;
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

        public IReadOnlyList<MonthIncome> MonthIncomes { get { return _monthIncomes; } }
        private List<MonthIncome> _monthIncomes;

        public AnnualOneTimeIncome AnnualOneTimeIncome { get { return _annualOneTimeIncome; } }
        private AnnualOneTimeIncome _annualOneTimeIncome;

        public override double Value
        {
            get
            {
                var value = 0d;
                foreach (var monthIncome in _monthIncomes)
                    value += monthIncome.Value;
                value += _annualOneTimeIncome.Value;
                return value;
            }
        }

        public override double ValueToBeTaxed => throw new NotImplementedException();

        public static TotalIncome CreateBy(double avaergeMonthIncome, double annualOneTimeIncome)
        {
            var monthIncomes = new List<MonthIncome>();
            for (int i = 1; i <= 12; i++)
                monthIncomes.Add(new MonthIncome((Month)i, avaergeMonthIncome));
            return new TotalIncome(monthIncomes, new AnnualOneTimeIncome(annualOneTimeIncome));
        }
    }
}