﻿using MesMicroservice.Api.Application.Messages;
using Microsoft.AspNetCore.Mvc;
using WembleyScada.Api.Application.Commands.References;
using WembleyScada.Api.Application.Queries.References;

namespace WembleyScada.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReferencesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReferencesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ReferenceViewModel>> GetReferences([FromQuery] ReferencesQuery query)
    {
        return await _mediator.Send(query);
    }


    [HttpPost]
    [Route("{refName}")]
    public async Task<IActionResult> CreateLot([FromRoute]string refName, [FromBody]CreateLotViewModel lot)
    {
        var command = new CreateLotCommand(refName, lot.LotId, lot.LotSize);
        try
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (ResourceNotFoundException ex)
        {
            var errorMessage = new ErrorMessage(ex);
            return NotFound(errorMessage);
        }
    }

    [HttpPut]
    [Route("{refName}")]
    public async Task<IActionResult> UpdateLot([FromRoute] string refName, [FromBody]UpdateLotViewModel lot)
    {
        var command = new UpdateLotCommand(refName, lot.LotId, lot.LotSize);
        try
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (ResourceNotFoundException ex)
        {
            var errorMessage = new ErrorMessage(ex);
            return NotFound(errorMessage);
        }
    }

    [HttpGet]
    [Route("Parameters")]
    public async Task<IEnumerable<ParameterViewModel>> GetParameter([FromQuery] ParametersQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPut]
    [Route("Parameters/Completed/{refName}")]
    public async Task<IActionResult> UpdateParameter([FromRoute] string refName)
    {
        var command = new UpdateParameterCommand(refName);
        try
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (ResourceNotFoundException ex)
        {
            var errorMessage = new ErrorMessage(ex);
            return NotFound(errorMessage);
        }
    }
}
