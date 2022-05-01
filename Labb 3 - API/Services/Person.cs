using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3___API.Services
{
    public class Person : IPerson
    {
        public Person(Models.Context context)
        {
            this.context = context;
        }

        private Models.Context context;

        public IEnumerable<Models.Person> GetAllPersons()
        {
            return context.Persons;
        }

        public async Task<Models.Person> GetPerson(int id)
        {
            return await context.Persons.Include(p => p.Interests)
                                        .Include(p => p.Links)
                                        .FirstOrDefaultAsync(p => p.Id == id);
        }

        public IEnumerable<Models.Person> Search(string searchString)
        {
            try
            {
                return context.Persons.Where(p => p.Name.ToLower().Contains(searchString.ToLower()));
            }
            catch (Exception)
            {
                return null;
            }
               
        }
    }
}
