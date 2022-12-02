using Domain.Entity;
using Infrastucture.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastucture.Repository
{
    public class AdminRepository : IAdminService
    {
        private readonly DataContext dataContext1;
        public AdminRepository(DataContext DataContext1)
        {
            this.dataContext1 = DataContext1;
        }
        public Admin AdminAdd(Admin admin)
        {
            dataContext1.Set<Admin>().Add(admin);
            int value = dataContext1.SaveChanges();
            return admin;
        }
        public bool AdminDelete(Guid id)
        {
            dataContext1.Set<Admin>().Remove(GetById(id));
            if (dataContext1.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Admin AdminUpdate(Admin admin)
        {
            dataContext1.Entry(admin).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dataContext1.SaveChanges();
            return admin;
        }
        public Admin GetById(Guid İd)
        {
            var admins = dataContext1.Set<Admin>().First(v => v.Id == İd);
            return admins;
        }
    }
}
