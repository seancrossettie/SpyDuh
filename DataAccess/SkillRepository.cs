using SpyDuh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuh.DataAccess
{
    public class SkillRepository
    {
        static List<Skill> _skills = new List<Skill>
        {
            new Skill
            {
                //SkillId = Guid.NewGuid(),
                SkillLevel = 42,
                SkillName = "Slinking About",
                SkillType = SkillType.Stealth
            }
        };

        internal IEnumerable<Skill> GetSkillByType(SkillType skillType)
        {
            throw new NotImplementedException();
        }

        internal List<Skill> GetAll()
        {
            throw new NotImplementedException();
        }

        internal void Add(Skill newSkill)
        {
            throw new NotImplementedException();
        }

        //internal Skill GetBySkillId(Guid skillId)
        //{
        //    return _skills.FirstOrDefault(skill => skill.SkillId == skillId);
        //}

        internal IEnumerable<Skill> GetSkillByType(object s)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skill> GetSkillBySkillType(SkillType skillType)
        {
            var skillsByType = _skills.Where(type => type.SkillType == skillType);
            return skillsByType;
        }

        //public void Remove(Guid skillId)
        //{
        //    var removeSkill = GetBySkillId(skillId);
        //}
    }
}
