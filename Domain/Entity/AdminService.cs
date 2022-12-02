using System;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public interface IAdminService
    {
        Admin AdminAdd(Admin admin);
        bool AdminDelete(Guid id);
        Admin AdminUpdate(Admin admin);
        Admin GetById(Guid İd);
    }
}
