using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp
{
    public class DepositCalculator
    {
        public decimal Calculate(decimal amount, int months, decimal yearlyRate = 0.1m)
        {
            decimal monthlyRate = yearlyRate / 12;

            for (int i = 0; i < months; i++)
            {
                amount += amount * monthlyRate;
            }

            return amount;
        }
    }
}
