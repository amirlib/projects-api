using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ProjectsApi.Validators
{
    public class PasswordContentAttribute : ValidationAttribute
    {
        #region Protected Methods
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            if (value is string password)
            {
                var regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])[a-zA-Z0-9]{8,128}$");

                if (!regex.IsMatch(password)) return new ValidationResult(GetErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
        #endregion

        #region Private Methods
        private string GetErrorMessage(string fieldName)
        {
            return $"{fieldName} must contain at least one uppercase character, one digit and english letters only";
        }
        #endregion
    }
}
