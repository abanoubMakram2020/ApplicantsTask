using ApplicantsTask.Domain.Entities;
using ApplicantsTask.Domain.RepositriesInterfaces;
using ApplicantsTask.Infra.Data.Context;

namespace ApplicantsTask.Infra.Data.Repositrories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicantsTaskDBContext context) : base(context)
        {

        }
    }
}
