using DumpDrive.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Entities
{
    public class DumpDriveDbContext : DbContext
    {
        public DumpDriveDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Drive> Drives => Set<Drive>();
        public DbSet<Models.File> Files => Set<Models.File>();
        public DbSet<FileComment> FilesComment => Set<FileComment>();
        public DbSet<FileLine> FileLines => Set<FileLine>();
        public DbSet<Folder> Folders => Set<Folder>();
        public DbSet<SharedFileUser> SharedFilesUsers => Set<SharedFileUser>();
        public DbSet<SharedFolderUser> SharedFoldersUsers => Set<SharedFolderUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SharedFileUser>()
                .HasKey(fu => new {fu.FileId, fu.UserId});

            modelBuilder.Entity<SharedFileUser>()
                .HasOne(f => f.User)
                .WithMany(u => u.SharedFiles)
                .HasForeignKey(fu => fu.UserId);

            modelBuilder.Entity<SharedFileUser>()
                .HasOne(f => f.File)
                .WithMany(f => f.SharedWith)
                .HasForeignKey(fu => fu.FileId);

            modelBuilder.Entity<SharedFolderUser>()
                .HasKey(flu => new { flu.UserId, flu.FolderId });

            modelBuilder.Entity<SharedFolderUser>()
                .HasOne(f => f.User)
                .WithMany(u => u.SharedFolders)
                .HasForeignKey(flu => flu.UserId);

            modelBuilder.Entity<SharedFolderUser>()
                .HasOne(f => f.Folder)
                .WithMany(f => f.SharedWith)
                .HasForeignKey(flu => flu.FolderId);

            modelBuilder.Entity<Folder>()
                .HasOne(f => f.ParentDrive)
                .WithMany(u => u.Folders);

            modelBuilder.Entity<Models.File>()
                .HasOne(f => f.Folder)
                .WithMany(f => f.Files);

            modelBuilder.Entity<FileLine>()
                .HasOne(f => f.ParentFile)
                .WithMany(f => f.FileLines);

            modelBuilder.Entity<FileComment>()
                .HasOne(f => f.ParentFile)
                .WithMany(f => f.Comments);



            base.OnModelCreating(modelBuilder);
        }
    }
}
