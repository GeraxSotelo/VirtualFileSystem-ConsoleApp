using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain;
using VirtualFileSystem.Domain.Models;

namespace VirtualFileSystem.Data
{
    public class FileSystemContext : DbContext
    {
        public DbSet<Directory> Directories { get; set; }
        public DbSet<File> Files { get; set; }

        public FileSystemContext()
        {}

        public FileSystemContext(DbContextOptions options) : base (options) //Options CONSTRUCTOR
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging().UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = VirtualFileSystemData");
            }
        }

    }
}
