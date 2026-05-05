using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class PromocaoRepository : EFRepository<Promocao>, IPromocaoRepository
    {
        public PromocaoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
