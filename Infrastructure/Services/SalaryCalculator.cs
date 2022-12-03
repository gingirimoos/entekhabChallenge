using System;
using Application.Common.Interfaces.Infrastructure;
using Domain.Aggregates.Person;
using OvetimePolicies;

namespace Infrastructure.Services
{
    public class SalaryCalculator : ISalaryCalculator
    {
        public double CalcurlateSalary(PaymentInformation paymentInformation,string overTimeCalculator)
        {
            return overTimeCalculator.ToLower() switch
            {
                "calcurlatora" => Payment.CalcurlatorA(paymentInformation.BasicSalary, paymentInformation.Allowance),
                "calcurlatorb" => Payment.CalcurlatorB(paymentInformation.BasicSalary, paymentInformation.Allowance),
                "calcurlatorc" => Payment.CalcurlatorC(paymentInformation.BasicSalary, paymentInformation.Allowance),
                _ => throw new Exception("overTimeCalculator not found")
            };
        }
    }
}
