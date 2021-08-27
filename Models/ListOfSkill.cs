using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuh.Models
{
    public class Skill
    {
        public Guid SkillId { get; set; }
        public int SkillLevel { get; set; }
        public string SkillName { get; set; }
        public SkillType SkillType { get; set; }

    }

    public enum SkillType
    {
        Combat,
        Stealth,
        Intelligence,
        Negotiation,
        Recon,
        Tactics,
        SoftSkills,
        Recruiting,
        Finance
    }
}
