using System.ComponentModel.DataAnnotations;

namespace AgendaContacts.Web.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]

        public string Email { get; set; } = null!;
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]

        public string Phone { get; set; } = null!;
        [DataType(DataType.MultilineText)]
        [MaxLength(250, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]

        public string Note { get; set; } = null!;
    }
}
