using Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Account
{
    public  class RegisterAccount
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "نام کاربری باید فقط شامل اعداد باشد.")]
        public string Username { get; set; }


        //[Required(ErrorMessage = "رمز عبور الزامی است.")]
        //[PasswordComplexity(ErrorMessage = "رمز عبور باید حداقل 8 کاراکتر داشته باشد و شامل حرف بزرگ، حرف کوچک، عدد و کاراکتر ویژه باشد.")]
        //public string Password { get; set; }

        //[Required(ErrorMessage = "تایید رمز عبور الزامی است.")]
        //[Compare("Password", ErrorMessage = "رمز عبور و تایید رمز عبور باید مطابقت داشته باشند.")]
        //public string Repassword { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get; set; }

        public long RoleId { get; set; }
        public long StateCategoryId { get; set; }

        public string Description { get; set; }




    }
}
