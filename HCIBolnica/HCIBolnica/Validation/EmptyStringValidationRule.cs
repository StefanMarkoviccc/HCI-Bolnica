using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCIBolnica.Validation
{
    public class EmptyStringValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                double r;
                if (!string.IsNullOrWhiteSpace(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Morate da popunite sva polja!");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}
