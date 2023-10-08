﻿using Jazani.Application.Generals.Dtos.InvestmentTypes;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentTypeController : ControllerBase
    {
        private readonly IInvestmentTypeService _investmentTypeService;

        public InvestmentTypeController(IInvestmentTypeService investmentTypeService)
        {
            _investmentTypeService = investmentTypeService;
        }


        // GET: api/<InvestmentTypeController>
        [HttpGet]
        public async Task<IEnumerable<InvestmentTypeDto>> Get()
        {
            return await _investmentTypeService.FindAllAsync();
        }

        // GET api/<InvestmentTypeController>/5
        [HttpGet("{id}")]
        public async Task<InvestmentTypeDto> Get(int id)
        {
            return await _investmentTypeService.FindByIdAsync(id);
        }

        // POST api/<InvestmentTypeController>
        [HttpPost]
        public async Task<InvestmentTypeDto> Post([FromBody] InvestmentTypeSaveDto saveDto)
        {
            return await _investmentTypeService.CreateAsync(saveDto);
        }

        // PUT api/<InvestmentTypeController>/5
        [HttpPut("{id}")]
        public async Task<InvestmentTypeDto> Put(int id, [FromBody] InvestmentTypeSaveDto saveDto)
        {
            return await _investmentTypeService.EditAsync(id, saveDto);
        }

        // DELETE api/<InvestmentTypeController>/5
        [HttpDelete("{id}")]
        public async Task<InvestmentTypeDto> Delete(int id)
        {
            return await _investmentTypeService.DisabledAsync(id);
        }
    }
}
