﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpyDuh.Models;


namespace SpyDuh.DataAccess
{
    public class ServicesRepository
    { 
        static List<Service> _services = new List<Service>
        {
            new Service
            {
                ServiceId = Guid.NewGuid(),
                ServicePrice = 4000,
                ServiceName = "Scope out a facility",
                Type = ServiceType.Recon
            },
            
            new Service
            {
                ServiceId = Guid.NewGuid(),
                ServicePrice = 230000,
                ServiceName = "Make someone disappear",
                Type = ServiceType.Combat
            },

            new Service
            {
                ServiceId = Guid.NewGuid(),
                ServicePrice = 200000,
                ServiceName = "Fight another agent",
                Type = ServiceType.Combat
            },

            new Service
            {
                ServiceId = Guid.NewGuid(),
                ServicePrice = 20000,
                ServiceName = "Flip an agent",
                Type = ServiceType.Recruiting
            }
        };

        internal List<Service> GetAll()
        {
            return _services;
        }

        internal Service GetServiceById(Guid serviceId)
        {
            return _services.FirstOrDefault(service => service.ServiceId == serviceId);
        }

        public IEnumerable<Service> GetServiceByType(ServiceType type)
        {
            return _services.Where(serviceType => serviceType.Type == type);
        }

        internal void Add(Service newService)
        {
            newService.ServiceId = Guid.NewGuid();

            _services.Add(newService);
        }

        public void Remove(Guid serviceId)
        {
            var removeSkill = GetServiceById(serviceId);
        }
    }
}
