using aihr.logic.test;
using System.Runtime.CompilerServices;

public class CelestialBody : ICelestialBody
{


    public bool HasSatelliteMoon(bool b)
    {
        return b;
    }

    public bool ItCanBeTerraformed(bool b)
    {
        return b;
    }

    public bool ItCanSustainLife(bool b)
    {
        return b;
    }

    //public static IEnumerable<GasPlanets> Colonize(this IEnumerable<GasPlanets> items)
    //{
    //    return items.GroupBy(item => (item.Jupiter, 
    //    item.Saturn, item.Saturn)).Select(item => item.First());

    //}
}