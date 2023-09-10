using System.ComponentModel.DataAnnotations;

namespace Js.ContactsViewer.Shared.Utility
{
    public class BirthDayExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var incVal = value as DateTime?;
            if (incVal == null)
                return ValidationResult.Success;

            if(incVal < new DateTime(1900, 01, 01))
            {
                return new ValidationResult("Tyle to ludzie nie żyją");
            }
            return ValidationResult.Success;
        }
    }
}
