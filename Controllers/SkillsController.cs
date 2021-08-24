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

        [HttpGet("skills/{skill}")] // how should this method be exposed & executed
        // all additive
        public IEnumerable<Skill> GetSkillBySkillType(SkillType skillType) // IEnum is just to loop over; restrictive permissions
        {
            return _repo.GetSkillBySkillType(skillType);
        }

        [HttpPost]
        public void AddASkill(Skill newSkill)
        {
            _repo.Add(newSkill);
        }
    }
}
