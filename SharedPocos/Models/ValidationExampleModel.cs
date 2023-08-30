using SharedPocos.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SharedPocos.Models;

// Doc link: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0
// Whole list can be found from this url https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-6.0
public class ValidationExampleModel
{
    [Required]
    public string? Name { get; set; }

    [Range(18, 110)]
    public int Age { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? Phone { get; set; }

    [CreditCard]
    public string? CreditCard { get; set; }

    [Range(minimum: 0, maximum: 500)]
    public string? Price { get; set; }

    [StringLength(maximumLength: 200)]
    public string? Summary { get; set; }

    [Url]
    public string? Url { get; set; }

    [Required(ErrorMessage = "Password is Required")]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$", ErrorMessage = "String must be between 8 and 15 characters long. string must contain at least one number. string must contain at least one uppercase letter. string must contain at least one lowercase letter.")]
    public string? Password { get; set; }

    [Required]
    [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password do not match")]
    public string? ReTypePassword { get; set; }

    [Required]
    [CustomName("S")]
    public string? CustomName { get; set; }


    // Following two attributes Works with Microsoft.AspNetCore.Mvc packages
    // [ValidateNever] Indicates that a property or parameter should be excluded from validation.
    public string? NeverValidate { get; set; }
}
