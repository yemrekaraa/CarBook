﻿using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values =await _mediator.Send(new GetServiceQuery());
            return Ok(values);

        }
        [HttpGet("id")]
        public async Task<IActionResult> GetServie(int id)
        {
            var values = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Service Başarıyla oluşturuldu.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveService(RemoveServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Service Başarıyla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Service başarıyla güncellendi.");
        }
    }
}
