using PeopleParser.BusinessEntitites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleParser.Proxy
{
    public interface IPeopleServiceProxy
    {
        Task<IEnumerable<People>> GetAll();
    }
}