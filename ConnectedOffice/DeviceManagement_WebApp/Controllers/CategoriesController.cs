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
    public class CategoriesController : Controller
    {
        private readonly ICategoriesRepository _context;

        public CategoriesController(ICategoriesRepository context)
        {
            _context = context;
        }

        // GET: Categories
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
        public async Task<IActionResult> Create(Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category _category = new Category()
                    {

                        CategoryId = model.CategoryId,
                        CategoryName = model.CategoryName,
                        CategoryDescription = model.CategoryDescription,
                        DateCreated = model.DateCreated,
                        Device = model.Device

                    };

                    var datasave = _context.AddCategory(_category);
                    _context.Update(_category);
                }
                return RedirectToAction("Index");
                

            }
            catch (Exception ex)
            {
                //ex.Message;
            }
            return View();
        }


        // GET: Categories/Details/5
        [AllowAnonymous]
        public ViewResult Details(Guid id)
        {
            Category model = _context.GetCategory(id);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("Customer Not Found", id);
            }
            Category _detail = new Category()
            {
                CategoryName = model.CategoryName,
                CategoryDescription = model.CategoryDescription,
                DateCreated = model.DateCreated,
                CategoryId = model.CategoryId,
                Device = model.Device

            };
            return View(_detail);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            Category _cust = _context.GetCategory(id);

            return View(_cust);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Category _category)
        {
            if (ModelState.IsValid)
            {
                Category _detail = _context.GetCategory(id);
                _detail.CategoryName = _category.CategoryName;
                _detail.CategoryDescription = _category.CategoryDescription;
                _detail.DateCreated = _category.DateCreated;
                _detail.CategoryId = _category.CategoryId;
                _detail.Device = _category.Device;


                _context.Update(_detail);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Devices/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            Category _category = _context.GetCategory(id);
            return View(_category);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Category _category)
        {
            _context.DeleteCategory(_category.CategoryId);
            return RedirectToAction("Index");
        }

    }
}
