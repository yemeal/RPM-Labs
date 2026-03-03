using SOLID_Fundamentals.DiscountCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.DiscountCalculator.ShippingMethods
{
    public class OvernightShippingMethod : IShippingMethod
    {
        public decimal Calculate(decimal weight, string destination) =>
            25.00m + (weight * 2.0m);
    }
}
