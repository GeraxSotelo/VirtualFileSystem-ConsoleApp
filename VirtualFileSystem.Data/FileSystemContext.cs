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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = VirtualFileSystemData");
        }

    }
}
