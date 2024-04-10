using Core.Application.Requests;
using Kodlama.io.Application.Features.ProgramLanguage.Commands.Create;
using Kodlama.io.Application.Features.ProgramLanguages.Dtos;
using Kodlama.io.Application.Features.ProgramLanguages.Models;
using Kodlama.io.Application.Features.ProgramLanguages.Queries.GetAll;
using Kodlama.io.Application.Features.ProgramLanguages.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProgramLanguagesController:BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramLanguageCommand request)
        {
            var response = await Mediator.Send(request);
            return Created("", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetAllProgramLanguageQuery reuqest = new() { PageRequest = pageRequest };
            ProgramLanguageListModel? response = await Mediator.Send(reuqest);
            return Created("", response);
        }
        [HttpPost("get/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramLanguageQuery reuqest)
        {
            GetByIdProgramLanguageDto response = await Mediator.Send(reuqest);
            return Ok(response);
        }
    }
}
