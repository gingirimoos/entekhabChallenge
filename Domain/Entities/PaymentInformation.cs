using System;
using Domain.Abstraction;

namespace Domain.Entities
{
    public class PaymentInformation : AuditableEntity
    { 
        public int PersonId { get; set; }
       public double BasicSalary{get;set;}
       public double Allowance{get;set;}
       public double Transportation{get;set;}
       public string Date { get; set; }
       public double Sallary { get; set; }
       public virtual Person Person { get; set; }

    }
}