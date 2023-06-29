using Associates.Domain.Interfaces;
using Associates.Infra.Data.Context;

namespace Associates.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AssociateContext _context;

        public UnitOfWork(AssociateContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
