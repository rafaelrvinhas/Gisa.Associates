using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Associates.Domain.Models.ValueObjects
{
    [Table(name: "State", Schema = "dbo")]
    public class State
    {
        [Key]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }

        [Column(name: "Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(name: "Uf", TypeName = "varchar(2)")]
        public string Uf { get; set; }
    }
}
