using Progi_Test.Domain.Enums;

namespace Progi_Test.Domain.Entities;

public class Fee
{
    public FeeType FeeType { get; set; }
    public decimal Value { get; set; }
}