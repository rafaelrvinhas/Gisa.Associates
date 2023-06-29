using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Associates.Domain.Models.ValueObjects
{
    [Table(name: "Address", Schema = "dbo")]
    public class Address
    {
        public Address()
        { }
        public Address(string streetName, string number, string complement, string zipCode, string neighborhood, string city, int stateId)
        {
            StreetName = streetName;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            Neighborhood = neighborhood;
            City = city;
            StateId = stateId;
        }

        [Key]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }

        [Column(name: "StreetName", TypeName = "varchar(250)")]
        public string? StreetName { get; set; }

        [Column(name: "Number", TypeName = "varchar(10)")]
        public string? Number { get; set; }

        [Column(name: "Complement", TypeName = "varchar(250)")]
        public string? Complement { get; set; }

        [Column(name: "ZipCode", TypeName = "varchar(8)")]
        public string? ZipCode { get; set; }

        [Column(name: "Neighborhood", TypeName = "varchar(250)")]
        public string? Neighborhood { get; set; }

        [Column(name: "City", TypeName = "varchar(250)")]
        public string? City { get; set; }

        [ForeignKey("StateId")]
        [Column(name: "StateId", TypeName = "int")]
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
