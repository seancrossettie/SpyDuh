using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpyDuh.DataAccess;
using SpyDuh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuh.Controllers
{
    [Route("api/friends")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        SpiesRepository _spyRepo;
        FriendRepository _friendRepo;
        public FriendController()
        {
            _spyRepo = new SpiesRepository();
            _friendRepo = new FriendRepository();
        }

        [HttpGet]
        public IActionResult GetFriends(string name)
        {
            //search spy repo for the Spy with this name property
            var thisSpy = _spyRepo.GetByName(name);

            //Search the friend repository join table for entries
            //where the FriendOneId is the same as the spy we grabbed by name above
            //this method returns all the FriendTwoIds 
             var friends = _friendRepo.GetAllFriendRels(thisSpy.Id);

            //create an empty list of Spy
            List<Spy> myNewFriends = new List<Spy>();

            //loop over the Ids we returned above in friends. For each Guid, return the Spy that matches
            //add each of those spies to the list
            foreach (Guid friend in friends)
            {
                Spy mySpy = _spyRepo.GetById(friend);
                myNewFriends.Add(mySpy);
            }
            
            //return the list of friendly spies
            return Ok(myNewFriends);
        }

        [HttpPost]
        public IActionResult AddFriendRelationship(string friendOne, string friendTwo)
        {
            //create a new friendship table using the FriendshipCommand model
            var newFriendship = new FriendshipCommand
            {
                FriendOneId = _spyRepo.GetByName(friendOne).Id,
                FriendTwoId = _spyRepo.GetByName(friendTwo).Id,
            };

            //add the new friend to the friend repo 
            _friendRepo.Add(newFriendship);

            //return the friendship of Guids
           return Created("api/friend/friendships", newFriendship);

        }

        [HttpGet("squadList")]
        public IActionResult GetTrustedTeam(string name)
        {
            //search the spy repo for the Spy with this name
            var currentSpyStatus = _spyRepo.GetByName(name);

            //check the DoubleAgent property on the spy
            bool isDoubleAgent = currentSpyStatus.DoubleAgent;

            //The get friends method returns only the spies whose doubleagent status matches
            //the spy we searched for above
            var results = _spyRepo.GetFriends(isDoubleAgent);

            //return the results
            return Ok(results.ToList());
        }
    }
}
