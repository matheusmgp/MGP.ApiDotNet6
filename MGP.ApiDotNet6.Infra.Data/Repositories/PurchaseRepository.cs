
using MGP.ApiDotNet6.Domain.Entities;
using MGP.ApiDotNet6.Domain.Repositories;
using MGP.ApiDotNet6.Infra.Data.Context;

namespace MGP.ApiDotNet6.Infra.Data.Repositories
{
    public class PurchaseRepository :  BaseRepository<Purchase> ,IPurchaseRepository
    {
        public PurchaseRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
