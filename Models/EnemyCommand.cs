using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuh.Models
{
    public class EnemyCommand
    {
        //defines the join table between enemies
        public Guid EnemyOneId { get; set; }
        public Guid EnemyTwoId { get; set; }
    }
}
