using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IITCalculator
{
    public class TaxManager
    {
        public TaxManager(List<TaxItem> taxItems, List<TaxReduction> taxReductions)
        {
            _taxItems = taxItems;
            _taxReductions = taxReductions;
        }

        private List<TaxItem> _taxItems;
        private List<TaxReduction> _taxReductions;
    }
}