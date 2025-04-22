using System.ComponentModel.DataAnnotations;

namespace MaximaHome.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "نام کاربری باید بین 3 تا 50 کاراکتر باشد")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "رمز عبور باید حداقل 8 کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تکرار رمز عبور الزامی است")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن باید یکسان باشند")]
        [Display(Name = "تکرار رمز عبور")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "نام و نام خانوادگی الزامی است")]
        [StringLength(100, ErrorMessage = "نام و نام خانوادگی نمی‌تواند بیشتر از 100 کاراکتر باشد")]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "شماره تماس الزامی است")]
        [RegularExpression(@"^09[0-9]{9}$", ErrorMessage = "شماره تماس باید با 09 شروع شود و 11 رقم باشد")]
        [Display(Name = "شماره تماس")]
        public string PhoneNumber { get; set; }
    }
} 