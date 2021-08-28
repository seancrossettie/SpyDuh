using SpyDuh.Models;
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
                      SkillId = Guid.NewGuid(),
                      SkillLevel = 1,
                      SkillName = "Stealth",
                      SkillType = SkillType.Stealth
                  }
              },
              SpyServices = new List<Service>
              {
                  new Service
                  {
                      ServiceId = Guid.NewGuid(),
                      ServicePrice = 4000,
                      ServiceName = "Scope out a facility",
                      ServiceType = ServiceType.Recon
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
                          SkillId = Guid.NewGuid(),
                          SkillLevel = 5,
                          SkillName = "Finesse",
                          SkillType = SkillType.SoftSkills
                      }
                  },
               SpyServices = new List<Service>
               {
                  new Service
                  {
                        ServiceId = Guid.NewGuid(),
                        ServicePrice = 230000,
                        ServiceName = "Make someone disappear",
                        ServiceType = ServiceType.Combat
                  }
               }
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
                          SkillId = Guid.NewGuid(),
                          SkillLevel = 1000,
                          SkillName = "Underground Railroad Boss B",
                          SkillType = SkillType.Recon
                      }
                  },
               SpyServices = new List<Service>
               {
                  new Service
                  {
                      ServiceId = Guid.NewGuid(),
                      ServicePrice = 0000,
                      ServiceName = "Go on a walk with her",
                      ServiceType = ServiceType.Stealth
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
                          SkillId = Guid.NewGuid(),
                          SkillLevel = 25,
                          SkillName = "Karate, the Dane Cook of martial arts",
                          SkillType = SkillType.Combat
                      }
                  },
               SpyServices = new List<Service>
               {
                  new Service
                  {
                      ServiceId = Guid.NewGuid(),
                      ServicePrice = 40000,
                      ServiceName = "Pick out the right Tactileneck Sweater",
                      ServiceType = ServiceType.Tactics
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
                          SkillId = Guid.NewGuid(),
                          SkillLevel = 1,
                          SkillName = "Diplomacy",
                          SkillType = SkillType.Negotiation
                      }
                  },
               SpyServices = new List<Service>
              {
                  new Service
                  {
                      ServiceId = Guid.NewGuid(),
                      ServicePrice = 220000,
                      ServiceName = "Take down the system",
                      ServiceType = ServiceType.Combat
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
                          SkillId = Guid.NewGuid(),
                          SkillLevel = 15,
                          SkillName = "Ballin Out",
                          SkillType = SkillType.Finance
                      }
                  },
               SpyServices = new List<Service>
               {
                  new Service
                  {
                      ServiceId = Guid.NewGuid(),
                      ServicePrice = 4000,
                      ServiceName = "Yeah, baby! Yeah!",
                      ServiceType = ServiceType.SoftSkills
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
                          SkillId = Guid.NewGuid(),
                          SkillLevel = 100,
                          SkillName = "Babyface",
                          SkillType = SkillType.Stealth
                      }
                  },
               SpyServices = new List<Service>
               {
                  new Service
                  {
                      ServiceId = Guid.NewGuid(),
                      ServicePrice = 14500,
                      ServiceName = "Hold all your files for you.",
                      ServiceType = ServiceType.Intelligence
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
        public List<Spy> GetSpyBySkillType(SkillType skillType)
        {
            var newInstance = new SpiesRepository();
            var listOfSpies = newInstance.GetAll();
            var spiesWithSkill = new List<Spy>();
            foreach (var spy in listOfSpies)
            {
                foreach (var item in spy.SpySkills)
                {
                    if (item.SkillType == skillType)
                    {
                        spiesWithSkill.Add(spy);
                    }
                }
            }
            return spiesWithSkill;
        }

        public Spy GetSpySkillsAndServices(string name)
        {
            // Get the spy that is passed by controller
            var matchingSpy = _spies.FirstOrDefault(spy => spy.Name == name);

            // Create a local model to return the skills and services of that spy. 
            var SpyServices = new Spy
            {
                Id = matchingSpy.Id,
                Name = matchingSpy.Name,
                SpySkills = matchingSpy.SpySkills,
                SpyServices = matchingSpy.SpyServices
            };


            return SpyServices;
        }

        //public List<Spy> GetSpyByService(ServiceType serviceType)
        //{
        //    var newRepo = new SpiesRepository();
        //    var listOfSpies = newRepo.GetAll();
        //    var spiesWithService = new List<Spy>();
        //    foreach (var spy in listOfSpies)
        //    {
        //        foreach (var item in spy.SpyServices)
        //        {
        //            if (item.ServiceType == serviceType)
        //            {
        //                spiesWithService.Add(spy);
        //            }
        //        }
        //    }
        //    return spiesWithService;
        //}

        public List<Spy> AddSkillBySkillId(Guid id, Skill skill)
        {
            var skills = _spies.FirstOrDefault(x => x.Id == id).SpySkills;
            skills.Add(skill);
            return _spies;

        }

        public List<Spy> AddServiceByServiceId(Guid id, Service service)
        {
            var services = _spies.FirstOrDefault(x => x.Id == id).SpyServices;
            services.Add(service);
            return _spies;

        }
    }
}
