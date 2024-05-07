using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ContactMessage
    {
        public ContactMessage()
            : this(string.Empty, string.Empty)
        { 
        }

        public ContactMessage(string email, string message)
        {
            Email = email;
            Message = message;
        }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A message is required!")]
        [Display(Name = "Write a message...")]
        public string Message { get; set; }
    }
}
