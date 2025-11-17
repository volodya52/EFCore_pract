using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EFCorePract.Validators
{
    public class CheckDate:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

           if(value is DateTime date)
           {
                if (date > DateTime.Today)
                {
                    return new ValidationResult(false, "Дата не может быть ранее текущей даты");
                }
                return ValidationResult.ValidResult;
           }
            return ValidationResult.ValidResult;


            
        }
    }
}
