using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Frontend.Validation
{
    public class ExcludeCharsAttribute: ValidationAttribute, IClientValidatable
    {
        private readonly string chars;

        public ExcludeCharsAttribute(string chars)
            : base("The field {0} contains invalid character.")
        {
            this.chars = chars;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                for (var i = 0; i < chars.Length; i++)
                {
                    if (valueAsString.Contains(chars[i]))
                    {
                        var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                        return new ValidationResult(errorMessage);
                    }
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("chars", chars);
            rule.ValidationType = "exclude";
            yield return rule;
        }
    }
}