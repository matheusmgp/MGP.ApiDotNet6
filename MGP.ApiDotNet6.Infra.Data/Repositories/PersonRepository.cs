using MGP.ApiDotNet6.Domain.Entities;
using MGP.ApiDotNet6.Domain.Repositories;
using MGP.ApiDotNet6.Infra.Data.Context;

namespace MGP.ApiDotNet6.Infra.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
      
        public PersonRepository(ApplicationDbContext dbContext) : base(dbContext)
        {          
        }
      
    }
}
