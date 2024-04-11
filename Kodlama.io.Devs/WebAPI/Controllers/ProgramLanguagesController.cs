using Core.Application.Requests;
using Kodlama.io.Application.Features.ProgramLanguage.Commands.Create;
using Kodlama.io.Application.Features.ProgramLanguages.Commands.Delete;
using Kodlama.io.Application.Features.ProgramLanguages.Commands.Update;
using Kodlama.io.Application.Features.ProgramLanguages.Dtos;
using Kodlama.io.Application.Features.ProgramLanguages.Models;
using Kodlama.io.Application.Features.ProgramLanguages.Queries.GetAll;
using Kodlama.io.Application.Features.ProgramLanguages.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProgramLanguagesController:BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetAllProgramLanguageQuery reuqest = new() {PageRequest = pageRequest };
            ProgramLanguageListModel? response = await Mediator.Send(reuqest);
            return Created("", response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramLanguageCommand request)
        {
            var response = await Mediator.Send(request);
            return Created("", response);
        }

        [HttpPost("get/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramLanguageQuery reuqest)
        {
            GetByIdProgramLanguageDto response = await Mediator.Send(reuqest);
            return Ok(response);
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteById([FromRoute] DeleteProgramLanguageCommand reuqest)
        {
            DeleteProgramLanguageDto response = await Mediator.Send(reuqest);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteByName([FromBody] DeleteProgramLanguageByNameCommand reuqest)
        {
            DeleteProgramLanguageDto response = await Mediator.Send(reuqest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgramLanguageCommand reuqest)
        {
            UpdatedProgramLanguageDto response = await Mediator.Send(reuqest);
            return Ok(response);
        }


    }
}
