using Associates.Domain.Models;

namespace Associates.Domain.Interfaces
{
    public interface IAssociateRepository : IRepository<Associate>
    {
        Task<Associate> GetByEmail(string email);
        Associate GetByDocumentNumber(string documentNumber);
    }
}
