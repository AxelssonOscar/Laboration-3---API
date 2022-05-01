using Labb_3___API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3___API.Services
{
    public class Interest : IInterest
    {
        public Interest(Models.Context context)
        {
            this.context = context;
        }

        private Models.Context context;

        public IEnumerable<Models.Interest> GetAllInterestsForSpecificPerson(int id)
        {
            IEnumerable<Models.Interest> query = context.Interests;

            if (id > -1)
            {
                query = query.Where(p => p.PersonId == id);
            }
            return query;
        }

        public async Task<Models.Interest> AddNewInterest(Models.Interest newInterest)
        {
            try
            {
                var result = await context.Interests.AddAsync(newInterest);
                await context.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception e)
            {

                return null;
            }
        }
        public IEnumerable<Models.Interest> Search(string searchString)
        {
            IEnumerable<Models.Interest> query = context.Interests;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.Title.ToLower().Contains(searchString.ToLower()) || p.Description.ToLower().Contains(searchString.ToLower()));
            }
            return query;
        }
    }
}
