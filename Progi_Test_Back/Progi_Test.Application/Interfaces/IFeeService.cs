using Progi_Test.Domain.Entities;

namespace Progi_Test.Application.Interfaces;

public interface IFeeService
{
    Task<List<Fee>> CalculateFees(Vehicle vehicle);
}