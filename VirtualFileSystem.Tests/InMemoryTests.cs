using ConsoleApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;
using Xunit;
using Xunit.Abstractions;

namespace VirtualFileSystem.Tests
{
    public class InMemoryTests
    {
        private readonly DbContextOptionsBuilder builder;
        private readonly ITestOutputHelper _output;


        public InMemoryTests(ITestOutputHelper output)
        {
            builder = new DbContextOptionsBuilder();
            _output = output;
        }

        [Fact]
        [Trait("Category", "Directory")]
        public void CanInsertDirectoryIntoDatabase()
        {
            //UsInMemoryDatabase() needs a string to be passed in to give a name to that instance
            //It's how EF Core keeps track of different instances of the provider in memory.
            builder.UseInMemoryDatabase("CanInsertDirectory");

            using (var context = new FileSystemContext(builder.Options))
            {
                var dir = new Directory();
                context.Directories.Add(dir);

                //Check the state of the entity is added.
                Assert.Equal(EntityState.Added, context.Entry(dir).State);
            }
        }

        [Fact]
        [Trait("Category", "File")]
        public void CanInsertFileIntoDatabase()
        {
            builder.UseInMemoryDatabase("CanInsertFile");

            using (var context = new FileSystemContext(builder.Options))
            {
                var file = new File() { DirectoryId = 1 };
                context.Files.Add(file);

                Assert.Equal(EntityState.Added, context.Entry(file).State);
            }
        }

        [Fact]
        public void CanInsertSingleDirectory()
        {
            builder.UseInMemoryDatabase("InsertSingleDirectory");

            using (var context = new FileSystemContext(builder.Options))
            {
                var bizlogic = new BusinessDataLogic(context);
                bizlogic.Mkdir(new Directory());
            }

            using (var context2 = new FileSystemContext(builder.Options))
            {
                Assert.Equal(1, context2.Directories.Count());
            }
        }

        [Fact]
        public void CanInsertSingleFile()
        {
            builder.UseInMemoryDatabase("InsertSingleFile");

            using (var context = new FileSystemContext(builder.Options))
            {
                var bizlogic = new BusinessDataLogic(context);
                bizlogic.Touch(new File() { DirectoryId = 1 });
            }

            using (var context2  = new FileSystemContext(builder.Options))
            {
                Assert.Equal(1, context2.Files.Count());
            }
        }

        [Fact]
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
