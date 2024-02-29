using MediatR;
using Progi_Test.Application.Features.Vehicle.Vms;

namespace Progi_Test.Application.Features.Vehicle.Queries.GetVehicleInformation;

public class GetVehicleInformationQuery: IRequest<VehicleVm>
{
    public Domain.Entities.Vehicle? Vehicle { get; set; }
}