using SOLID_Fundamentals.DiscountCalculator.Interfaces;

namespace SOLID_Fundamentals.DiscountCalculator.Services
{
    public class DiscountService
    {
        private readonly IDiscountStrategy _discountStartegy;

        public DiscountService(IDiscountStrategy discountStartegy)
        {
            _discountStartegy = discountStartegy;
        }

        public decimal Calculate(decimal orderAmount)
        {
            return _discountStartegy.Calculate(orderAmount);
        }

        
    }
}
