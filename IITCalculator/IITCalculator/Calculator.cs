using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IITCalculator
{
    public class Calculator
    {
        public static double CalculateTaxedIncome(NiuMa niuMa, TaxManager taxManager)
        {
            var incomeMonthlyToBeTaxed = niuMa.GetIncomeMonthlyToBeTaxed();
            var incomeAnnualOneTimeToBeTaxed = niuMa.GetIncomeAnnualOneTimeToBeTaxed();

            var taxOfIncomeMonthly = taxManager.IITTaxPass(incomeMonthlyToBeTaxed);
            var taxOfIncomeAnnualOneTime = taxManager.AnnualTaxPass(incomeAnnualOneTimeToBeTaxed);
            var totalTax = taxOfIncomeMonthly + taxOfIncomeAnnualOneTime;
            var totalIncome = niuMa.Income.IncomeAnnualOneTime + niuMa.Income.IncomeMonthly;
            var taxedTotalIncome = totalIncome - totalTax;
            return taxedTotalIncome;
        }

        public static List<(NiuMa, double)> FindBestNiuMaList(TaxManager taxManager)
        {
            var list = NiuMaList.InitializeAnonymousNiuMaList();
            var taxedTotalIncomeList = list.Select(niuMa => (niuMa, CalculateTaxedIncome(niuMa, taxManager))).ToList().OrderByDescending(ret => ret.Item2);
            return taxedTotalIncomeList.ToList();
        }
    }
}