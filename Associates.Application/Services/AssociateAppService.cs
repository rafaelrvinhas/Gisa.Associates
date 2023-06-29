using Associates.Application.Interfaces;
using Associates.Application.ViewModels.Requests;
using Associates.Application.ViewModels.Responses;
using Associates.Domain.Commands;
using Associates.Domain.Core.Bus;
using Associates.Domain.Interfaces;
using AutoMapper;

namespace Associates.Application.Services
{
    public class AssociateAppService : IAssociateAppService
    {
        private readonly IMapper _mapper;
        private readonly IAssociateRepository _associateRepository;
        private readonly IMediatorHandler Bus;

        public AssociateAppService(
            IMapper mapper,
            IAssociateRepository associateRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _associateRepository = associateRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async void Register(NewAssociateViewModel associateViewModel)
        {
            var command = _mapper.Map<RegisterNewAssociateCommand>(associateViewModel);
            await Bus.SendCommand(command);
        }

        public AssociateDetailsViewModel GetByDocumentNumber(string documentNumber)
        {
            return _mapper.Map<AssociateDetailsViewModel>(_associateRepository.GetByDocumentNumber(documentNumber));
        }
    }
}
