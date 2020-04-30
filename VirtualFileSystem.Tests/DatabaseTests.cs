using System;
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

        public DatabaseTests(ITestOutputHelper output)
        {
            builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = VirtualFileSystemTestData");
            _output = output;
        }

        [Fact]
        [Trait("Category", "Directory")]
        public void CanInsertDirectoryIntoDatabase()
        {

            using (var context = new FileSystemContext(builder.Options))
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var dir = new Directory() { Name = "Newer Test Directory" };
                context.Directories.Add(dir);
                _output.WriteLine($"Before save: {dir.Id}");

                context.SaveChanges();
                _output.WriteLine($"After save: {dir.Id}");

                Assert.NotEqual(0, dir.Id);
            }
        }
    }
}
