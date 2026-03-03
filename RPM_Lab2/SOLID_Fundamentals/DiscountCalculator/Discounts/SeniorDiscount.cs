using SOLID_Fundamentals.DiscountCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.DiscountCalculator.Discounts
{
    internal class SeniorDiscount : IDiscountStrategy
    {
        public decimal Calculate(decimal orderAmount)
        => orderAmount * 0.07m;
    }
}
