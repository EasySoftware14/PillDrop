using System.Device.Location;
using GoogleMaps.LocationServices;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IGeographicalRepository
    {
        MapPoint GetMapPoints(string address);
        double GetCoordinate(MapPoint add1, MapPoint add2);
    }
}