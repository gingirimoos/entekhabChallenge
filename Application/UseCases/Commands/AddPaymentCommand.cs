using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces.Infrastructure;
using Application.Common.Interfaces.Persistence;
using Application.UseCases.Models;
using AutoMapper;
using Domain.Aggregates.Person;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Commands
{
    public class AddPaymentCommand : IRequest<Person> 
    {
        public Payload Data { get; set; }
    }


    public class AddPaymentCommandHandler : IRequestHandler<AddPaymentCommand, Person>
    {
        private readonly IMapper _mapper;
        private readonly ISalaryCalculator _salaryCalculator;
        private readonly ISqlDbContext _sqlDbContext;
        public AddPaymentCommandHandler(IMapper mapper, ISalaryCalculator salaryCalculator, ISqlDbContext sqlDbContext)
        {
            _mapper = mapper;
            _salaryCalculator = salaryCalculator;
            _sqlDbContext = sqlDbContext;
        }


        public async Task<Person> Handle(AddPaymentCommand request,
            CancellationToken cancellationToken)
        {
            var person =await _sqlDbContext.People.FirstOrDefaultAsync(x=>x.FirstName.ToLower() == request.Data.FirstName.ToLower() && x.LastName.ToLower() == request.Data.LastName.ToLower(), cancellationToken: cancellationToken) ?? _mapper.Map<Person>(request.Data);
            var paymentInformation = _mapper.Map<PaymentInformation>(request.Data);
            paymentInformation.Sallary = _salaryCalculator.CalcurlateSalary(paymentInformation, request.Data.OverTimeCalculator);
            person.AddPaymentInformation(paymentInformation);
            var addedPayment = _sqlDbContext.People.Add(person);
            await _sqlDbContext.SaveChangesAsync(cancellationToken);
            return addedPayment.Entity;
        }
    }
}