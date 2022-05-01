using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3___API.Services
{
    public interface IInterest
    {
        IEnumerable<Models.Interest> GetAllInterestsForSpecificPerson(int id);

        Task<Models.Interest> AddNewInterest(Models.Interest newInterest);

        IEnumerable<Models.Interest> Search(string name);

    }
}
