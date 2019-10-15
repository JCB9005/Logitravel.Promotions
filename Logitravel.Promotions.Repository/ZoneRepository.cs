using Logitravel.Promotions.Model;
using Logitravel.Promotions.Model.Context;
using Logitravel.Promotions.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Logitravel.Promotions.Repository
{
    public class ZoneRepository : IZoneRepository
    {
        public Zone GetZone(int zoneCode)
        {
            return LogitravelContext.Instance.Zones.Where(z => z.Code == zoneCode).FirstOrDefault();
        }

        public List<Zone> GetZones()
        {
            return LogitravelContext.Instance.Zones;
        }
    }
}
