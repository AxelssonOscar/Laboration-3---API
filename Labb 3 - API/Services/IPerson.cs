using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3___API.Services
{
    public interface IPerson
    {
        IEnumerable<Models.Person> GetAllPersons();
        Task<Models.Person> GetPerson(int id);


        IEnumerable<Models.Person> Search(string name);
    }
}
