using System;
using System.Threading.Tasks;
using Application.Common.Interfaces.Persistence.Repositories;
using Domain.Entities;

namespace Application.UseCases.Queries
{
    public interface IPersonQuery
    {
        Task<Person> Get(int paymentId);
        Task<Person> GetRange(int paymentId, DateTime from, DateTime to);
    }

    public class PersonQuery : IPersonQuery
    {
        private readonly IPersonRepository _personRepository;
        public PersonQuery(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }


        public async Task<Person> Get(int paymentId)
        {
            return await _personRepository.GetWithPayments(paymentId);
        }


        public async Task<Person> GetRange(int paymentId, DateTime from, DateTime to)
        {
            return await _personRepository.GetWithPaymentsInDateRange(paymentId,from,to);
        }
    }
}