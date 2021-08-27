using SpyDuh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuh.DataAccess
{
    public class FriendRepository
    {
        //define new spy repo since we need to search it to create the join table
        static SpiesRepository _spyRepo = new SpiesRepository();
        
        //create new repository that serves as join table between friends
        static List<FriendshipCommand> _friendsJoin = new List<FriendshipCommand>
        
        {
            //create a bunch of new relationships between spies. Grab them by name and then assign the property their Id
             new FriendshipCommand
            {
                FriendOneId = _spyRepo.GetByName("James Bond").Id,
                FriendTwoId = _spyRepo.GetByName("Austin Powers").Id,
            },
             new FriendshipCommand
            {
                FriendOneId = _spyRepo.GetByName("James Bond").Id,
                FriendTwoId = _spyRepo.GetByName("Inspector Gadget").Id,
            },
              new FriendshipCommand
            {
                FriendOneId = _spyRepo.GetByName("Harriet Tubman").Id,
                FriendTwoId = _spyRepo.GetByName("Austin Powers").Id,
            },
               new FriendshipCommand
            {
                FriendOneId = _spyRepo.GetByName("James Bond").Id,
                FriendTwoId = _spyRepo.GetByName("Jason Bourne").Id,
            },
                new FriendshipCommand
            {
                FriendOneId = _spyRepo.GetByName("Jason Bourne").Id,
                FriendTwoId = _spyRepo.GetByName("Austin Powers").Id,
            },

    };
        internal void Add(FriendshipCommand friendshipRelationship)
        {
            //add the things to the list
            _friendsJoin.Add(friendshipRelationship);
        }

        internal List<Guid> GetAllFriendRels(Guid id)
        {
            //Look at our friend join table and get all the entries that contain the id of the spy we are passing in
            //FriendOneId is the id of the spy whose friends we are trying to find. Convert to list
            var findFriends = _friendsJoin.Where(friend => friend.FriendOneId == id).ToList();

            //create new list instance for the Ids since our table contains only Ids
            List<Guid> myFriends = new List<Guid>();
            //loop over the friends we found that FriendOne has
            foreach (var friend in findFriends)
            {
                //add the Id of FRIENDTWO from table to the list of myfriends
                myFriends.Add(friend.FriendTwoId);
            }

            //return the result of friendTwoIds
            return myFriends;
        }
    }
}
