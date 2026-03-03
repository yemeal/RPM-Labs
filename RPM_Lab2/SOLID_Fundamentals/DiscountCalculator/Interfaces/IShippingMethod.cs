using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Fundamentals.DiscountCalculator.Interfaces
{
    public interface IShippingMethod
    {
        decimal Calculate(decimal weight, string destination);
    }
}
