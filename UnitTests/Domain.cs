
using Domain.Entities;
using System;
using Xunit;

namespace UnitTests
{
    public class Domain
    {

        [Fact]
        public void Should_Not_Add_Dupplicated_PaymentInformation()
        {
            var person = new Person();
            var paymentInformation = new PaymentInformation
            {
                Allowance = 10000,
                BasicSalary = 10000,
                Date = DateTime.UtcNow.ToString(),
                Sallary = 10000,
                Transportation = 10000,
            };
            person.AddPaymentInformation(paymentInformation);
            Assert.Throws<Exception>( () => person.AddPaymentInformation(paymentInformation));

        }

        [Fact]
        public void Should_Add_PaymentInformation()
        {
            var person = new Person();
            var paymentInformation = new PaymentInformation
            {
                Allowance = 10000,
                BasicSalary = 10000,
                Date = DateTime.UtcNow.ToString(),
                Sallary = 10000,
                Transportation = 10000,
            };
            person.AddPaymentInformation(paymentInformation);
        }

        [Fact]
        public void Should_Not_Delete_NotAdded_PaymentInformation()
        {
            var person = new Person();
            Assert.Throws<Exception>(() => person.DeletePaymentInformation(1));
        }
    }
}
