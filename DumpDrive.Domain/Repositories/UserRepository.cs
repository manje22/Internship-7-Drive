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

        public Result Update(User user, string email)
        {
            var userToBeUpdated = DbContext.Users.FirstOrDefault(u => u.Email == email);

            if (userToBeUpdated == null)
            {
                return Result.NotFound;
            }


            DbContext.Attach(userToBeUpdated);
            userToBeUpdated.Email = user.Email;
            userToBeUpdated.Password = user.Password;

            try
            {
                return SaveChanges();
            }
            catch (Exception ex)
            {
                return Result.Error;
            }
        }

        public ICollection<User> GetAll() => DbContext.Users.ToList();

        public User? GetByEmail(string email)
        {
            var foundUser = DbContext.Users.FirstOrDefault(U => U.Email == email);
            return foundUser;
        }

        public bool CheckPassword(User user, string password)
        {
            return user.Password == password;
        }

    }
}
