using System.ComponentModel.DataAnnotations;

public class ChangePassword
{
    public long Id { get; set; }

    [Required(ErrorMessage = "رمز عبور الزامی است.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "رمز عبور باید حداقل ۸ کاراکتر باشد.")]
    [RegularExpression(@"(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}",
        ErrorMessage = "رمز عبور باید شامل حرف بزرگ، حرف کوچک، عدد و کاراکتر ویژه باشد.")]
    // RegularExpression kheili moheme ke jeloye ramze eshtebah ro begire
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن مطابقت ندارند.")]
    public string RePassword { get; set; }
}
