using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IITCalculator
{
    public class AnnualOneTimeIncome : Income
    {
        public AnnualOneTimeIncome(double annualncome)
        {
            _annualncome = annualncome;
        }

        public override double IncomeMonthly { get { return 0; } }

        public override double IncomeAnnualOneTime { get { return _annualncome; } }
        private double _annualncome;

        public override double GetIncomeMonthlyToBeTaxed(List<IncomeReduction> incomeReductions)
        {
            return 0;
        }

        public override double GetIncomeAnnualOneTimeToBeTaxed(List<IncomeReduction> incomeReductions)
        {
            var value = IncomeAnnualOneTime;

            foreach (var incomeReduction in incomeReductions)
            {
                if (incomeReduction.Type != TimePeriod.Year)
                    continue;

                value -= incomeReduction.CalculateReduction(this);
            }

            return value;
        }
    }
}