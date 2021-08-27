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
        // get all da skillz
        [HttpGet]
        public List<Skill> GetAllSkills()
        {
            return (List<Skill>)_repo.GetAll();
        }
        // get skill by skilltype enum index
        [HttpGet("{skill}")]
        public IEnumerable<Skill> GetSkillBySkillType(SkillType skillType)
        {
            return _repo.GetSkillBySkillType(skillType);
        }
        // add new skill
        [HttpPost]
        public void AddASkill(Skill newSkill)
        {
            _repo.Add(newSkill);
        }
        // delete skill by id
        [HttpDelete("{skillId}")]
        public IActionResult RemoveSkill(Guid skillId)
        {
            _repo.RemoveSkill(skillId);

            return Ok();
        }
    }
}
