using System.ComponentModel.DataAnnotations;

namespace MovieArchive.Models
{
    public class Contact
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }
}