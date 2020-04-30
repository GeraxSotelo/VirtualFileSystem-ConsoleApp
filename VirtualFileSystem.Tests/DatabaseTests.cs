using System;
using System.Diagnostics;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;
using Xunit;

namespace VirtualFileSystem.Tests
{
    public class DatabaseTests
    {
        [Fact]
        [Trait("Category", "Directory")]
        public void CanInsertDirectoryIntoDatabase()
        {
            using (var context = new FileSystemContext())
            {
                //localdb VirtualFileSystemTestData
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var dir = new Directory();
                context.Directories.Add(dir);
                Debug.WriteLine($"Before save: {dir.Id}");

                context.SaveChanges();
                Debug.WriteLine($"After save: {dir.Id}");

                Assert.NotEqual(0, dir.Id);
            }
        }
    }
}
