using aihr.logic.test;
using System.Runtime.CompilerServices;

public class CelestialBody : ICelestialBody
{
    public string? Name
    {
        get; set;
    }
    public string? Picture
    {
        get; set;
    }
    public decimal DistanceFromSun
    {
        get; set;
    }
    public decimal ObitalPeriod
    {
        get; set;
    }
    public decimal Mass
    {
        get; set;
    }

    public bool HasSatelliteMoon(bool b) => b;


    public bool ItCanBeTerraformed(bool b) => b;


    public bool ItCanSustainLife(bool b) => b;
}