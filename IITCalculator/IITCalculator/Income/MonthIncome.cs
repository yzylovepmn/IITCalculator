using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IITCalculator
{
    public class MonthIncome : Income
    {
        public MonthIncome(Month month, double monthIncome, List<IncomeReduction> incomeReductions)
        {
            _month = month;
            _monthIncome = monthIncome;
            _incomeReductions = incomeReductions;
        }

        public Month Month { get { return _month; } }
        private Month _month;

        public override double Value { get { return _monthIncome; } }

        public override double ValueToBeTaxed => throw new NotImplementedException();

        private double _monthIncome;
        private List<IncomeReduction> _incomeReductions;
    }
}