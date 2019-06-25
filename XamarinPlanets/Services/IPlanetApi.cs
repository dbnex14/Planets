using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using XamarinPlanets.Models;

namespace XamarinPlanets.Services
{
    public interface IPlanetApi
    {
        [Get("/rest/bodies/")]
        Task<Body> GetPlanets();
    }
}
