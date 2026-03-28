using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp
{
    public class CardValidator
    {
        public bool IsValid(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return false;

            if (cardNumber.Length != 16 || !cardNumber.All(char.IsDigit))
                return false;

            return LuhnCheck(cardNumber);
        }

        private bool LuhnCheck(string number)
        {
            int sum = 0;
            bool alternate = false;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int n = number[i] - '0';

                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                        n -= 9;
                }

                sum += n;
                alternate = !alternate;
            }

            return sum % 10 == 0;
        }
    }
}
