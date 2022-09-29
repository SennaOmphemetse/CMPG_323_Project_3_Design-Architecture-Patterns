using Autofac.Core;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        IEnumerable GetCategory();
        IEnumerable GetZone();

        IEnumerable GetMostRecentDevice();
        Device GetDevice(Guid Id);
        Device AddDevice(Device id);
        void DeleteDevice(Guid id);
        Device Delete(Guid id);
        Device FindDevice(Guid id);
        Device Update(Device id);
    }
}
