using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3___API.Services
{
    public interface ILink
    {
        IEnumerable<Models.Link> GetAllLinksForSpecificPerson(int id);
        Task<Models.Link> AddNewLink(Models.Link newLink);
        IEnumerable<Models.Link> Search(string name);
    }
}
