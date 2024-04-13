using Core.Application.Requests;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Create;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Delete.Id;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Delete.Name;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Update;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Dtos;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Queries.GetById;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/languageTechnology")]
    [ApiController]
    public class ProgramLanguageTechnologiesController : BaseController
    {


        [HttpGet("getlist")]
        public async Task<IActionResult> Update([FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListProgramLanguageTechnologyQuery { PageRequest = pageRequest });
            return Ok(response);
        }

        [HttpGet("get/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramLanguageTechnologyQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProgramLanguageTechnologyCommand request)
        { 
            CreateProgramLanguageTechnologyDto response = await  Mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteById([FromRoute] DeleteProgramLanguageTechnologyByIdCommand request)
        {
            var  response = await Mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteByName([FromBody] DeleteProgramLanguageTechnologyByNameCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgramLanguageTechnologyCommand request)
        {
            var  response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
