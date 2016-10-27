using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PastebookApp.Models
{
    public class SettingsViewModel : SignupViewModel
    {
        [Required(ErrorMessage ="Changing email or password requires the old password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Between 8 to 50 characters only", MinimumLength = 8)]
        public string OldPassword { get; set; }
    }
}