using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Abstraction;

namespace Domain.Entities
{
    public class Person : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<PaymentInformation> PaymentInformations { get; set; } = new List<PaymentInformation>();

        public Person()
        {

        }
        public Person(string firstName, string lastName, List<PaymentInformation> informations)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

        }

        public void AddMultiplePaymentInformations(List<PaymentInformation> paymentInformations)
        {
            foreach (var paymentInfo in paymentInformations)
            {
                this.AddPaymentInformation(paymentInfo);
            }
        }

        public void AddPaymentInformation(PaymentInformation paymentInformation)
        {
            var isAlreadyAdded = this.PaymentInformations.Any(x => x.Date == paymentInformation.Date);
            if (isAlreadyAdded)
            {
                throw new Exception("patmentInfo already added");
            }

            this.PaymentInformations.Add(paymentInformation);
            
        }

        public void UpdatePaymentInformation(PaymentInformation paymentInformation)
        {
            
            var personInformationToBeUpdated = this.PaymentInformations.FirstOrDefault(x => x.Id == paymentInformation.Id);
            if (personInformationToBeUpdated != null)
            {
                personInformationToBeUpdated.Allowance = paymentInformation.Allowance;
                personInformationToBeUpdated.BasicSalary = paymentInformation.BasicSalary;
                personInformationToBeUpdated.Date = paymentInformation.Date;
                personInformationToBeUpdated.Transportation = paymentInformation.Transportation;
                personInformationToBeUpdated.Sallary = paymentInformation.Sallary;
            } else
            {
                throw new System.Exception("The payment information you are trying to modify is not found");
            }
        }


        public void DeletePaymentInformation(PaymentInformation paymentInformation)
        {
            this.PaymentInformations.Remove(paymentInformation);
        }
        public void DeletePaymentInformation(int paymentInformationId)
        {
            var paymentInfo = this.PaymentInformations.FirstOrDefault(x => x.Id == paymentInformationId);
            if (paymentInfo == null)
            {
                throw new Exception("paymentinfo not found");
            }
            this.PaymentInformations.Remove(paymentInfo);
        }
    }
}