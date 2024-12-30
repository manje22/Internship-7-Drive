using DumpDrive.Data.Entities;
using DumpDrive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DumpDriveDbContext DbContext;

        protected BaseRepository(DumpDriveDbContext dbContext) 
        {
            DbContext = dbContext;
        }
        
        protected Result SaveChanges()
        {
            var hasChanges = DbContext.SaveChanges() > 0;
            if (hasChanges)
                return Result.Success;

            return Result.NoChanges;
        }
    }
}
