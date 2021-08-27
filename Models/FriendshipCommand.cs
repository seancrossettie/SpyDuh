using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuh.Models
{
    public class FriendshipCommand
    {
        //define the join table properties

        //this is the friend whose friends we are searching for
        public Guid FriendOneId { get; set; }

        //this is the friend in relation to the above friend
        public Guid FriendTwoId { get; set; }
    }
}
