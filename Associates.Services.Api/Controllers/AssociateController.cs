using Associates.Application.Interfaces;
using Associates.Application.ViewModels.Requests;
using Associates.Application.ViewModels.Responses;
using Associates.Domain.Core.Bus;
using Associates.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Associates.Services.Api.Controllers
{
    /// <summary>
    /// Constrolador de requisições da API de Associados.
    /// </summary>
    [Route("api/associado")]
    public class AssociateController : ApiController
    {
        private readonly IAssociateAppService _associateAppService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="associateAppService"></param>
        /// <param name="notifications"></param>
        /// <param name="mediator"></param>
        public AssociateController(
            IAssociateAppService associateAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _associateAppService = associateAppService;
        }

        /// <summary>
        /// Registra um novo associado e seu plano de saúde
        /// </summary>
        /// <param name="associateViewModel">COntém os dados do novo associado e seu plano.</param>
        /// <returns>Dados do novo associado registrado.</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("novo")]
        public IActionResult Post([Required][FromBody] NewAssociateViewModel associateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AssociateDetailsViewModel? associateDetails = new();

            _associateAppService.Register(associateViewModel);

            if (IsValidOperation())
            {
                associateDetails = _associateAppService.GetByDocumentNumber(associateViewModel.DocumentNumber);
            }

            return Response(associateDetails);
        }

        /// <summary>
        /// Consulta os detalhes de um associado pelo número do CPF.
        /// </summary>
        /// <param name="documentNumber">Número do CPF</param>
        /// <returns>Dados do associado</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("detalhes")]
        public IActionResult Get([FromQuery(Name = "cpf")] string documentNumber)
        {
            var associateDetailsViewModel = _associateAppService.GetByDocumentNumber(documentNumber);
            return Response(associateDetailsViewModel);
        }

        /// <summary>
        /// Atualiza o plano de um associado
        /// </summary>
        /// <param name="updateAssociateViewModel">Dados do associado e do plano necessários para realizar a atualização</param>
        /// <returns>Dados do plano atualizado</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPut]
        [Route("atualiza")]
        public IActionResult UpdateAssociate(UpdateAssociateViewModel updateAssociateViewModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Atualiza o plano de um associado
        /// </summary>
        /// <param name="updatePlanViewModel">Dados do associado e do plano necessários para realizar a atualização</param>
        /// <returns>Dados do plano atualizado</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPut]
        [Route("plano/atualiza")]
        public IActionResult UpdatePlan(UpdatePlanViewModel updatePlanViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
