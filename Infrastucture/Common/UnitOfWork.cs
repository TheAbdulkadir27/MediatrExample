using Domain.Common;
using Domain.Entity;
using Infrastucture.Context;
using Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public int Commit()
        {
            return dataContext.SaveChanges();
        }
        public IAdminService GetAdminService()
        {
            return new AdminRepository(dataContext);
        }
        public IBookService GetBookService()
        {
            return new BookRepository(dataContext);
        }
        public ICategoryService GetCategoryService()
        {
            return new CategoryRepository(dataContext);
        }
        public IWritersService GetWriterService()
        {
            return new WriterRepository(dataContext);
        }
    }
}
