using Autofac.Core;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        public IEnumerable GetMostRecentDevice()
        {
            return _context.Device;
        }

        public IEnumerable GetCategory()
        {
            return _context.Category;
        }
        public IEnumerable GetZone()
        {
            return _context.Zone;
        }
        public Device AddDevice(Device device)
        {
            _context.Device.Add(device);
            int a = _context.SaveChanges();
            return device;
        }
        public Device GetDevice(Guid Id)
        {
            return _context.Device.Find(Id);
        }
        public IEnumerable GetAllDevice()
        {
            return _context.Device;
        }


        public void DeleteDevice(Guid CustId)
        {
            var cust = _context.Device.Find(CustId);
            if (cust != null)
            {
                _context.Device.Remove(cust);
            }
            _context.SaveChanges();
        }
        public Device Delete(Guid CustId)
        {
            Device _cate = _context.Device.Find(CustId);
            if (_cate != null)
            {
                _context.Device.Remove(_cate);
                _context.SaveChanges();
            }
            return _cate;
        }

        public Device FindDevice(Guid Id)
        {
            return _context.Device.Find(Id);
        }

        public Device Update(Device _device)
        {
            var _categ = _context.Device.Attach(_device);
            _categ.State = EntityState.Modified;
            _context.SaveChanges();
            return _device;
        }
    }
}
