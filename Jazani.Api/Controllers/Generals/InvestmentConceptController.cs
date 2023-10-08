using Jazani.Application.Generals.Dtos.InvestmentConcepts;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentConceptController : ControllerBase 
    {
        private readonly IInvestmentConceptService _investmentConceptService;

        public InvestmentConceptController(IInvestmentConceptService investmentConceptService)
        {
            _investmentConceptService = investmentConceptService;
        }

        // GET: api/<InvestmentConceptController>
        [HttpGet]
        public async Task<IEnumerable<InvestmentConceptDto>> Get()
        {
            return await _investmentConceptService.FindAllAsync();
        }

        // GET api/<InvestmentConceptController>/5
        [HttpGet("{id}")]
        public async Task<InvestmentConceptDto> Get(int id)
        {
            return await _investmentConceptService.FindByIdAsync(id);
        }

        // POST api/<InvestmentConceptController>
        [HttpPost]
        public async Task<InvestmentConceptDto> Post([FromBody] InvestmentConceptSaveDto saveDto)
        {
            return await _investmentConceptService.CreateAsync(saveDto);
        }

        // PUT api/<InvestmentConceptController>/5
        [HttpPut("{id}")]
        public async Task<InvestmentConceptDto> Put(int id, [FromBody] InvestmentConceptSaveDto saveDto)
        {
            return await _investmentConceptService.EditAsync(id, saveDto);
        }

        // DELETE api/<InvestmentConceptController>/5
        [HttpDelete("{id}")]
        public async Task<InvestmentConceptDto> Delete(int id)
        {
            return await _investmentConceptService.DisabledAsync(id);
        }
    }
}
