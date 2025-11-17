using EFCorePract.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EFCorePract.Validators
{
    public class CheckEmailTwice:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            bool exists = false;

            using (var context=new AppDbContext())
            {
                exists=context.Users.Any(u => u.Email.ToLower() == input.ToLower());
            }

            if (exists)
            {
                return new ValidationResult(false, "Этот email уже используется");
            }

            return ValidationResult.ValidResult;
        }
    }
}
