using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;
using Xunit;
using Xunit.Abstractions;

namespace VirtualFileSystem.Tests.InMemoryTests
{
    public class DirectoryInMemoryTests
    {
        private readonly DbContextOptionsBuilder builder;
        private readonly ITestOutputHelper _output;


        public DirectoryInMemoryTests(ITestOutputHelper output)
        {
            builder = new DbContextOptionsBuilder();
            _output = output;
        }

        [Fact]
        public void CanInsertSingleDirectory()
        {
            //UsInMemoryDatabase() needs a string to be passed in to give a name to that instance
            //It's how EF Core keeps track of different instances of the provider in memory.
            builder.UseInMemoryDatabase("InsertSingleDirectory");

            using (var context = new FileSystemContext(builder.Options))
            {
                var bizlogic = new BusinessDataLogic(context);
                bizlogic.MkDir(new Directory());
            }

            using (var context2 = new FileSystemContext(builder.Options))
            {
                Assert.Equal(1, context2.Directories.Count());
            }
        }

        [Fact]
        public void CanRemoveSingleDirectory()
        {
            builder.UseInMemoryDatabase("RemoveSingleDirectory");

            using (var context = new FileSystemContext(builder.Options))
            {
                var bizlogic = new BusinessDataLogic(context);
                var dir = new Directory() { Name = "RemoveDir" };
                var dir1 = new Directory() { Name = "RemoveDir1" };
                var dir2 = new Directory() { Name = "RemoveDir2" };
                bizlogic.MkDir(dir);
                bizlogic.MkDir(dir1);
                bizlogic.MkDir(dir2);
                bizlogic.RmDir(dir1);
            }

            using (var context2 = new FileSystemContext(builder.Options))
            {
                Assert.Equal(2, context2.Directories.Count());
            }
        }

        [Fact]
        [Trait("Category", "Directory")]
        public void CanInsertDirectoryIntoDatabase()
        {
            builder.UseInMemoryDatabase("CanInsertDirectory");

            using (var context = new FileSystemContext(builder.Options))
            {
                var dir = new Directory();
                context.Directories.Add(dir);

                //Check the state of the entity is 'added'.
                Assert.Equal(EntityState.Added, context.Entry(dir).State);
            }
        }

        [Fact]
        [Trait("Category", "Directory")]
        public void CanRemoveDirectoryFromDatabase()
        {
            builder.UseInMemoryDatabase("CanDeleteDirectory");

            using (var context = new FileSystemContext(builder.Options))
            {
                var dir = new Directory() { Name = "DeleteDirectory" };

                context.Directories.Add(dir);
                context.Directories.Remove(dir);

                Assert.Equal(EntityState.Detached, context.Entry(dir).State);
            }
        }

        [Fact]
        [Trait("Category", "Directory")]
        public void ThrowsExceptionForDuplicateDirectory()
        {
            builder.UseInMemoryDatabase("ThrowsException");

            using (var context = new FileSystemContext(builder.Options))
            {
                context.Database.EnsureCreated();

                var bizlogic = new BusinessDataLogic(context);

                var dir = new Directory() { Name = "Exception Directory", DirectoryId = 1 };
                context.Directories.Add(dir);
                context.SaveChanges();

                Assert.Throws<Exception>(() => bizlogic.AlreadyExists("Exception Directory", 1));
            }
        }
    }
}
