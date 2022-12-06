using Domain.Common;
using Domain.Entity;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastucture.Repository
{
    public class AdminRepository : IAdminService
    {
        private readonly DataContext _DataContext;
        public AdminRepository(DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        public Admin AdminAdd(Admin admin)
        {
            _DataContext.AdminS.Add(admin);
            return admin;
        }
        public bool AdminDelete(Guid id)
        {
            _DataContext.AdminS.Remove(GetById(id));
            return true;
        }
        public Admin AdminUpdate(Admin admin)
        {
            _DataContext.AdminS.Update(admin);
            return admin;
        }
        public Admin GetById(Guid İd)
        {
            var admins = _DataContext.AdminS.FirstOrDefault(v => v.Id == İd);
            return admins;
        }
        public Admin[] Search(Specification<Admin> specification, Pagition page)
        {
            return _DataContext.AdminS.AsNoTracking().Filter(specification).Page(page).ToArray();
        }
    }
}
