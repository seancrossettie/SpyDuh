using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpyDuh.Models;

namespace SpyDuh.DataAccess
{
    public class EnemiesRepository
    {
        static SpiesRepository _spyRepo = new SpiesRepository();
        static List<EnemyCommand> _enemyTable = new List<EnemyCommand>
        {
            new EnemyCommand
            {
                EnemyOneId = _spyRepo.GetByName("Austin Powers").Id,
                EnemyTwoId = _spyRepo.GetByName("Inspector Gadget").Id
            },
            new EnemyCommand
            {
                EnemyOneId = _spyRepo.GetByName("James Bond").Id,
                EnemyTwoId = _spyRepo.GetByName("Harriet Tubman").Id
            }
        };

        public void createEnemyTable(EnemyCommand enemyTable)
        {
            _enemyTable.Add(enemyTable);
        }

        public List<Guid> GetAllEnemies(Guid id)
        {
            var findEnemies = _enemyTable.Where(enemy => enemy.EnemyOneId == id);

            List<Guid> myEnemies = new List<Guid>();

            foreach (var enemy in findEnemies)
            {
                myEnemies.Add(enemy.EnemyTwoId);
            }

            return myEnemies;
        }

        internal void Add(EnemyCommand newEnemyRelationship)
        {
            _enemyTable.Add(newEnemyRelationship);
        }
    }
}
