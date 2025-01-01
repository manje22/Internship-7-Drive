using DumpDrive.Data.Entities;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = DumpDrive.Data.Entities.Models.File;

namespace DumpDrive.Domain.Repositories
{
    public class FileRepository : BaseRepository
    {
        public FileRepository(DumpDriveDbContext dbContext) : base(dbContext) { }

        public Result Add(File file)
        {
            DbContext.Files.Add(file);

            return SaveChanges();
        }

        public Result Delete(int id)
        {
            var fileToBeDeleted = DbContext.Files.Find(id);
            if (fileToBeDeleted is null)
            {
                return Result.NotFound;
            }

            DbContext.Files.Remove(fileToBeDeleted);

            return SaveChanges();
        }

        public Result Update(File file, int id)
        {
            var fileToBeUpdated = DbContext.Files.Find(id);

            if (fileToBeUpdated is null)
            {
                return Result.NotFound;
            }

            fileToBeUpdated.Name = file.Name;

            return SaveChanges();
        }

    }
}
