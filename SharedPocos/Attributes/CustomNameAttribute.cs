using System.ComponentModel.DataAnnotations;

namespace SharedPocos.Attributes;

// This is a Custom Validation Attribute
public class CustomNameAttribute : ValidationAttribute
{
    private readonly string _startsWith;

    public CustomNameAttribute(string startsWith)
    {
        _startsWith = startsWith;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string valueStr && !valueStr.StartsWith(_startsWith))
        {
            return new ValidationResult($"{validationContext.MemberName} does not starts with {_startsWith}");
        }

        return ValidationResult.Success;
    }
}
