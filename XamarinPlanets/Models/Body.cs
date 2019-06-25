using System;
using System.Collections.Generic;

namespace XamarinPlanets.Models
{
    public class Body
    {
        public string id { get; set; }
        public string name { get; set; }
        public string englishName { get; set; }
        public bool isPlanet { get; set; }
        public IList<Moon> moons { get; set; }
        public object semimajorAxis { get; set; }
        public object perihelion { get; set; }
        public object aphelion { get; set; }
        public double eccentricity { get; set; }
        public double inclination { get; set; }
        public Mass mass { get; set; }
        public Vol vol { get; set; }
        public double density { get; set; }
        public double gravity { get; set; }
        public double escape { get; set; }
        public double meanRadius { get; set; }
        public double equaRadius { get; set; }
        public double polarRadius { get; set; }
        public double flattening { get; set; }
        public string dimension { get; set; }
        public double sideralOrbit { get; set; }
        public double sideralRotation { get; set; }
        public AroundPlanet aroundPlanet { get; set; }
        public string discoveredBy { get; set; }
        public string discoveryDate { get; set; }
        public string alternativeName { get; set; }
        public string rel { get; set; }
    }
}
