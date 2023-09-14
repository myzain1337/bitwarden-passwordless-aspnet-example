using System.ComponentModel.DataAnnotations;

namespace Passwordless.AspNet.Example.Validation;

public class AlphanumericAttribute : RegularExpressionAttribute
{
    private const string Regex = "([a-zA-Z0-9]+)";

    public AlphanumericAttribute() : base(Regex)
    {
    }
}