﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Passwordless.AspNet.Example.Validation;

namespace Passwordless.AspNet.Example.Pages.Account;

public class RegisterModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public RegisterModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public IActionResult OnGet()
    {
        if (HttpContext.User.Identity is { IsAuthenticated: true })
        {
            return LocalRedirect("/");
        }
        return Page();
    }

    public async Task OnPostAsync(FormModel form, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return;
        _logger.LogInformation("Registering user {username}", form.Username);
        ViewData["CanAddPasskeys"] = true;
    }

    public FormModel Form { get; init; } = new();
}

public class FormModel
{
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    [Alphanumeric]
    public string Username { get; set; } = string.Empty;

    [EmailAddress]
    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
}