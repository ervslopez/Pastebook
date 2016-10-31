using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PastebookApp.Models
{
    public class UserModel
    {
        public int ID;

        [Required(ErrorMessage = "Username is required")]
        [DisplayName("User Name")]
        [StringLength(50, ErrorMessage = "Username should be less than 50 characters only")]
        [RegularExpression(@"^((([_.]?)[a-zA-Z0-9]+)+([_.]?)*)$", ErrorMessage = "Invalid format for username")]
        public string USER_NAME { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [DisplayName("First Name")]
        [RegularExpression(@"^((\s*[ '.-]?\s*[a-zA-Z0-9]+)+[ '.-]?\s*)$", ErrorMessage = "Invalid format for first name")]
        [StringLength(50, ErrorMessage = "First name should be less than 50 characters only")]
        public string FIRST_NAME { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [RegularExpression(@"^((\s*[ '.-]?\s*[a-zA-Z0-9]+)+[ '.-]?\s*)$", ErrorMessage = "Invalid format for last name")]
        [DisplayName("Last Name")]
        [StringLength(50, ErrorMessage = "Last name should be less than 50 characters only")]
        public string LAST_NAME { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Email address should be less than 50 characters only")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [StringLength(30, ErrorMessage = "Password should be less than 30 characters only")]
        public string PASSWORD { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Compare("PASSWORD", ErrorMessage = "Confirm Password not matched.")]
        [DisplayName("Confirm Password")]
        [StringLength(30, ErrorMessage = "Confirm Password should be 8 to 30 characters long", MinimumLength =8)]
        public string CONFIRM_PASSWORD { get; set; }

        [Required(ErrorMessage = "Birthday is Required")]
        [DataType(DataType.Date)]
        [DisplayName("Birthday")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BIRTHDAY { get; set; }
        
        [DisplayName("Country")]
        public int COUNTRY_ID { get; set; }

        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Mobile number format")]
        [Phone(ErrorMessage = "Invalid Mobile number format")]
        [StringLength(20, ErrorMessage = "Mobile Number should be less than 20 digits only")]
        public string MOBILE_NO { get; set; }

        [DisplayName("Gender")]
        public char GENDER { get; set; }
        
        public DateTime DATE_CREATED { get; set; }

        [StringLength(2000, ErrorMessage = "Description should be less than 2000 characters only")]
        [DisplayName("About Me")]
        public string ABOUT_ME { get; set; }

        [DisplayName("Profile Picture")]
        public byte[] PROFILE_PIC { get; set; }
    }
}