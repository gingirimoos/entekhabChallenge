using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Persistence.Repositories;
using Dapper;
using Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class PersonRepository:IPersonRepository
    {
        private readonly IDapperContext _dapperContext;

        public PersonRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<Person> GetWithPayments(int paymentId)
        {
            var query =
                $"select * from Persons p join PaymentInformations pi on p.Id = pi.PersonId where pi.Id = '{paymentId}'";
            await using (var connection = _dapperContext.Connection())
            {
               return (await connection.QueryAsync<Person, PaymentInformation, Person>
                    (query, (person, paymentInfo) => { person.PaymentInformations.Add(paymentInfo); return person; })).FirstOrDefault();
            }
        }


        public async Task<Person> GetWithPaymentsInDateRange(int paymentId, DateTime from,DateTime to)
        {
            var query =
                $"select * from Persons p join PaymentInformations pi on p.Id = pi.PersonId where pi.Id = '{paymentId}' and pi.Date >= '{from.ToString("yyyy/MM/dd")}' and pi.Date <= '{to.ToString("yyyy/MM/dd")}'";
            await using (var connection = _dapperContext.Connection())
            {
                return (await connection.QueryAsync<Person, PaymentInformation, Person>
                    (query, (person, paymentInfo) => { person.PaymentInformations.Add(paymentInfo); return person; })).FirstOrDefault();
            }
        }
    }
}