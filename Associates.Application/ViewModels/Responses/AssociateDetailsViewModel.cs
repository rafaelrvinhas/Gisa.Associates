using Associates.Application.ViewModels.Enums;
using System.Text.Json.Serialization;

namespace Associates.Application.ViewModels.Responses
{
    /// <summary>
    /// Contém os dados consultados de um associado
    /// </summary>
    public class AssociateDetailsViewModel
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public AssociateDetailsViewModel()
        {
            Address = new AddressDetailsViewModel();
            Plan = new PlanDetailsViewModel();
        }

        /// <summary>
        /// Id do associado
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Nome do associado
        /// </summary>
        [JsonPropertyName("nome")]
        public string Name { get; set; }

        /// <summary>
        /// Email do associado
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Número de CPF do associado
        /// </summary>
        [JsonPropertyName("cpf")]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Data de nascimento do associado
        /// </summary>
        [JsonIgnore]
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Data de nascimento do associado no formato 'yyyy-MM-dd'
        /// </summary>
        [JsonPropertyName("data_nascimento")]
        public string FormattedBirthdate { get { return Birthdate.ToString("yyyy-MM-dd"); } }

        /// <summary>
        /// Enumerador de gênero do associado
        /// </summary>
        [JsonIgnore]
        public EGenderViewModel Gender { get; set; }

        /// <summary>
        /// Gênero do associado: Masculino / Feminino / Não informado
        /// </summary>
        [JsonPropertyName("genero")]
        public string GenderName 
        {
            get
            {
                return Gender switch
                {
                    EGenderViewModel.Male => "Masculino",
                    EGenderViewModel.Female => "Feminino",
                    EGenderViewModel.Uninformed => "Não informado",
                    _ => string.Empty,
                };
            }
        }

        /// <summary>
        /// Enumerador de categoria do associado
        /// </summary>
        [JsonIgnore]
        public EAssociateCategoryViewModel AssociateCategory { get; set; }

        /// <summary>
        /// Categoria do associado: Ativo / Suspenso / Inativo
        /// </summary>
        [JsonPropertyName("categoria_associado")]
        public string AssociateCategoryName 
        { 
            get
            {
                return AssociateCategory switch
                {
                    EAssociateCategoryViewModel.Active => "Ativo",
                    EAssociateCategoryViewModel.Suspended => "Suspenso",
                    EAssociateCategoryViewModel.Inactive => "Inativo",
                    _ => string.Empty,
                };
            }
        }

        /// <summary>
        /// Id do endereço do associado
        /// </summary>
        [JsonIgnore]
        [JsonPropertyName("id_endereco")]
        public int AddressId { get; set; }

        /// <summary>
        /// Informações de endereço
        /// </summary>
        [JsonPropertyName("endereco")]
        public AddressDetailsViewModel Address { get; set; }

        /// <summary>
        /// Id do plano do associado
        /// </summary>
        [JsonIgnore]
        [JsonPropertyName("id_plano")]
        public int PlanId { get; set; }

        /// <summary>
        /// Informações do plano do associado
        /// </summary>
        [JsonPropertyName("plano")]
        public PlanDetailsViewModel Plan { get; set; }
    }
}
