using MediatR;
using Microsoft.AspNetCore.Mvc;
using Progi_Test.Application.Features.Vehicle.Queries.GetVehicleInformation;

namespace Progi_Test_API.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehicleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "VehicleInformation")]
    public async Task<IActionResult> VehicleInformation([FromBody] GetVehicleInformationQuery request)
    {
        return Ok(await _mediator.Send(request));
    }
}