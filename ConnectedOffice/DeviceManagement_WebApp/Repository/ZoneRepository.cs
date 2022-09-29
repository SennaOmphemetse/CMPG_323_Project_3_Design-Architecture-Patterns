using Autofac.Core;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {

        }
        public IEnumerable GetMostRecentZone()
        {
            return _context.Zone;
        }

        public Zone AddZone(Zone category)
        {
            _context.Zone.Add(category);
            int a = _context.SaveChanges();
            return category;
        }
        public Zone GetZone(Guid Id)
        {
            return _context.Zone.Find(Id);
        }
        public IEnumerable GetAllZone()
        {
            return _context.Zone;
        }


        public void DeleteZone(Guid CustId)
        {
            var cust = _context.Zone.Find(CustId);
            if (cust != null)
            {
                _context.Zone.Remove(cust);
            }
            _context.SaveChanges();
        }
        public Zone Delete(Guid CustId)
        {
            Zone _cate = _context.Zone.Find(CustId);
            if (_cate != null)
            {
                _context.Zone.Remove(_cate);
                _context.SaveChanges();
            }
            return _cate;
        }

        public Zone FindZone(Guid Id)
        {
            return _context.Zone.Find(Id);
        }

        public Zone Update(Zone _category)
        {
            var _categ = _context.Zone.Attach(_category);
            _categ.State = EntityState.Modified;
            _context.SaveChanges();
            return _category;
        }
    }
}
