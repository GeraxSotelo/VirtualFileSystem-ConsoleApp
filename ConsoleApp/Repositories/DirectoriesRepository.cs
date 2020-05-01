using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;
using VirtualFileSystem.Domain.Models;

namespace ConsoleApp
{
    public class DirectoriesRepository
    {
        private static FileSystemContext _context = new FileSystemContext();

        internal Directory GetRootDirectory()
        {
            return _context.Directories.Find(1);
        }

        internal Directory CreateRootDirectory(Directory root)
        {
            _context.Directories.Add(root);
            //root is now being tracked
            _context.SaveChanges();
            return root;
        }

        internal Directory GetByNameAndDirectoryId(string option, int directoryId)
        {
            var dir = _context.Directories.Where(d => d.Name == option && d.DirectoryId == directoryId).FirstOrDefault();
            return dir;
        }

        internal IEnumerable<Directory> GetDirectoriesByDirectoryId(int id)
        {
            return _context.Directories.Where(d => d.DirectoryId == id).ToList();
        }

        internal void MkDir(Directory directory)
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

        internal bool DirectoryExists(string name, int? directoryId)
        {
            return _context.Directories.Any(d => d.Name == name && d.DirectoryId == directoryId);
        }

        internal void RmDir(Directory found)
        {
            _context.Directories.Remove(found);
            _context.SaveChanges();
        }
    }
}
