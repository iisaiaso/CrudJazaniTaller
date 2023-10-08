﻿using Jazani.Application.Generals.Dtos.Investments;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase 
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        // GET: api/<InvestmentController>
        [HttpGet]
        public async Task<IEnumerable<InvestmentDto>> Get()
        {
           return await _investmentService.FindAllAsync();
        }

        // GET api/<InvestmentController>/5
        [HttpGet("{id}")]
        public async Task<InvestmentDto> Get(int id)
        {
            return await _investmentService.FindByIdAsync(id);
        }

        // POST api/<InvestmentController>
        [HttpPost]
        public async Task<InvestmentDto> Post([FromBody] InvestmentSaveDto saveDto)
        {
            return await _investmentService.CreateAsync(saveDto);
        }

        // PUT api/<InvestmentController>/5
        [HttpPut("{id}")]
        public async Task<InvestmentDto> Put(int id, [FromBody] InvestmentSaveDto saveDto)
        {
            return await _investmentService.EditAsync(id, saveDto);
        }

        // DELETE api/<InvestmentController>/5
        [HttpDelete("{id}")]
        public async Task<InvestmentDto> Delete(int id)
        {
            return await _investmentService.DisabledAsync(id);
        }
    }
}
