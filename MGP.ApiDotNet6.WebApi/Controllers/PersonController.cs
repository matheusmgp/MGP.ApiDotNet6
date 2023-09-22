using MGP.ApiDotNet6.Application.Dtos;
using MGP.ApiDotNet6.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MGP.ApiDotNet6.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePersonDto createPersonDto)
        {
           
            var result = await _personService.CreateAsync(new PersonDto()
            {
                Id = 1,
                Name = createPersonDto.Name,
                Document = createPersonDto.Document,
                Phone = createPersonDto.Phone,
            });

            if(result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet]
        public async Task<ActionResult> GettAll()
        {
            var results = await _personService.GetAllAsync();
            if(results.IsSuccess) return Ok(results);
            return BadRequest(results);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _personService.GetByIdAsync(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id,[FromBody] UpdatePersonDto updatePersonDto)
        {

            var result = await _personService.UpdateAsync(new PersonDto()
            {
                Id = id,
                Name = updatePersonDto.Name,
                Document = updatePersonDto.Document,
                Phone = updatePersonDto.Phone,
            });

            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _personService.DeleteAsync(id);

            return Ok();
        }

    }
}
