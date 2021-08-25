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

        [HttpGet("{skill}")]
        public IEnumerable<Skill> GetSkillBySkillType(SkillType skillType)
        {
            return _repo.GetSkillBySkillType(skillType);
        }

        [HttpPost]
        public void AddASkill(Skill newSkill)
        {
            _repo.Add(newSkill);
        }

        [HttpDelete("{skillId}")]
        public IActionResult RemoveSkill(Guid skillId)
        {
            _repo.Remove(skillId);

            return Ok();
        }

        //[HttpGet("spies/{skill}")]
        //public IActionResult FindBySkillName(string skillName)
        //{
        //    var parsedString = skillName.Replace("-", " ");
        //    return Ok(_repo.GetMemberByInterest(parsedString));
        //}
    }
}
