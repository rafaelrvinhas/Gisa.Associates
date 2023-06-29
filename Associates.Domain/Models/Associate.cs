using Associates.Domain.Models.Enums;
using Associates.Domain.Models.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Associates.Domain.Models
{
    [Table(name: "Associate", Schema = "dbo")]
    public class Associate
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Associate()
        {
            Name = string.Empty;
            Email = string.Empty;
            DocumentNumber = string.Empty;
            Address = new Address();
            Plan = new Plan();
        }
        
        /// <summary>
        /// Construtor parametrizado
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="documentNumber"></param>
        /// <param name="birthdate"></param>
        /// <param name="gender"></param>
        /// <param name="associateCategory"></param>
        /// <param name="address"></param>
        /// <param name="planId"></param>
        public Associate(string name, string email, string documentNumber, DateTime birthdate, EGender gender, EAssociateCategory associateCategory, Address address, Plan plan)
        {
            Name = name;
            Email = email;
            DocumentNumber = documentNumber;
            Birthdate = birthdate;
            Gender = gender;
            AssociateCategory = associateCategory;
            Address = address;
            Plan = plan;
        }

        [Key]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }

        [Column(name: "Name", TypeName = "varchar(250)")]
        public string Name { get; set; }

        [Column(name: "Email", TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column(name: "DocumentNumber", TypeName = "varchar(11)")]
        public string DocumentNumber { get; set; }

        [Column(name: "Birthdate", TypeName = "date")]
        public DateTime Birthdate { get; set; }

        [Column(name: "GenderId", TypeName = "int")]
        public EGender Gender { get; set; }

        [Column(name: "AssociateCategoryId", TypeName = "int")]
        public EAssociateCategory AssociateCategory { get; set; }

        [ForeignKey("AddressId")]
        [Column(name: "AddressId", TypeName = "int")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("PlanId")]
        [Column(name: "PlanId", TypeName = "int")]
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}
