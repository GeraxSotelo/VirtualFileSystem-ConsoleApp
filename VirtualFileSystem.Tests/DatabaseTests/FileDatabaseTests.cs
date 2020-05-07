using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;
using Xunit;
using Xunit.Abstractions;

namespace VirtualFileSystem.Tests.DatabaseTests
{
    public class FileDatabaseTests
    {
        private readonly DbContextOptionsBuilder builder;
        private readonly ITestOutputHelper _output;
        private readonly FileSystemContext _context;
        private Directory root;

        public FileDatabaseTests(ITestOutputHelper output)
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
        [Trait("Category", "Files")]
        public void CanInsertFileIntoDatabase()
        {
            using (_context)
            {
                var file = new File() { DirectoryId = 1 };
                _context.Files.Add(file);
                _context.SaveChanges();

                Assert.NotEqual(0, file.Id);
            }
        }

        [Fact]
        [Trait("Category", "Files")]
        public void CanDeleteFileFromDatabase()
        {
            using (_context)
            {
                var file = new File() { Name = "DeleteFile", DirectoryId = 1 };
                _context.Files.Add(file);//tracks file
                _context.SaveChanges(); //adds to db
                _context.Files.Remove(file);
                _context.SaveChanges();

                var found = _context.Files.Where(f => f.Name == "DeleteFile" && f.Id == file.Id).FirstOrDefault();

                Assert.Null(found);
            }
        }

    }
}
