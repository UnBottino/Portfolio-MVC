using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ContactMessage
    {
        public ContactMessage()
            : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        { 
        }

        public ContactMessage(string firstName, string surname, string email, string phoneNumber, string message)
        {
            FirstName = firstName;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
            Message = message;
        }

        [Required(ErrorMessage = "First Name is required!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required!")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required!")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "A message is required!")]
        [Display(Name = "Write a message...")]
        public string Message { get; set; }
    }
}
