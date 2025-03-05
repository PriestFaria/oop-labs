using Lab5.Application.Models;

namespace Lab5.Application.Abstractions.Repositories;

public interface IOperationsRepository
{
    IEnumerable<Operation> GetOperationsByAccount(long id);

    void AddOperation(long id, double amount);
}