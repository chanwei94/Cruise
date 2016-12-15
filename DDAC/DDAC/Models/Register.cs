using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DDAC.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Please enter username", AllowEmptyStrings = false)]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "This field must be 7 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter fullname", AllowEmptyStrings = false)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter email", AllowEmptyStrings = false)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }
    }
}
