using DumpDrive.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Seeds
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User>
                {
                    new User("manje@mail.com", "123loz_abc")
                    {
                        Id = 1,
                    },
                    new User("duje@mail.com", "456pass_xyz")
                    {
                        Id = 2,
                    },
                });

            builder.Entity<Drive>()
                .HasData(new List<Drive>
                {
                    new Drive(1)
                    {
                        Id = 1,
                    },
                    new Drive(2) 
                    {
                        Id = 2,
                    },
                });

            builder.Entity<Folder>()
                .HasData(new List<Folder>
                {
                    new Folder(1, "Homework") 
                    {
                        Id = 1,
                    },
                    new Folder(1, "Essay")
                    {
                        Id = 2,
                    },
                    new Folder(1, "Random")
                    {
                        Id = 3,
                    },
                    new Folder(2, "Work")
                    {
                        Id = 4,
                    }
                });

            builder.Entity<Entities.Models.File>()
                .HasData(new List<Entities.Models.File>
                {
                    new Entities.Models.File("First Draft", 1)
                    {
                        Id = 1,
                        Created = DateTime.UtcNow,
                    },
                    new Entities.Models.File("Second Draft", 1)
                    {
                        Id = 2,
                        Created = DateTime.UtcNow,
                    },
                    new Entities.Models.File("Favorite foods", 3)
                    {
                        Id = 3,
                        Created = DateTime.UtcNow,
                    },
                    new Entities.Models.File("Quarter report", 4)
                    {
                        Id = 4,
                        Created = DateTime.UtcNow,
                    },
                });
        }
    }
}
