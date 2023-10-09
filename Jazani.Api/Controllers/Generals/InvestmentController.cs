using Jazani.Api.Exceptions;
using Jazani.Application.Generals.Dtos.Investments;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    //[ApiController]
    public class InvestmentController : ControllerBase 
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        // GET: api/<InvestmentController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<IEnumerable<InvestmentDto>> Get()
        {
           return await _investmentService.FindAllAsync();
        }

        // GET api/<InvestmentController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentDto>>> Get(int id)
        {
            var response = await _investmentService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/<InvestmentController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentDto>>> Post([FromBody] InvestmentSaveDto saveDto)
        {
            var response = await _investmentService.CreateAsync(saveDto);
            return TypedResults.CreatedAtRoute(response);

        }

        // PUT api/<InvestmentController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<InvestmentDto> Put(int id, [FromBody] InvestmentSaveDto saveDto)
        {
            return await _investmentService.EditAsync(id, saveDto);
        }

        // DELETE api/<InvestmentController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<InvestmentDto> Delete(int id)
        {
            return await _investmentService.DisabledAsync(id);
        }
    }
}
