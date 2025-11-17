using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EFCorePract.Validators
{
    public class LoginCheck:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input.Length <= 5)
            {
                return new ValidationResult(false, "Логин должен быть длиной не менее 5 символов");
            }
            return ValidationResult.ValidResult;
        }
    }
}
