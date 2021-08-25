using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpyDuh.DataAccess;
using SpyDuh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuh.Controllers
{
    [Route("api/spies")]
    [ApiController]
    public class SpiesController : ControllerBase
    {
        SpiesRepository _repo;
        public SpiesController()
        {
            _repo = new SpiesRepository();
        }
        [HttpGet]
        public IActionResult GetAllSpies()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPost]
        public IActionResult AddSpy(Spy newSpy)
        {
            if (string.IsNullOrEmpty(newSpy.Name))
            {
                return BadRequest("You must provide a name");
            }
            _repo.Add(newSpy);

            return Created($"/api/spies/{newSpy.Id}", newSpy);
        }

        [HttpGet("{skillType}")]
        public IActionResult FindBySkillType(SkillType skillType)
        {
            return Ok(_repo.GetSpyBySkillType(skillType));
        }
    }
}
