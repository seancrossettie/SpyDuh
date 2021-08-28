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
            //check to make sure this new spy has a name, since we filter with the property the most
            if (string.IsNullOrEmpty(newSpy.Name))
            {
                //if there is no name, send bad request response with warning
                return BadRequest("You must provide a name");
            }
            //otherwise, add new spy 
            _repo.Add(newSpy);

            //return response 
            return Created($"/api/spies/{newSpy.Id}", newSpy);
        }
        // search & filter spies by skilltype enum index
        [HttpGet("{skillType}")]
        public IActionResult FindBySkillType(SkillType skillType)
        {
            return Ok(_repo.GetSpyBySkillType(skillType));
        }

        // add new skill to spy
        [HttpPut("{id}")]
        public object UpdateSkill(Guid Id, Skill updateSkill)
        {
            return _repo.AddSkillBySkillId(Id, updateSkill);
        }
        //// add new service to spy
        //[HttpPut("{id}/services")]
        //public object UpdateService(Guid Id, Service updateService)
        //{
        //    return _repo.AddServiceByServiceId(Id, updateService);
        //}

        // search & filter spies by servicetype enum index 
        [HttpGet("getSpySkillsAndServices")]
        public IActionResult FindByService(string name)
        {
           return Ok(_repo.GetSpySkillsAndServices(name));
        }
    }
}
