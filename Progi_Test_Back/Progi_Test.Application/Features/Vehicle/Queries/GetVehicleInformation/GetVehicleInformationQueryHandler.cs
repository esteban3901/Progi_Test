using AutoMapper;
using MediatR;
using Progi_Test.Application.Features.Fee.Vms;
using Progi_Test.Application.Features.Vehicle.Vms;
using Progi_Test.Application.Interfaces;

namespace Progi_Test.Application.Features.Vehicle.Queries.GetVehicleInformation;

public class GetVehicleInformationQueryHandler : IRequestHandler<GetVehicleInformationQuery, VehicleVm>
{
    private readonly IFeeService _feeService;
    private readonly IMapper _mapper;

    public GetVehicleInformationQueryHandler(IFeeService feeService, IMapper mapper)
    {
        _feeService = feeService;
        _mapper = mapper;
    }

    public async Task<VehicleVm> Handle(GetVehicleInformationQuery request, CancellationToken cancellationToken)
    {
        var vehicle = _mapper.Map<VehicleVm>(request.Vehicle);

        var fees = await _feeService.CalculateFees(request.Vehicle!);
        vehicle.Fees = _mapper.Map<List<FeeVm>>(fees);

        vehicle.Total = vehicle.BasePrice + vehicle.Fees.Sum(x => x.Value);

        return vehicle;
    }
}