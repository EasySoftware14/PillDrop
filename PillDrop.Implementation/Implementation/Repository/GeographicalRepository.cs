using System.Device.Location;
using GoogleMaps.LocationServices;
using PillDrop.Domain.Contracts.Repositories;

namespace PillDrop.Implementation.Implementation.Repository
{
    public class GeographicalRepository : IGeographicalRepository
    {
        private readonly GoogleLocationService _googleLocationService;

        public GeographicalRepository()
        {
            _googleLocationService = new GoogleLocationService("AIzaSyCkJcGWSqlARduCa__1aEg4MPmfaoylQN0");
        }
        public MapPoint GetMapPoints(string address)
        {
            return _googleLocationService.GetLatLongFromAddress(address);
        }

        public double GetCoordinate(MapPoint add1, MapPoint add2)
        {
            var sCoord = new GeoCoordinate(add1.Latitude, add1.Longitude);
            var eCoord = new GeoCoordinate(add2.Latitude, add2.Longitude);
           
            return sCoord.GetDistanceTo(eCoord);
        }
    }
}