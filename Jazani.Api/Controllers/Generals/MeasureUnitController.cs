using Jazani.Application.Generals.Dtos.MeasureUnits;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureUnitController : ControllerBase
    {
        private readonly IMeasureUnitService _measureUnitService;

        public MeasureUnitController(IMeasureUnitService measureUnitService)
        {
            _measureUnitService = measureUnitService;
        }

        // GET: api/<MeasureUnitcs>
        [HttpGet]
        public async Task<IEnumerable<MeasureUnitDto>> Get()
        {
            return await _measureUnitService.FindAllAsync();
        }

        // GET api/<MeasureUnitcs>/5
        [HttpGet("{id}")]
        public async Task<MeasureUnitDto> Get(int id)
        {
            return await _measureUnitService.FindByIdAsync(id);
        }

        // POST api/<MeasureUnitcs>
        [HttpPost]
        public async Task<MeasureUnitDto> Post([FromBody] MeasureUnitSaveDto saveDto)
        {
            return await _measureUnitService.CreateAsync(saveDto);
        }

        // PUT api/<MeasureUnitcs>/5
        [HttpPut("{id}")]
        public async Task<MeasureUnitDto> Put(int id, [FromBody] MeasureUnitSaveDto saveDto)
        {
            return await _measureUnitService.EditAsync(id, saveDto);
        }

        // DELETE api/<MeasureUnitcs>/5
        [HttpDelete("{id}")]
        public async Task<MeasureUnitDto> Delete(int id)
        {
            return await _measureUnitService.DisabledAsync(id);
        }
    }
}
