using DeviceManagement_WebApp.Models;
using System;
using System.Collections;

namespace DeviceManagement_WebApp.Repository
{
    public interface IZoneRepository : IGenericRepository<Zone>
    {
        IEnumerable GetMostRecentZone();
        Zone GetZone(Guid Id);
        Zone AddZone(Zone category);
        void DeleteZone(Guid id);
        Zone Delete(Guid id);
        Zone FindZone(Guid id);
        Zone Update(Zone id);
    }
}
