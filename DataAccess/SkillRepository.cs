using SpyDuh.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpyDuh.DataAccess
{
    public class SkillRepository
    {
        private static List<Skill> _skills = new List<Skill>
        {
            new Skill
            {
                SkillId = Guid.NewGuid(),
                SkillLevel = 42,
                SkillName = "Slinking About",
                SkillType = SkillType.Stealth
            },
            new Skill
            {
                SkillId = Guid.NewGuid(),
                SkillLevel = 1,
                SkillName = "Stealth",
                SkillType = SkillType.Stealth
            },
            new Skill
            {
                SkillId = Guid.NewGuid(),
                SkillLevel = 5,
                SkillName = "Finesse",
                SkillType = SkillType.SoftSkills
            },
            new Skill
            {
                SkillId = Guid.NewGuid(),
                SkillLevel = 25,
                SkillName = "Nunchuku",
                SkillType = SkillType.Combat
            },
            new Skill
            {
                SkillId = Guid.NewGuid(),
                SkillLevel = 10,
                SkillName = "Gamblin",
                SkillType = SkillType.Finance
            },
            new Skill
            {
                SkillId = Guid.NewGuid(),
                SkillLevel = 44,
                SkillName = "Silver Tongue",
                SkillType = SkillType.Negotiation
            },
            new Skill
            {
                SkillId = Guid.NewGuid(),
                SkillLevel = 24,
                SkillName = "Hustlin New Blood",
                SkillType = SkillType.Recruiting
            },
            new Skill
            {
                SkillId = Guid.NewGuid(),
                SkillLevel = 114,
                SkillName = "Sippin Tea",
                SkillType = SkillType.Recon
            }
        };

        internal IEnumerable<Skill> GetSkillByType(SkillType skillType)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<Skill> GetAll()
        {
            return _skills;
        }

        internal void Add(Skill newSkill)
        {
            newSkill.SkillId = Guid.NewGuid();
            _skills.Add(newSkill);
        }

        internal Skill GetBySkillId(Guid skillId)
        {
            return _skills.FirstOrDefault(skill => skill.SkillId == skillId);
        }

        public IEnumerable<Skill> GetSkillBySkillType(SkillType skillType)
        {
            var skillsByType = _skills.Where(type => type.SkillType == skillType);
            return skillsByType;
        }

        public void Remove(Guid skillId)
        {
            var removeSkill = GetBySkillId(skillId);
        }
    }
}