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
    public class UserRepository : BaseRepository
    {
        public UserRepository(DumpDriveDbContext dbContext) : base(dbContext) { }

        public Result Add(User user)
        {
            DbContext.Users.Add(user);

            return SaveChanges();
        }

        public Result Delete(int id)
        {
            var userToBeDeleted = DbContext.Users.Find(id);
            if (userToBeDeleted is null)
            {
                return Result.NotFound;
            }

            DbContext.Users.Remove(userToBeDeleted);

            return SaveChanges();
        }

        public Result Update(User user, int id)
        {
            var userToBeUpdated = DbContext.Users.Find(id);

            if (userToBeUpdated is null)
            {
                return Result.NotFound;
            }

            userToBeUpdated.Email = user.Email;
            userToBeUpdated.Password = user.Password;

            return SaveChanges();
        }

        public Result GetByEmail(string email)
        {
            var foundUser = DbContext.Users.FirstOrDefault(U => U.Email == email);
            if (foundUser is null)
                return Result.NotFound;

            return Result.Success;
        }
    }
}
