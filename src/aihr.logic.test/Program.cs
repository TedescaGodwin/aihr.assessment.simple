using aihr.logic.test;
using System.Runtime.CompilerServices;

List<CelestialBody> body = new List<CelestialBody>();

foreach (CelestialBody c in body)
{
    Console.WriteLine($"{c.Name}{c.ObitalPeriod}...list continues");
}

body.Min(x=> x.ObitalPeriod);
