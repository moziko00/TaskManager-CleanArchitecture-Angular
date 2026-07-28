using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Application.Persistence
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
