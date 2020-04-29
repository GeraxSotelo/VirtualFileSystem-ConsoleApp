﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;
using Xunit;

namespace VirtualFileSystem.Tests
{
    public class InMemoryTests
    {
        [Fact]
        public void CanInsertDirectoryIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder();
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
    }
}