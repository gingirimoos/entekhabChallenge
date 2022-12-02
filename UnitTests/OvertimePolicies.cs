using OvetimePolicies;
using Xunit;

namespace UnitTests
{
    public class OvertimePolicies
    {
        [Fact]
        public void CalculatorA_ShuouldWork()
        {
            Assert.Equal(1550000, Payment.CalcurlatorA(1000000, 550000));
        }

        [Fact]
        public void CalcurlatorB_ShuouldWork()
        {
            Assert.Equal(1550000, Payment.CalcurlatorB(1000000, 550000));
        }


        [Fact]
        public void CalcurlatorC_ShuouldWork()
        {
            Assert.Equal(1550000, Payment.CalcurlatorC(1000000, 550000));
        }

    }
}
