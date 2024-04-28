using System.ComponentModel.DataAnnotations;

namespace E_CommerceApp.CustomValidations
{
    public class ValidateProductCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var List = value as List<int>;
            if (List != null)
            {
                if (List.Any(code => code < 1))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
    public class RequiredListIntAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = value as IList<int>;
            if (list == null || !list.Any())
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} can't be blank.");
            }
            return ValidationResult.Success;
        }
    }
    public class RequiredListDoubleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = value as IList<double>;
            if (list == null || !list.Any())
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} can't be blank.");
            }
            return ValidationResult.Success;
        }
    }
    public class RequiredDoubleAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if (value is double)
            {
                double price = (double)value;
                return price != 0;
            }

            return false;
        }
    }
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000; // Default minimum year

        public string DefaultErrorMessage { get; set; } = "Order Date can't be blank";

        // Parameterless constructor
        public MinimumYearValidatorAttribute()
        {
        }

        // Parameterized constructor
        public MinimumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && value is DateTime date)
            {
                if (date.Year < MinimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                }
            }
            else
            {
                // Return error message if the value is null or not of DateTime type
                return new ValidationResult(ErrorMessage ?? "Value is not a valid DateTime.");
            }

            // If validation passes, return success
            return ValidationResult.Success;
        }
    }

}
   
