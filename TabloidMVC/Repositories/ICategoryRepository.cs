using System.Collections.Generic;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetCatById(int categoryId);
        void Add(Category category);
        void Edit(Category category);
        void Delete(int categoryId);
    }
}