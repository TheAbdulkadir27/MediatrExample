using Domain.Entity;
using Infrastucture.Context;
using System;
using System.Linq;

namespace Infrastucture.Repository
{
    public class WriterRepository : IWritersService
    {
        private readonly DataContext dataContext;
        public WriterRepository(DataContext dataContext) => this.dataContext = dataContext;
        public Writers AddWriters(Writers writers)
        {
            dataContext.Set<Writers>().Add(writers);
            if (dataContext.SaveChanges() > 0)
                return writers;
            return null;
        }
        public bool DeleteWriters(Guid id)
        {
            dataContext.Remove(id);
            if (dataContext.SaveChanges() > 0)
                return true;
            return false;
        }
        public Writers GetById(Guid id)
        {
            return dataContext.Set<Writers>().FirstOrDefault(v => v.Id == id);
        }
        public Writers UpdateWriters(Writers writers)
        {
            dataContext.Entry(writers).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dataContext.SaveChanges();
            return writers;
        }
    }
}
