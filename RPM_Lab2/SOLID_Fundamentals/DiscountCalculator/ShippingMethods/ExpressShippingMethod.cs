using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.DiscountCalculator.ShippingMethods
{
    public class ExpressShippingMethod
    {
        public decimal Calculate(decimal weight, string destination) =>
            15.00m + (weight * 1.0m);
    }
}
