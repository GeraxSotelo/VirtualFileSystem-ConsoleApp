using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;
using Xunit;
using Xunit.Abstractions;

namespace VirtualFileSystem.Tests.DatabaseTests
{
    public class DirectoryDatabaseTests
    {
        private readonly DbContextOptionsBuilder builder;
        private readonly ITestOutputHelper _output;
        private readonly FileSystemContext _context;
        private Directory root;

        public DirectoryDatabaseTests(ITestOutputHelper output)
        {
            _output = output;
            builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = VirtualFileSystemTestData");
            _context = new FileSystemContext(builder.Options);

            Setup();
        }

        internal void Setup()
        {
            var dir = _context.Directories.Where(d => d.Name == "root" && d.Id == 1).FirstOrDefault();
            if (dir == null)
            {
                root = new Directory() { Name = "root" };
                _context.Directories.Add(root);
                _context.SaveChanges();
            }
        }


        [Fact]
        [Trait("Category", "Directory")]
        public void CanInsertDirectoryIntoDatabase()
        {
            using (_context)
            {
                var dir = new Directory() { Name = "Newer Test Directory" };
                _context.Directories.Add(dir);
                _output.WriteLine($"Before save: {dir.Id}");

                _context.SaveChanges();
                _output.WriteLine($"After save: {dir.Id}");

                Assert.NotEqual(0, dir.Id);
            }
        }

        [Fact]
        [Trait("Category", "Files")]
        public void CanDeleteDirectoryFromDatabase()
        {
            using (_context)
            {
                var dir = new Directory() { Name = "DeleteDirectory" };
                _context.Directories.Add(dir);//tracks directory
                _context.SaveChanges(); //adds to db
                _context.Directories.Remove(dir);
                _context.SaveChanges();

                var found = _context.Directories.Where(d => d.Name == "DeleteDirectory" && d.Id == dir.Id).FirstOrDefault();

                Assert.Null(found);
            }
        }

    }
}
