using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SpyDuh.Models.SpyService;

namespace SpyDuh.DataAccess
{
    public class ServicesRepository
    { 
        static List<ListOfServices> _services = new List<ListOfServices>
            {
                new Hat
                {
                    Id = Guid.NewGuid(),
                    Color = "Blue",
                    Designer = "Charlie",
                    Style = HatStyle.OpenBack
                },
                new Hat
                {
                    Id = Guid.NewGuid(),
                    Color = "Black",
                    Designer = "Nathan",
                    Style = HatStyle.WideBrim
                },
                new Hat
                {
                    Id = Guid.NewGuid(),
                    Color = "Magenta",
                    Designer = "Charlie",
                    Style = HatStyle.Normal
                }
            };

        internal Hat GetById(Guid hatId)
        {
            return _hats.FirstOrDefault(hat => hat.Id == hatId);
        }

        internal List<Hat> GetAll()
        {
            return _hats;
        }

        internal IEnumerable<Hat> GetByStyle(HatStyle style)
        {
            return _hats.Where(hat => hat.Style == style);
        }

        internal void Add(Hat newHat)
        {
            newHat.Id = Guid.NewGuid();

            _hats.Add(newHat);
        }
    }
}
