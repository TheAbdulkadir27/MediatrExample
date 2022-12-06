using Domain.Entity;
using System;
using System.Linq.Expressions;

namespace Domain.Common
{
    public class AdminSpecification : Specification<Admin>
    {
        public AdminSpecification(Admin admin) => this.admin = admin;
        public Admin admin { get; set; }
        public override Expression<Func<Admin, bool>> Expression()
        {
            return e => admin == null || (string.IsNullOrEmpty(admin.Name) || e.Name == admin.Name) && (string.IsNullOrEmpty(admin.Surname) || e.Surname == admin.Surname);
        }
    }
}
