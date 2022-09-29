using DeviceManagement_WebApp.Models;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public interface ICategoriesRepository : IGenericRepository<Category>
    {

        Category GetMostRecentCategory();
        Category GetCategory(Guid Id);
        Category AddCategory(Category category);
        void DeleteCategory(Guid id);
        Category Delete(Guid id);
        Category FindCategory(Guid id);
        Category Update(Category id);
        Category Update2(Category id);
    }
}
