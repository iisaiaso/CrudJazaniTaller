using Jazani.Application.Generals.Dtos.Financialentitys;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialentityController : ControllerBase
    {
        private readonly IFinancialentityService _financialentityservice;

        public FinancialentityController(IFinancialentityService financialentityservice)
        {
            _financialentityservice = financialentityservice;
        }


        // GET: api/<FinancialentityController>
        [HttpGet]
        public async Task<IEnumerable<FinancialentityDto>> Get()
        {
            return await _financialentityservice.FindAllAsync();
        }

        // GET api/<FinancialentityController>/5
        [HttpGet("{id}")]
        public async Task<FinancialentityDto> Get(int id)
        {
            return await _financialentityservice.FindByIdAsync(id);
        }

        // POST api/<FinancialentityController>
        [HttpPost]
        public async Task<FinancialentityDto> Post([FromBody] FinancialentitySaveDto saveDto)
        {
            return await _financialentityservice.CreateAsync(saveDto);
        }

        // PUT api/<FinancialentityController>/5
        [HttpPut("{id}")]
        public async Task<FinancialentityDto> Put(int id, [FromBody] FinancialentitySaveDto saveDto)
        {
            return await _financialentityservice.EditAsync(id, saveDto);
        }

        // DELETE api/<FinancialentityController>/5
        [HttpDelete("{id}")]
        public async Task<FinancialentityDto> Delete(int id)
        {
            return await _financialentityservice.DisabledAsync(id);
        }
    }
}
