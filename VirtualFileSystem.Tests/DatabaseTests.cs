using System;
using ConsoleApp;
using Microsoft.EntityFrameworkCore;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;
using Xunit;
using Xunit.Abstractions;

namespace VirtualFileSystem.Tests
{
    public class DatabaseTests
    {
        private readonly DbContextOptionsBuilder builder;
        private readonly ITestOutputHelper _output;
        private readonly FileSystemContext context;
        private readonly Directory root;

        public DatabaseTests(ITestOutputHelper output)
        {
            _output = output;
            builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = VirtualFileSystemTestData");
            context = new FileSystemContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            root = new Directory() { Name = "root" };
            context.Directories.Add(root);
            context.SaveChanges();
        }


        [Fact]
        [Trait("Category", "Directory")]
        public void CanInsertDirectoryIntoDatabase()
        {
            using (context)
            {
                var dir = new Directory() { Name = "Newer Test Directory" };
                context.Directories.Add(dir);
                _output.WriteLine($"Before save: {dir.Id}");

                context.SaveChanges();
                _output.WriteLine($"After save: {dir.Id}");

                Assert.NotEqual(0, dir.Id);
            }
        }

        [Fact]
        [Trait("Category", "Files")]
        public void CanInsertFileIntoDatabase()
        {
            using (context)
            {
                var file = new File() { DirectoryId = root.Id };
                context.Files.Add(file);
                context.SaveChanges();

                Assert.NotEqual(0, file.Id);
            }
        }
    }
}
