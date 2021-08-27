﻿using SpyDuh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuh.DataAccess
{
    public class SpiesRepository
    {
        static FriendRepository _friendRepo = new FriendRepository();
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
                      //SkillId = Guid.NewGuid(),
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
               DoubleAgent = false,
               SpySkills = new List<Skill>
                  {
                      new Skill
                      {
                          //SkillId = Guid.NewGuid(),
                          SkillLevel = 5,
                          SkillName = "Finesse",
                          SkillType = SkillType.SoftSkills
                      }
                  },
           },
           new Spy
           {
               Id = Guid.NewGuid(),
               Name = "Harriet Tubman",
               DoubleAgent = false,
               SpySkills = new List<Skill>
                  {
                      new Skill
                      {
                          //SkillId = Guid.NewGuid(),
                          SkillLevel = 1000,
                          SkillName = "Underground Railroad Boss B",
                          SkillType = SkillType.Recon
                      }
                  }
           },
           new Spy
           {
               Id = Guid.NewGuid(),
               Name = "Sterling Archer",
               DoubleAgent = true,
               SpySkills = new List<Skill>
                  {
                      new Skill
                      {
                          //SkillId = Guid.NewGuid(),
                          SkillLevel = 25,
                          SkillName = "Karate, the Dane Cook of martial arts",
                          SkillType = SkillType.Combat
                      }
                  }
           },
           new Spy
           {
               Id = Guid.NewGuid(),
               Name = "Jason Bourne",
               DoubleAgent = true,
               SpySkills = new List<Skill>
                  {
                      new Skill
                      {
                          //SkillId = Guid.NewGuid(),
                          SkillLevel = 1,
                          SkillName = "Diplomacy",
                          SkillType = SkillType.Negotiation
                      }
                  }
           },
           new Spy
           {
               Id = Guid.NewGuid(),
               Name = "Austin Powers",
               DoubleAgent = true,
               SpySkills = new List<Skill>
                  {
                      new Skill
                      {
                          //SkillId = Guid.NewGuid(),
                          SkillLevel = 15,
                          SkillName = "Ballin Out",
                          SkillType = SkillType.Finance
                      }
                  }
           },
           new Spy
           {
               Id = Guid.NewGuid(),
               Name ="Chuck Bartowski",
               DoubleAgent = false,
               SpySkills = new List<Skill>
                  {
                      new Skill
                      {
                          //SkillId = Guid.NewGuid(),
                          SkillLevel = 100,
                          SkillName = "Babyface",
                          SkillType = SkillType.Stealth
                      }
                  }
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

        public Spy GetById(Guid spyId)
        {
            var result = _spies.FirstOrDefault(spy => spy.Id == spyId);
            return result;
        }

        public Spy GetByName(string name)
        {
            var result = _spies.FirstOrDefault(spy => spy.Name == name);
            return result;
        }

        public IEnumerable<Spy> GetFriends(bool friendStatus)
        { 
            var result = _spies.Where(spy => spy.DoubleAgent == friendStatus);
            return result;
        }

    }
}
