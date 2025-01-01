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
    public class FileCommentRepository : BaseRepository
    {
        public FileCommentRepository(DumpDriveDbContext dbContext) : base(dbContext) { }

        public Result Add(FileComment fileComment)
        {
            DbContext.FilesComment.Add(fileComment);

            return SaveChanges();
        }

        public Result Delete(int id)
        {
            var commentToBeDeleted = DbContext.FilesComment.Find(id);
            if (commentToBeDeleted is null)
            {
                return Result.NotFound;
            }

            DbContext.FilesComment.Remove(commentToBeDeleted);

            return SaveChanges();
        }

        //get all comments of doc
        
        //get comments filtered by person idk
    }
}
