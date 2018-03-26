using System.Device.Location;
using GoogleMaps.LocationServices;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IGeographicalService
    {
        MapPoint GetMapPoints(string address);
        double GetCoordinate(MapPoint add1, MapPoint add2);
    }
}
