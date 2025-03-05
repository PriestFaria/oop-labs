using Lab5.Application.Contracts.Accounts;

namespace Lab5.Application.Contracts.Admin;

public interface IAdminService
{
    LoginResult AdminLogin(long id);
}