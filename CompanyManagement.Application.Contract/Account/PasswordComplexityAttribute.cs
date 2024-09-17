using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class PasswordComplexityAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value as string;
        if (string.IsNullOrWhiteSpace(password))
        {
            return new ValidationResult("رمز عبور اجباری است");
        }

        // شرط‌های پیچیدگی رمز عبور
        if (password.Length < 8 ||
            !Regex.IsMatch(password, @"[A-Z]") ||
            !Regex.IsMatch(password, @"[a-z]") ||
            !Regex.IsMatch(password, @"[0-9]") ||
            !Regex.IsMatch(password, @"[\W_]"))
        {
            return new ValidationResult("رمز عبور باید حداقل 8 کاراکتر داشته باشد و شامل حرف بزرگ، حرف کوچک، عدد و کاراکتر ویژه باشد");
        }

        return ValidationResult.Success;
    }
}