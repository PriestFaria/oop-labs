using Lab5.Application.Models;

namespace Lab5.Presentation.Console.CurrentAccounts;

public record CurrentAccount(long Id, decimal Balance = 0) : Account(Id);