using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IITCalculator
{
    public class NiuMaList
    {
        static NiuMaList()
        {
            _anonymousNiuMa = InitializeAnonymousNiuMa();
        }

        public static NiuMa AnonymousNiuMa { get { return _anonymousNiuMa; } }
        private static NiuMa _anonymousNiuMa;

        public static NiuMa InitializeAnonymousNiuMa()
        {
            var monthIncome = 10000;
            var annualOneTimeIncome = 30000;
            var income = TotalIncome.CreateBy(monthIncome, annualOneTimeIncome);
            var incomeReductions = new List<IncomeReduction>();
            incomeReductions.Add(new RatioIncomeReduction("养老保险", 0.08, monthIncome));
            incomeReductions.Add(new RatioIncomeReduction("医疗保险", 0.02, monthIncome));
            incomeReductions.Add(new RatioIncomeReduction("工伤保险", 0, monthIncome));
            incomeReductions.Add(new RatioIncomeReduction("失业保险", 0.002, monthIncome));
            incomeReductions.Add(new RatioIncomeReduction("生育保险", 0, monthIncome));
            incomeReductions.Add(new RatioIncomeReduction("公积金", 0.12, monthIncome));

            var taxReductions = new List<TaxReduction>();
            taxReductions.Add(new FixedTaxReduction("租房专项扣除", 1500 * 12));
            // Add needed

            return new NiuMa("AnonymousNiuMa", income, incomeReductions, taxReductions);
        }

        public static List<NiuMa> InitializeAnonymousNiuMaList()
        {
            var niuMaList = new List<NiuMa>();

            var incomeReductions = new List<IncomeReduction>();
            incomeReductions.Add(new RatioIncomeReduction("养老保险", 0.08, 26421));
            incomeReductions.Add(new RatioIncomeReduction("医疗保险", 0.02, 32376));
            incomeReductions.Add(new RatioIncomeReduction("工伤保险", 0, 43000));
            incomeReductions.Add(new RatioIncomeReduction("失业保险", 0.002, 43000));
            incomeReductions.Add(new RatioIncomeReduction("生育保险", 0, 32376));
            incomeReductions.Add(new RatioIncomeReduction("公积金", 0.12, 43659));

            var taxReductions = new List<TaxReduction>();
            taxReductions.Add(new FixedTaxReduction("租房专项扣除", 1500 * 12));

            var step = 500;
            var start = 44000;
            var end = 60000;
            var totalIncome = 792000;
            for (int i = start; i <= end; i += step)
            {
                var monthIncome = i;
                var income = TotalIncome.CreateBy(monthIncome, totalIncome - monthIncome * 12);
                niuMaList.Add(new NiuMa("AnonymousNiuMa", income, incomeReductions, taxReductions));
            }

            return niuMaList;
        }
    }
}