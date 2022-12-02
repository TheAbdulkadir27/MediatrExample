using Domain.Entity;
using Infrastucture.Context;
using System;
using System.Linq;
namespace Infrastucture.Repository
{
    public class CategoryRepository : ICategoryService
    {
        private readonly DataContext dataContext;
        public CategoryRepository(DataContext dataContext) => this.dataContext = dataContext;
        public Category Add(Category category)
        {
            dataContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            dataContext.SaveChanges();
            return category;
        }
        public bool Delete(Guid id)
        {
            dataContext.Categories.Remove(GetById(id));
            if (dataContext.SaveChanges() > 0)
                return true;
            return false;
        }
        public Category GetById(Guid id) => dataContext.Categories.SingleOrDefault(v => v.Id == id);
        public Category Update(Category category)
        {
            dataContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dataContext.SaveChanges();
            return category;
        }
    }
}
