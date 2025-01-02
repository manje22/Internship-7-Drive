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
    public class FolderRepository : BaseRepository
    {
        public FolderRepository(DumpDriveDbContext dbContext) : base(dbContext) { }

        public Result Add(Folder folder)
        {
            DbContext.Folders.Add(folder);

            return SaveChanges();
        }

        public Result Delete(int id)
        {
            var folderToBeDeleted = DbContext.Folders.Find(id);
            if (folderToBeDeleted is null)
            {
                return Result.NotFound;
            }

            DbContext.Folders.Remove(folderToBeDeleted);

            return SaveChanges();
        }

        public Result Update(Folder folder, int id)
        {
            var folderToBeUpdated = DbContext.Folders.Find(id);

            if (folderToBeUpdated is null)
            {
                return Result.NotFound;
            }

            folderToBeUpdated.Name = folder.Name;

            return SaveChanges();
        }
    }
}
