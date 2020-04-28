using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;
using VirtualFileSystem.Domain.Models;

namespace ConsoleApp
{
    class DirectoryRepository
    {
        private static FileSystemContext _context = new FileSystemContext();

        internal void Mkdir(Directory directory)
        {
            _context.Directories.Add(directory);
            _context.SaveChanges();

            //var foundDir = _context.Directories.Find(id);
            //foundDir.Directories.Add(directory);

            //using (var newContext = new FileSystemContext())
            //{
            //    newContext.Directories.Attach(foundDir);
            //    newContext.SaveChanges();
            //}
        }

        internal object GetRootDirectory()
        {
            return _context.Set<RootDirectory>().Find(1);
        }
    }
}
