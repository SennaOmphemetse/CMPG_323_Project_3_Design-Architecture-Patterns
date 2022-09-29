using Autofac.Core;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        public Category GetMostRecentCategory()
        {
            return _context.Category.OrderByDescending(category => category.DateCreated).FirstOrDefault();
        }

        public Category AddCategory(Category category)
        {
            _context.Category.Add(category);
            int a = _context.SaveChanges();
            return category;
        }
        public Category GetCategory(Guid Id)
        {
            return _context.Category.Find(Id);
        }
        public IEnumerable GetAllCategory()
        {
            return _context.Category;
        }
        

        public void DeleteCategory(Guid CustId)
        {
            var cust = _context.Category.Find(CustId);
            if (cust != null)
            {
                _context.Category.Remove(cust);
            }
            _context.SaveChanges();
        }
        public Category Delete(Guid CustId)
        {
            Category _cate = _context.Category.Find(CustId);
            if (_cate != null)
            {
                _context.Category.Remove(_cate);
                _context.SaveChanges();
            }
            return _cate;
        }

        public Category FindCategory(Guid Id)
        {
            return _context.Category.Find(Id);
        }

        public Category Update(Category _category)
        {
            var _categ = _context.Category.Attach(_category);
            _categ.State = EntityState.Modified;
            _context.SaveChanges();
            return _category;
        }
        public Category Update2(Category _category)
        {
            var _categ = _context.Category.Attach(_category);
            _categ.State = EntityState.Modified;
            _context.SaveChanges();
            return _category;
        }
    }
}
