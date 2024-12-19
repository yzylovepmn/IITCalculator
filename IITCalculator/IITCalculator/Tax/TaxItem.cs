using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IITCalculator
{
    public class TaxItem
    {
        public TaxItem(double low, double high, double taxRate, double fastReduction = 0)
        {
            _low = low;
            _high = high;
            _taxRate = taxRate;
            _fastReduction = fastReduction;
        }

        public double Low { get { return _low; } }
        private double _low;

        public double High { get { return _high; } }
        private double _high;

        public double TaxRate { get { return _taxRate; } }
        private double _taxRate;

        public double FastReduction { get { return _fastReduction; } }
        private double _fastReduction;
    }
}