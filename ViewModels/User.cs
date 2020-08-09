using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
namespace ViewModels
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username is blank")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        [Remote("ChkMale", "Home", ErrorMessage = "Gender must be Male")]
        public string Gender { get; set; }
        public bool IsInterestedInCSharp { get; set; }
        public bool IsInterestedInJava { get; set; }
        public bool IsInterestedInPython { get; set; }
        [Display(Name = "City")]
        public int CityId { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //public DateTime YourDate { get; set; }
        [Required]
        public DateTime DOB { get; set; }

        public IEnumerable<City> CityList { get; set; }
    }
}
