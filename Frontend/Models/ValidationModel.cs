using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Frontend.Validation;

namespace Frontend.Models
{
    public class ValidationModel: IValidatableObject
    {
        [Required(ErrorMessage = "The field Age is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The field Age must be a valid integer Number")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "The field Name is required.")]
        [ExcludeChars("0123456789")]
        public string Name { get; set; }

        public int? Income { get; set; }

        public bool HasSalary { get; set; }

        public string Message { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HasSalary && (!Income.HasValue || Income < 0))
            {
                yield return new ValidationResult("The field Income cannot be negative", new[] { "Income" });
            }
        }
    }
}