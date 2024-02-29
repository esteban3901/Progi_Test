using AutoMapper;
using Progi_Test.Application.Features.Fee.Vms;
using Progi_Test.Application.Features.Vehicle.Vms;
using Progi_Test.Domain.Entities;

namespace Progi_Test.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Vehicle, VehicleVm>()
            .ForMember(x => x.Type, y => y.MapFrom(z => z.Type.ToString()));
        CreateMap<Fee, FeeVm>()
            .ForMember(x => x.FeeName, y => y.MapFrom(z => z.FeeType.ToString()));
    }
}