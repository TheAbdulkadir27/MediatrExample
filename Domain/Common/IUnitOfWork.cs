using Domain.Entity;
namespace Domain.Common
{
    public interface IUnitOfWork
    {
        int Commit();
        IAdminService GetAdminService();
        IBookService GetBookService();
        ICategoryService GetCategoryService();
        IWritersService GetWriterService();
    }
}
