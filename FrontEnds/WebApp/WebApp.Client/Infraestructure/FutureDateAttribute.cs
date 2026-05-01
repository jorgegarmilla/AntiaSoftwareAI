using System.ComponentModel.DataAnnotations;

namespace WebApp.Client.Infraestructure
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime datetime;

            if (DateTime.TryParse(value.ToString(), out datetime))
            {
                if (datetime < DateTime.Now)
                {
                    var memberName = validationContext.MemberName ?? string.Empty;

                    return new ValidationResult(ErrorMessage ?? "La fecha debe ser igual o anterior a hoy.", new[] { memberName });
                }
            }
            
            return ValidationResult.Success;
        }
    }

}
