using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuh.Models
{
    public class SpyService
    {
        public class ListOfServices
        {
            public int ServicePrice { get; set; }
            public string ServiceName { get; set; }
            public ServiceType ServiceType { get; set; }

        }

        public enum ServiceType
        {
            Combat,
            Stealth,
            Intelligence,
            Negotiation,
            Recon,
            Tactics,
            SoftSkills,
            Recruiting,
            Finance
        }
    }
}
