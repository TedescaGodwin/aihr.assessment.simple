using aihr.logic.test;
using System.Runtime.CompilerServices;

var celestialBodies = new List<dynamic>();
var nonDynamic = new List<Mars>();
//add all
celestialBodies.Add(new GasPlanets());
celestialBodies.Add(new DwarfPlanet());
celestialBodies.Add(new IceGiant());
//...list goes on

var q2n3 = nonDynamic.Select(x => x)
    .ToList().Min(x => x.ObitalPeriod);
