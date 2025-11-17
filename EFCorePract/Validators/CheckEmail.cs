using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EFCorePract.Validators
{
    public class CheckEmail:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (!input.Contains("@"))
            {
                return new ValidationResult(false, "Email должен содержать символ @");
            }

            return ValidationResult.ValidResult;
        }
    }
}
