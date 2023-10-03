using Jazani.Application.Admins.Dtos.Stateattentions;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateattentionController : ControllerBase
    {
        private readonly IStateattentionService _stateattentionService;

        public StateattentionController(IStateattentionService stateattentionService)
        {
            _stateattentionService = stateattentionService;
        }
        // GET: api/<StateattentionController>
        [HttpGet]
        public async Task<IEnumerable<StateattentionDto>> Get()
        {
            return await _stateattentionService.FindAllAsync();
        }

        // GET api/<StateattentionController>/5
        [HttpGet("{id}")]
        public async Task<StateattentionDto> Get(int id)
        {
            return await _stateattentionService.FindByIdAsync(id);
        }

        // POST api/<StateattentionController>
        [HttpPost]
        public async Task<StateattentionDto> Post([FromBody] StateattentionSaveDto stateattentionSaveDto)
        {
            return await _stateattentionService.CreateAsync(stateattentionSaveDto);
        }

        // PUT api/<StateattentionController>/5
        [HttpPut("{id}")]
        public async Task<StateattentionDto> Put(int id, [FromBody] StateattentionSaveDto stateattentionSaveDto)
        {
            return await _stateattentionService.EditAsync(id, stateattentionSaveDto);
        }

        // DELETE api/<StateattentionController>/5
        [HttpDelete("{id}")]
        public async Task<StateattentionDto> Delete(int id)
        {
            return await _stateattentionService.DisableAsync(id);
        }
    }
}
