namespace Lab5.Application.Abstractions.Auth;

public interface IAuthenticationService
{
    ValidationResult Validate(long id);
}