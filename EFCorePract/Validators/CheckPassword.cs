using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EFCorePract.Validators
{
    public class CheckPassword:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input.Length < 8)
            {
                return new ValidationResult(false, "Пароль должен быть не менее 8 символов.");
            }

            string passwordSimvols = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";

            if (!Regex.IsMatch(input, passwordSimvols))
            {
                return new ValidationResult(false, "Пароль должен содержать символы, цифры, буквы в верхнем и нижнем регистре.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
