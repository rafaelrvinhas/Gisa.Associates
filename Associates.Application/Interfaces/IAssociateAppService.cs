using Associates.Application.ViewModels.Requests;
using Associates.Application.ViewModels.Responses;

namespace Associates.Application.Interfaces
{
    public interface IAssociateAppService : IDisposable
    {
        void Register(NewAssociateViewModel associateViewModel);
        AssociateDetailsViewModel GetByDocumentNumber(string documentNumber);
    }
}
