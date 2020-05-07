using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;

namespace VirtualFileSystem.Tests
{
    public class BusinessDataLogic
    {
        private FileSystemContext _context;

        public BusinessDataLogic()
        {
            _context = new FileSystemContext();
        }
        public BusinessDataLogic(FileSystemContext context)
        {
            _context = context;
        }

        public int MkDir(Directory directory)
        {
            _context.Directories.Add(directory);
            var dbResult = _context.SaveChanges();//returns number of rows affected
            return dbResult;
        }

        public int RmDir(Directory directory)
        {
            _context.Directories.Remove(directory);
            var dbResult = _context.SaveChanges();//returns number of rows affected
            return dbResult;
        }

        public int Touch(File file)
        {
            _context.Files.Add(file);
            var dbResult = _context.SaveChanges();//returns # of rows affected
            return dbResult;
        }

        public int Rm(File file)
        {
            _context.Files.Remove(file);
            var dbResult = _context.SaveChanges();//returns # of rows affected
            return dbResult;
        }

        public void AlreadyExists(string name, int directoryId)
        {
            var exists = GetByNameAndDirectoryId(name, directoryId);
            if (exists != null) { throw new Exception($"\n--Directory '{exists.Name}' already exists in this location.--"); }
        }

        public Directory GetByNameAndDirectoryId(string name, int directoryId)
        {
            var dir = _context.Directories.Where(d => d.Name == name && d.DirectoryId == directoryId).FirstOrDefault();
            return dir;
        }
    }
}
