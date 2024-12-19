using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IITCalculator
{
    public class TaxItem
    {
        public TaxItem(double low, double high, double taxRate)
        {
            _low = low;
            _high = high;
            _taxRate = taxRate;
        }

        private double _low;
        private double _high;
        private double _taxRate;
    }
}