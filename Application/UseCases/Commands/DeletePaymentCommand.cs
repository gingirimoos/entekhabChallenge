using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Commands
{
    public class DeletePaymentCommand : IRequest<int>
    {
        public int PaymentId { get; set; }
    }


    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, int>
    {
        private readonly ISqlDbContext _sqlDbContext;
        public DeletePaymentCommandHandler(ISqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }

        public async Task<int> Handle(DeletePaymentCommand request,
            CancellationToken cancellationToken)
        {
            var person = await _sqlDbContext.People.Where(x => x.PaymentInformations
                .Any(x => x.Id == request.PaymentId))
                .Include(x => x.PaymentInformations)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            person.DeletePaymentInformation(request.PaymentId);

            await _sqlDbContext.SaveChangesAsync(cancellationToken);

            return request.PaymentId;
        }
    }
}