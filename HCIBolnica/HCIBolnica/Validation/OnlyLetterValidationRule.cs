using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCIBolnica.Validation
{
    public class OnlyLetterValidationRule : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                double r;
                if (Regex.IsMatch(s, @"^[a-zA-Z]+$"))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Dozvoljen unos samo slova!");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }

    }
}
