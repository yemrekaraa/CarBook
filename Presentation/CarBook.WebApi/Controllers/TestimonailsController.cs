using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonailsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
          var values =  await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetTestitmonial(int id)
        {
            var values = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimoniak( CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(RemoveTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans başarıyla silindi");
        }
    }
}
