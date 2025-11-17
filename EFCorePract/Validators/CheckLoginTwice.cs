using EFCorePract.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EFCorePract.Validators
{
    public class CheckLoginTwice:ValidationRule
    {
        public override System.Windows.Controls.ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            bool exists = false ;

            using (var context = new AppDbContext())
            {
                exists=context.Users.Any(u=>u.Login.ToLower()==input.ToLower());
            }

            if (exists)
            {
                return new System.Windows.Controls.ValidationResult(false, "Логин занят");
            }
            return System.Windows.Controls.ValidationResult.ValidResult;
        }
    }
}
