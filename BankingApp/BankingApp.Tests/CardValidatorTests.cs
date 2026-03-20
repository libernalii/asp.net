using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp.Tests
{
    public class CardValidatorTests
    {
        private readonly CardValidator _validator = new CardValidator();

        [Fact]
        public void ValidCard_ReturnsTrue()
        {
            Assert.True(_validator.IsValid("4539578763621486"));
        }

        [Fact]
        public void InvalidCard_ReturnsFalse()
        {
            Assert.False(_validator.IsValid("1234567890123456"));
        }
    }
}
