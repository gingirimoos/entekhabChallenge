using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces.Infrastructure;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Commands
{
    public class UpdatePaymentCommand : IRequest<PaymentInformation>
    {
        public PaymentInformation PaymentInformation { get; set; }
        public string OverTimeCalculator { get; set; }
    }


    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, PaymentInformation>
    {
        private readonly ISqlDbContext _sqlDbContext;
        private readonly ISalaryCalculator _salaryCalculator;

        public UpdatePaymentCommandHandler(ISqlDbContext sqlDbContext, ISalaryCalculator salaryCalculator)
        {
            _sqlDbContext = sqlDbContext;
            _salaryCalculator = salaryCalculator;
        }

        public async Task<PaymentInformation> Handle(UpdatePaymentCommand request,
            CancellationToken cancellationToken)
        {
            var person = await _sqlDbContext.People.Where(x => x.PaymentInformations.Any(x => x.Id == request.PaymentInformation.Id)).Include(x => x.PaymentInformations).FirstOrDefaultAsync();

            request.PaymentInformation.Sallary = _salaryCalculator.CalcurlateSalary(request.PaymentInformation, request.OverTimeCalculator);

            person.UpdatePaymentInformation(request.PaymentInformation);

            await _sqlDbContext.SaveChangesAsync(cancellationToken);

            return person.PaymentInformations.Where(x => x.Id == request.PaymentInformation.Id).FirstOrDefault();
        }
    }
}