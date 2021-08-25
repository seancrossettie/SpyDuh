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
        SpiesRepository _repo;
        public FriendController()
        {
            _repo = new SpiesRepository();
        }
        [HttpGet]
        public IActionResult GetMyFriends(Guid spyId)
        {
            var currentSpyStatus = _repo.GetById(spyId).ToList()[0];
            bool isDoubleAgent = currentSpyStatus.DoubleAgent;
            var results = _repo.GetFriends(isDoubleAgent);
            return Ok(results.ToList());
        }
    }
}
