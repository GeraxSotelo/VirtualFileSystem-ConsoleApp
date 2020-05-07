using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;
using Xunit;
using Xunit.Abstractions;

namespace VirtualFileSystem.Tests.InMemoryTests
{
    public class FileInMemoryTests
    {
        private readonly DbContextOptionsBuilder builder;
        private readonly ITestOutputHelper _output;


        public FileInMemoryTests(ITestOutputHelper output)
        {
            builder = new DbContextOptionsBuilder();
            _output = output;
        }

        [Fact]
        [Trait("Category", "File")]

        public void CanInsertSingleFile()
        {
            //UsInMemoryDatabase() needs a string to be passed in to give a name to that instance
            //It's how EF Core keeps track of different instances of the provider in memory.
            builder.UseInMemoryDatabase("InsertSingleFile");

            using (var context = new FileSystemContext(builder.Options))
            {
                var bizlogic = new BusinessDataLogic(context);
                bizlogic.Touch(new File() { DirectoryId = 1 });
            }

            using (var context2 = new FileSystemContext(builder.Options))
            {
                Assert.Equal(1, context2.Files.Count());
            }
        }

        [Fact]
        public void CanRemoveSingleFile()
        {
            builder.UseInMemoryDatabase("RemoveSingleFile");

            using (var context = new FileSystemContext(builder.Options))
            {
                var bizlogic = new BusinessDataLogic(context);
                var file = new File() { Name = "RemoveFile", DirectoryId = 1 };
                var file1 = new File() { Name = "RemoveFile1", DirectoryId = 1 };
                var file2 = new File() { Name = "RemoveFile2", DirectoryId = 1 };
                bizlogic.Touch(file);
                bizlogic.Touch(file1);
                bizlogic.Touch(file2);
                bizlogic.Rm(file1);
            }

            using (var context2 = new FileSystemContext(builder.Options))
            {
                Assert.Equal(2, context2.Files.Count());
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

                //Check the state of the entity is 'added'.
                Assert.Equal(EntityState.Added, context.Entry(file).State);
            }
        }

        [Fact]
        [Trait("Category", "File")]
        public void CanRemoveFileFromDatabase()
        {
            builder.UseInMemoryDatabase("CanDeleteFile");

            using (var context = new FileSystemContext(builder.Options))
            {
                var file = new File() { Name= "DeleteFile", DirectoryId = 1 };

                context.Files.Add(file);
                context.Files.Remove(file);

                Assert.Equal(EntityState.Detached, context.Entry(file).State);
            }
        }

    }
}
