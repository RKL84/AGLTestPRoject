using PeopleParser.Proxy;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleParser.BusinessLogic
{
    public class PeopleBL
    {
        IPeopleServiceProxy _proxy;
        public PeopleBL(IPeopleServiceProxy proxy)
        {
            _proxy = proxy;
        }

        public async Task<IEnumerable<string>> GetAllPetNameCollection(Gender gender, PetType petType)
        {
            var collection = await _proxy.GetAll();
            if (collection == null)
                return new List<string>();
            var allPets = collection.Where(a => a.Gender == gender && a.Pets != null)
                .SelectMany(a => a.Pets);
            return allPets.Where(a => a.Type == petType)
                .OrderBy(a => a.Name).Select(a => a.Name).ToList();
        }
    }
}

