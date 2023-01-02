using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStore.Models
{
    public class UserDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        [RegularExpression(@"^(?!.*[#@$%&'\-()*+,./:;<=>?^\[\]\\])[a-zA-Z_].{5,15}$",
            ErrorMessage = "The passsword should include only lowercase or uppercase letters and _")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [RegularExpression(@"^(?!.*[#$%&'()*+,./:;<=>?^\[\]\\])(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_])[a-zA-Z\d_].{6,20}$",
            ErrorMessage = "The passsword should include at least one lowercase letter, one uppercase letter, one number " +
            "and one special character (@, -, _, ~, |) and must be between 6 and 20 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [RegularExpression(@"[a-zA-z]+@[a-zA-z]+\.([a-zA-z])$", ErrorMessage = "This is not valid email address")]
        public string Email { get; set; }

        [RegularExpression(@"^[0-9]{3}?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$",
            ErrorMessage = "The phone can contain only numbers and -")]
        public string Phone { get; set; }
    }
}