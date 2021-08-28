using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpyDuh.DataAccess;
using SpyDuh.Models;

namespace SpyDuh.Controllers
{
    [Route("api/enemies")]
    [ApiController]
    public class EnemiesController : ControllerBase
    {
        SpiesRepository _spyRepo;
        EnemiesRepository _enemyRepo;

        public EnemiesController()
        {
            _spyRepo = new SpiesRepository();
            _enemyRepo = new EnemiesRepository();
        }

        [HttpGet]
        public IActionResult GetEnemy(String name)
        {
            // searches the spy repo to find the spy by this name
            var spyOne = _spyRepo.GetByName(name);
            var enemies = _enemyRepo.GetAllEnemies(spyOne.Id);

            List<Spy> myEnemies = new List<Spy>();

            foreach(Guid enemyId in enemies)
            {
                Spy enemySpy = _spyRepo.GetById(enemyId);
                myEnemies.Add(enemySpy);
            }
            return Ok(myEnemies);
        }

        [HttpPost]
        public IActionResult CreateNewEnemy(String spyOneName, String spyTwoName)
        {
            var spyOneId = _spyRepo.GetByName(spyOneName).Id;
            var spyTwoId = _spyRepo.GetByName(spyTwoName).Id;

            var newEnemyRelationship = new EnemyCommand
            {
                EnemyOneId = spyOneId,
                EnemyTwoId = spyTwoId
            };

            _enemyRepo.Add(newEnemyRelationship);

            return Created("enemies/created-enemies", newEnemyRelationship);
        }
    }
}
