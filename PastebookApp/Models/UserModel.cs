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

        [DisplayName("User Name:")]
        [StringLength(50, ErrorMessage = "Less than 50 characters only")]
        [RegularExpression(@"^[a-zA-Z'. d\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        public string USER_NAME { get; set; }

        [Required(ErrorMessage = "FirstName Required:")]
        [DisplayName("First Name:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        [StringLength(50, ErrorMessage = "Less than 50 characters only")]
        public string FIRST_NAME { get; set; }

        [Required(ErrorMessage = "LastName Required:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        [DisplayName("Last Name:")]
        [StringLength(50, ErrorMessage = "Less than 50 characters only")]
        public string LAST_NAME { get; set; }

        [Required(ErrorMessage = "Email Required:")]
        [DisplayName("Email:")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Less than 50 characters only")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "Password Required:")]
        [DataType(DataType.Password)]
        [DisplayName("Password:")]
        [StringLength(30, ErrorMessage = "Less than 30 characters only")]
        public string PASSWORD { get; set; }

        [Required(ErrorMessage = "Confirm Password Required:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password not matched.")]
        [Display(Name = "Confirm password:")]
        [StringLength(30, ErrorMessage = "Less than 30 characters only")]
        public string CONFIRM_PASSWORD { get; set; }

        [Required(ErrorMessage = "Birthday Required:")]
        [DataType(DataType.Date)]
        [DisplayName("Birthday:")]
        public DateTime BIRTHDAY { get; set; }

        [DisplayName("Country:")]
        public int COUNTRY_ID { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Numbers only")]
        [StringLength(20, ErrorMessage = "Less than 20 digits only")]
        [DisplayName("Phone Number:")]
        public string MOBILE_NO { get; set; }

        [DisplayName("Gender:")]
        public char GENDER { get; set; }
        
        public DateTime DATE_CREATED { get; set; }

        [StringLength(2000, ErrorMessage = "Less than 2000 characters only")]
        [DisplayName("About me:")]
        public string ABOUT_ME { get; set; }

        [DisplayName("Profile Picture:")]
        public byte[] PROFILE_PIC { get; set; }
    }


}