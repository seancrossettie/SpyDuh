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
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        SkillRepository _repo;

        public SkillsController()
        {
            _repo = new SkillRepository();
        }

        [HttpGet]
        public List<Skill> GetAllSkills()
        {
            return (List<Skill>)_repo.GetAll();
        }

        [HttpGet("{skillType}")]
        public IEnumerable<Skill> GetSkillBySkillType(SkillType skillType)
        {
            return _repo.GetSkillBySkillType(skillType);
        }

        [HttpPost]
        public IActionResult AddNewSkill(Skill newSkill)
        {
            _repo.Add(newSkill);

            return Created($"/api/skills/{newSkill.SkillId}", newSkill);
        }

        [HttpDelete("{skillId}")]
        public IActionResult RemoveSkill(Guid skillId)
        {
            _repo.Remove(skillId);

            return Ok();
        }
    }
}
