using Jazani.Application.Generals.Dtos.PeriodTypes;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodTypeController : ControllerBase
    {
        private readonly IPeriodTypeService _periodTypeService;

        public PeriodTypeController(IPeriodTypeService periodTypeService)
        {
            _periodTypeService = periodTypeService;
        }

        // GET: api/<PeriodTypeController>
        [HttpGet]
        public async Task<IEnumerable<PeriodTypeDto>> Get()
        {
            return await _periodTypeService.FindAllAsync();
        }

        // GET api/<PeriodTypeController>/5
        [HttpGet("{id}")]
        public async Task<PeriodTypeDto> Get(int id)
        {
            return await _periodTypeService.FindByIdAsync(id);
        }

        // POST api/<PeriodTypeController>
        [HttpPost]
        public async Task<PeriodTypeDto> Post([FromBody] PeriodTypeSaveDto saveDto)
        {
            return await _periodTypeService.CreateAsync(saveDto);
        }

        // PUT api/<PeriodTypeController>/5
        [HttpPut("{id}")]
        public async Task<PeriodTypeDto> Put(int id, [FromBody] PeriodTypeSaveDto saveDto)
        {
            return await _periodTypeService.EditAsync(id, saveDto);
        }

        // DELETE api/<PeriodTypeController>/5
        [HttpDelete("{id}")]
        public async Task<PeriodTypeDto> Delete(int id)
        {
            return await _periodTypeService.DisabledAsync(id);
        }
    }
}
