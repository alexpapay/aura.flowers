using System.ComponentModel.DataAnnotations;

namespace aura.flowers.Models
{
    public class ContactUsViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public int SelectedProductId { get; set; }
    }
}
