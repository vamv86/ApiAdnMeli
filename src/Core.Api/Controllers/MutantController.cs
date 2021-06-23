using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Api.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service.Interface;

namespace Core.Api.Controllers
{
    
    [ApiController]
    [Route("api")]
    public class MutantController : ControllerBase
    {
        private readonly IMutantServiceQuery _mutantServiceQuery;
        private readonly IMutantServiceCreate _mutantServiceCreate;
        

        public MutantController(
            IMutantServiceQuery MutantServiceQuery,
            IMutantServiceCreate MutantServiceCreate
        )
        {
            _mutantServiceQuery = MutantServiceQuery;
            _mutantServiceCreate = MutantServiceCreate;
        }


        [HttpPost]
        [Route("mutant")]
        public async Task<ActionResult> Create(GenDto gen)
        {
            try
            {
                bool isMutan = _mutantServiceQuery.IsMutant(gen.adn);

                string adn = string.Join(",", gen.adn);
                await _mutantServiceCreate.CreateAdn(
                     new TblAdnDto
                     {
                         Adn = adn,
                         IsMutant = isMutan,
                         AdnType = AdnType.Humano
                     });

                if (isMutan)
                {
                    return Ok("Mutante");
                }
                else
                {
                    return StatusCode(403, "No Mutante");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpGet]
        [Route("stats")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var stats = await _mutantServiceQuery.GetStats();
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
