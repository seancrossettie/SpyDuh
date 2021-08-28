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
    [Route("api/services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        ServicesRepository _repo;
        public ServicesController()
        {
            _repo = new ServicesRepository();
        }

        [HttpGet]
        public List<Service> GetAllSkills()
        {
            return (List<Service>)_repo.GetAll();
        }


        [HttpGet("{serviceType}")] // how should this method be exposed & executed
        // all additive
        public IEnumerable<Service> GetServiceByType(ServiceType serviceType) 
        {
            return _repo.GetServiceByType(serviceType);
        }

        [HttpPost]
        public void AddAService(Service newService)
        {
            _repo.Add(newService);
        }


        [HttpDelete("{serviceId}")]
        public IActionResult RemoveService(Guid serviceId)
        {
            _repo.Remove(serviceId);

            return Ok();
        }

    }
}
