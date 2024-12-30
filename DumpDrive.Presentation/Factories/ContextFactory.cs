using Microsoft.EntityFrameworkCore;
using System.Configuration;
using DumpDrive.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Presentation.Factories
{
    public static class DbContextFactory
    {
        public static DumpDriveDbContext GetDumpDriveContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql(ConfigurationManager.ConnectionStrings["DumpDrive"].ConnectionString)
                .Options;

            return new DumpDriveDbContext(options);
        }
    }
}
