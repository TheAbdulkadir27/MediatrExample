using System;

namespace Domain.Entity
{
    public interface ICategoryService
    {
        Category Add(Category category);
        Category Update(Category category);
        bool Delete(Guid id);
        Category GetById(Guid id);
    }
}
