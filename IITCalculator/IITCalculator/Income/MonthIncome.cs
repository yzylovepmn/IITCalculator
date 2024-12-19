using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IITCalculator
{
    public class MonthIncome : Income
    {
        public MonthIncome(Month month, double monthIncome)
        {
            _month = month;
            _monthIncome = monthIncome;
        }

        public Month Month { get { return _month; } }
        private Month _month;

        public override double IncomeMonthly { get { return _monthIncome; } }
        private double _monthIncome;

        public override double IncomeAnnualOneTime { get { return 0; } }

        public override double GetIncomeMonthlyToBeTaxed(List<IncomeReduction> incomeReductions)
        {
            var value = IncomeMonthly;

            foreach (var incomeReduction in incomeReductions)
            {
                if (incomeReduction.Type != TimePeriod.Month)
                    continue;

                value -= incomeReduction.CalculateReduction(this);
            }

            return value;
        }

        public override double GetIncomeAnnualOneTimeToBeTaxed(List<IncomeReduction> incomeReductions)
        {
            return IncomeAnnualOneTime;
        }
    }
}