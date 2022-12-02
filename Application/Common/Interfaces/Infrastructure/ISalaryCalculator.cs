using Domain.Entities;

namespace Application.Common.Interfaces.Infrastructure
{
    public interface ISalaryCalculator
    {
        public double CalcurlateSalary(PaymentInformation paymentInformation, string overTimeCalculator);
    }
}
