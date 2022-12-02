using System;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public interface IWritersService
    {
        Writers AddWriters(Writers writers);
        bool DeleteWriters(Guid id);
        Writers UpdateWriters(Writers writers);
        Writers GetById(Guid id);
    }
}
