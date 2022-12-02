using System;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces.Persistence.Repositories
{
    public interface IPersonRepository
    {
        public Task<Person> GetWithPayments(int paymentId);

        Task<Person> GetWithPaymentsInDateRange(int paymentId, DateTime from,
             DateTime to);
    }
}