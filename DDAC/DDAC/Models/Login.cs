using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DDAC.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter username", AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter password", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "This field must be 7 characters")]
        public string Password { get; set; }
    }
}
