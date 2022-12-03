using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces.Persistence
{
    public interface ISqlDbContext
    {
        DbSet<Person> People { get; set; }
        DbSet<PaymentInformation> PaymentInformations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbContext DbContext();

    }
}