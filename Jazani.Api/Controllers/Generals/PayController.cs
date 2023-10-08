using Jazani.Application.Generals.Dtos.Pays;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IPayService _payService;

        public PayController(IPayService payService)
        {
            _payService = payService;
        }

        
         // GET: api/<PayController>
         [HttpGet]
         public async Task<IEnumerable<PayDto>> Get()
         {
             return await _payService.FindAllAsync();
         }

         // GET api/<PayController>/5
         [HttpGet("{id}")]
         public async Task<PayDto> Get(int id)
         {
             return await _payService.FindByIdAsync(id);
         }

         // POST api/<PayController>
         [HttpPost]
         public async Task<PayDto> Post([FromBody] PaySaveDto saveDto)
         {
             return await _payService.CreateAsync(saveDto);
         }

         // PUT api/<PayController>/5
         [HttpPut("{id}")]
         public async Task<PayDto> Put(int id, [FromBody] PaySaveDto saveDto)
         {
             return await _payService.EditAsync(id, saveDto);
         }

         // DELETE api/<PAyController>/5
         [HttpDelete("{id}")]
         public async Task<PayDto> Delete(int id)
         {
             return await _payService.DisabledAsync(id);
         }
    }
}
