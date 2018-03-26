using GoogleMaps.LocationServices;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;

namespace PillDrop.Implementation.Implementation.Services
{
    public class GeographicalService: IGeographicalService
    {
        private readonly IGeographicalRepository _geographicalRepository;

        public GeographicalService(IGeographicalRepository geographicalRepository)
        {
            _geographicalRepository = geographicalRepository;
        }
        public MapPoint GetMapPoints(string address)
        {
            return _geographicalRepository.GetMapPoints(address);
        }

        public double GetCoordinate(MapPoint add1, MapPoint add2)
        {
            return _geographicalRepository.GetCoordinate(add1, add2);
        }
    }
}