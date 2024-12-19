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

        public override double Value { get { return _annualncome; } }

        public override double ValueToBeTaxed { get { return _annualncome; } }

        private double _annualncome;
    }
}