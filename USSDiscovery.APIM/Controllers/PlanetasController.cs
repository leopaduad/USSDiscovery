using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USSDiscovery.Application.Interfaces;
using USSDiscovery.Application.Services;
using USSDiscovery.Domain;
using USSDiscovery.Domain.Interfaces;

namespace USSDiscovery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetasController : ControllerBase
    {
        private readonly IPlanetaRepository _planeta;
        private readonly IPlanetaService _service;
        public PlanetasController(IPlanetaRepository planeta)
        {
            _planeta = planeta;
        }

        [HttpPost]
        public IActionResult Get()
        {
            decimal dime = 2.56m;
            var planeta = new Planeta("Leonardo", dime);
            _planeta.Add(planeta);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Planeta> Todos()
        {
            var p = new PlanetaService();
            p.cross();
            return _planeta.GetAll().ToList();
        }
    }
}
