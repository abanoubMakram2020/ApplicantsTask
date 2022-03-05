using ApplicantsTask.Domain.Entities;
using ApplicantsTask.Domain.RepositriesInterfaces;
using ApplicantsTask.Infra.Data.Context;

namespace ApplicantsTask.Infra.Data.Repositrories
{
    public class ApplicantRepository : GenericRepository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(ApplicantsTaskDBContext context) : base(context)
        {

        }
    }
}
