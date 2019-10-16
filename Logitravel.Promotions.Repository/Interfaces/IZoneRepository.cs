using Logitravel.Promotions.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logitravel.Promotions.Repository.Interfaces
{
    public interface IZoneRepository
    {
        List<Zone> GetZones();

        Zone GetZone(int zoneCode);
    }
}
