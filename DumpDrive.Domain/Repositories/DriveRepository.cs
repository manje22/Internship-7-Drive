using DumpDrive.Data.Entities;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Domain.Repositories
{
    public class DriveRepository : BaseRepository
    {
        public DriveRepository(DumpDriveDbContext dbContext) : base(dbContext) { }

        public Result Add(Drive drive)
        {
            DbContext.Drives.Add(drive);

            return SaveChanges();
        }


        public Result Delete(int id)
        {
            var driveToDelete = DbContext.Drives.Find(id);
            if (driveToDelete is null)
            {
                return Result.NotFound;
            }

            DbContext.Drives.Remove(driveToDelete);

            return SaveChanges();
        }

        
    }
}
