using Domain.Abstraction;

namespace Domain.Aggregates.Person
{
    public class PaymentInformation : BaseEntity
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