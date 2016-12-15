using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDAC.Models
{
    public class UpdateUser
    {
        [Required(ErrorMessage = "This field cannot be empty" ,AllowEmptyStrings =false)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "This field cannot be empty", AllowEmptyStrings = false)]
        public string Email { get; set; }

    }
}