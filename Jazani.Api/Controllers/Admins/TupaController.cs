using Jazani.Application.Admins.Dtos.Tupas;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class TupaController : ControllerBase
    {
        private readonly ITupaService _tupaService;

        public TupaController(ITupaService tupaService)
        {
            _tupaService = tupaService;
        }
        // GET: api/<TupaController>
        [HttpGet]
        public async Task<IEnumerable<TupaDto>> Get()
        {
            return await _tupaService.FindAllAsync();
        }

        // GET api/<TupaController>/5
        [HttpGet("{id}")]
        public async Task<TupaDto> Get(int id)
        {
            return await _tupaService.FindByIdAsync(id);
        }

        // POST api/<TupaController>
        [HttpPost]
        public async Task<TupaDto> Post([FromBody] TupaSaveDto tupaSaveDto)
        {
            return await _tupaService.CreateAsync(tupaSaveDto);
        }

        // PUT api/<TupaController>/5
        [HttpPut("{id}")]
        public async Task<TupaDto> Put(int id, [FromBody] TupaSaveDto tupaSaveDto)
        {
            return await _tupaService.EditAsync(id, tupaSaveDto);
        }

        // DELETE api/<TupaController>/5
        [HttpDelete("{id}")]
        public async Task<TupaDto> Delete(int id)
        {
            return await _tupaService.DisableAsync(id);
        }
    }
}
