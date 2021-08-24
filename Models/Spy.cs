using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SpyDuh.Models.SpyService;

namespace SpyDuh.Models
{
    public class Spy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool DoubleAgent { get; set; }
        public List<Skill> SpySkills {get; set;}
        public List<ListOfServices> SpyServices { get; set; }

    }
}
