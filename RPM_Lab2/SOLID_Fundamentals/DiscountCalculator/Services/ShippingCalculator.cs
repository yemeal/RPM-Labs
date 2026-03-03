using SOLID_Fundamentals.DiscountCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.DiscountCalculator.Services
{
    public class ShippingCalculator
    {
        private readonly IShippingMethod _shippingMethod;
        public ShippingCalculator(IShippingMethod shippingMethod)
        {
            _shippingMethod = shippingMethod;
        }
        public decimal Calculate(decimal weight, string destination)
        {
            return _shippingMethod.Calculate(weight, destination);
        }
    }
}
