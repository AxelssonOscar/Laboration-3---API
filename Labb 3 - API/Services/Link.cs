using Labb_3___API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3___API.Services
{
    public class Link : ILink
    {
        private Models.Context context;
        public Link(Models.Context context)
        {
            this.context = context;
        }

        public IEnumerable<Models.Link> GetAllLinksForSpecificPerson(int id)
        {
            IEnumerable<Models.Link> query = context.Links;

            if (id > -1)
            {
                query = query.Where(p => p.PersonId == id);
            }
            return query;
        }


        public async Task<Models.Link> AddNewLink(Models.Link newLink)
        {
            try
            {
                var result = await context.Links.AddAsync(newLink);
                await context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Models.Link> Search(string searchString)
        {
            IEnumerable<Models.Link> query = context.Links;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.WebsiteLink.ToLower().Contains(searchString.ToLower()));
            }
            return query;
        }
    }
}
