using SpyDuh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuh.DataAccess
{
    public class SpiesRepository
    {
        static List<Spy> _spies = new List<Spy>
       {
           new Spy
           {
              Id =  Guid.NewGuid(),
              Name = "Inspector Gadget",
              DoubleAgent = true,
              SpySkills = new List<Skill>
              {
                  new Skill
                  {
                      SkillLevel = 1,
                      SkillName = "Stealth",
                      SkillType = SkillType.Stealth
                  }
              }
           },
           new Spy
           {
               Id = Guid.NewGuid(),
               Name = "James Bond",
               DoubleAgent = false
           },
           new Spy
           {
               Id = Guid.NewGuid(),
               Name = "Harriet Tubman",
               DoubleAgent = false
           },
           new Spy
           {
               Id = Guid.NewGuid(),  
               Name = "Sterling Archer",
               DoubleAgent = true
           },
           new Spy
           {
               Id = Guid.NewGuid(),
               Name = "Jason Bourne",
               DoubleAgent = true
           },
           new Spy
           {
               Id = Guid.NewGuid(),
               Name = "Austin Powers",
               DoubleAgent = true
           },
           new Spy
           {
               Id = Guid.NewGuid(),
               Name ="Chuck Bartowski",
               DoubleAgent = false
           }

       };
        internal IEnumerable<Spy> GetAll()
        {
            return _spies;
        }

        internal void Add(Spy newSpy)
        {
            newSpy.Id = Guid.NewGuid();
            _spies.Add(newSpy);
        }

        internal Spy GetById(Guid spyId)
        {
            return _spies.FirstOrDefault(spy => spy.Id == spyId);
        }
    }
}
