using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IITCalculator
{
    public class TaxManager
    {
        public static TaxManager TaxManagerChina
        {
            get
            {
                if (_taxManagerChina == null)
                    _taxManagerChina = CreateTaxManagerInChina();
                return _taxManagerChina;
            }
        }
        private static TaxManager _taxManagerChina;

        public TaxManager(List<TaxItem> iitTaxItems, List<TaxItem> annualTaxItems, double freeTaxValue)
        {
            _iitTaxItems = iitTaxItems;
            _annualTaxItems = annualTaxItems;
            _freeTaxValue = freeTaxValue;
        }

        public IReadOnlyList<TaxItem> IITTaxItems { get { return _iitTaxItems; } }
        private List<TaxItem> _iitTaxItems;

        public IReadOnlyList<TaxItem> AnnualTaxItems { get { return _annualTaxItems; } }
        private List<TaxItem> _annualTaxItems;

        public double FreeTaxValue { get { return _freeTaxValue; } }
        private double _freeTaxValue;

        public double IITTaxPass(double incomeMonthlyToBeTaxed)
        {
            var incomePassIn = incomeMonthlyToBeTaxed - _freeTaxValue;
            var valueTaxed = 0d;
            foreach (var iitTaxItem in _iitTaxItems)
            {
                if (incomePassIn < iitTaxItem.Low)
                    continue;

                var incomeToBeTaxed = Math.Min(incomePassIn - iitTaxItem.Low, iitTaxItem.High - iitTaxItem.Low);
                valueTaxed += incomeToBeTaxed * iitTaxItem.TaxRate;
            }

            return valueTaxed;
        }

        public double AnnualTaxPass(double incomeAnnualOneTimeToBeTaxed)
        {
            var incomePassIn = incomeAnnualOneTimeToBeTaxed / 12;
            var valueTaxed = 0d;
            foreach (var annualTaxItem in _annualTaxItems)
            {
                if (incomePassIn < annualTaxItem.Low || incomePassIn > annualTaxItem.High)
                    continue;

                valueTaxed += incomeAnnualOneTimeToBeTaxed * annualTaxItem.TaxRate - annualTaxItem.FastReduction;
                break;
            }

            return valueTaxed;
        }

        public static TaxManager CreateTaxManagerInChina()
        {
            var iitTaxItems = new List<TaxItem>();
            iitTaxItems.Add(new TaxItem(0, 36000, 0.03));
            iitTaxItems.Add(new TaxItem(36000, 144000, 0.1));
            iitTaxItems.Add(new TaxItem(144000, 300000, 0.2));
            iitTaxItems.Add(new TaxItem(300000, 420000, 0.25));
            iitTaxItems.Add(new TaxItem(420000, 660000, 0.3));
            iitTaxItems.Add(new TaxItem(660000, 960000, 0.35));
            iitTaxItems.Add(new TaxItem(960000, double.MaxValue, 0.45));

            var _annualTaxItems = new List<TaxItem>();
            _annualTaxItems.Add(new TaxItem(0, 3000, 0.03, 0));
            _annualTaxItems.Add(new TaxItem(3000, 12000, 0.1, 210));
            _annualTaxItems.Add(new TaxItem(12000, 25000, 0.2, 1410));
            _annualTaxItems.Add(new TaxItem(25000, 35000, 0.25, 2660));
            _annualTaxItems.Add(new TaxItem(35000, 55000, 0.3, 4410));
            _annualTaxItems.Add(new TaxItem(55000, 80000, 0.35, 7160));
            _annualTaxItems.Add(new TaxItem(80000, double.MaxValue, 0.45, 15160));

            return new TaxManager(iitTaxItems, _annualTaxItems, 60000);
        }
    }
}