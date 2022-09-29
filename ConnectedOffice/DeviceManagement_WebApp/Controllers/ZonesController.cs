using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.AspNetCore.Authorization;

namespace DeviceManagement_WebApp.Controllers
{
    public class ZonesController : Controller
    {
        private readonly IZoneRepository _context;

        public ZonesController(IZoneRepository context)
        {
            _context = context;
        }

        // GET: Zone
        public async Task<IActionResult> Index()
        {
            return View(_context.GetAll());
        }




        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Zone model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Zone _Zone = new Zone()
                    {
                        ZoneName = model.ZoneName,
                        ZoneDescription = model.ZoneDescription,
                        DateCreated = model.DateCreated,
                        ZoneId = model.ZoneId,
                        Device = model.Device,
                        
                    };
                    var datasave = _context.AddZone(_Zone);
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    //ex.Message;
                }
            }
            return RedirectToAction("Index");
        }


        // GET: Zone/Details/5
        [AllowAnonymous]
        public ViewResult Details(Guid id)
        {
            Zone model = _context.GetZone(id);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("Zone Not Found", id);
            }
            Zone _detail = new Zone()
            {
                ZoneName = model.ZoneName,
                ZoneDescription = model.ZoneDescription,
                DateCreated = model.DateCreated,
                ZoneId = model.ZoneId,
                Device = model.Device

            };

            return View(_detail);
        }

        // GET: Zone/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            Zone _Zone = _context.GetZone(id);

            return View(_Zone);
        }

        // POST: Zone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Zone _Zone)
        {
            if (ModelState.IsValid)
            {
                Zone _detail = _context.GetZone(id);
                _detail.ZoneName = _Zone.ZoneName;
                _detail.ZoneDescription = _Zone.ZoneDescription;
                _detail.DateCreated = _Zone.DateCreated;
                _detail.ZoneId = _Zone.ZoneId;
                _detail.Device = _Zone.Device;


                _context.Update(_detail);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Zone/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            Zone _Zone = _context.GetZone(id);
            return View(_Zone);
        }

        // POST: Zone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Zone _Zone)
        {
            _context.DeleteZone(_Zone.ZoneId);
            return RedirectToAction("Index");
        }
    }
}