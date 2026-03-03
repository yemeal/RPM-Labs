using SOLID_Fundamentals.DiscountCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.DiscountCalculator.ShippingMethods
{
    public class StandartShippingMethod : IShippingMethod
    {
        public decimal Calculate(decimal weight, string destination) => 
            5.00m + (weight * 0.5m);
    }
}
