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
    public class CheckGroupsTwice:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            bool exists = false;

            using(var context = new AppDbContext())
            {
                exists = context.InterestGroups.Any(ig=>ig.Title.ToLower() == input.ToLower());
            }

            if (exists)
            {
                return new ValidationResult(false, "Группа интересов с таким названием уже есть");
            }

            return ValidationResult.ValidResult;
        }
    }
}
