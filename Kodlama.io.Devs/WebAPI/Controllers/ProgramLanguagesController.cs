using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Application.Features.ProgramLanguage.Commands.Create;
using Kodlama.io.Application.Features.ProgramLanguages.Commands.Delete.Id;
using Kodlama.io.Application.Features.ProgramLanguages.Commands.Delete.Name;
using Kodlama.io.Application.Features.ProgramLanguages.Commands.Update;
using Kodlama.io.Application.Features.ProgramLanguages.Dtos;
using Kodlama.io.Application.Features.ProgramLanguages.Models;
using Kodlama.io.Application.Features.ProgramLanguages.Queries.GetAll;
using Kodlama.io.Application.Features.ProgramLanguages.Queries.GetById;
using Kodlama.io.Application.Features.ProgramLanguages.Queries.GetList.dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProgramLanguagesController:BaseController
    {

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgramLanguageQuery reuqest = new() {PageRequest = pageRequest };
            ProgramLanguageListModel? response = await Mediator.Send(reuqest);
            return Created("", response);
        }

        [HttpGet("getlist/bydynamic")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest,[FromBody] Dynamic _dynamic)
        {
            GetListByDynamicProgramLanguageQuery reuqest = new() { PageRequest = pageRequest, Dynamic = _dynamic};
            ProgramLanguageListModel? response = await Mediator.Send(reuqest);
            return  Ok(response);
        }

        [HttpPost("add")]
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
        public async Task<IActionResult> DeleteById([FromRoute] DeleteProgramLanguageByIdCommand reuqest)
        {
            DeleteProgramLanguageDto response = await Mediator.Send(reuqest);
            return Ok(response);
        }

        [HttpDelete("delete/byname")]
        public async Task<IActionResult> DeleteByName([FromBody] DeleteProgramLanguageByNameCommand reuqest)
        {
            DeleteProgramLanguageDto response = await Mediator.Send(reuqest);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgramLanguageCommand reuqest)
        {
            UpdatedProgramLanguageDto response = await Mediator.Send(reuqest);
            return Ok(response);
        }


    }
}
