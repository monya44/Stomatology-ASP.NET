using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dent.Data.Identity
{
    [Table("Form", Schema = "data")]
    public class Form
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Please write the corect email: example@exem.com")]
        public string Email { get; set; }

        public string ChoseProcedure { get; set; }
        public string ChoseDoctor { get; set; } 

        public DateTime CheckDoctor { get; set; }
        public decimal Price { get; set; }
        public string? Comments { get; set; }
    }
}
