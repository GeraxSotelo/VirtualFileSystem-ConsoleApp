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

        public int Mkdir(Directory directory)
        {
            _context.Directories.Add(directory);
            //returns number of rows affected
            var dbResult = _context.SaveChanges();
            return dbResult;
        }

        public int Touch(File file)
        {
            _context.Files.Add(file);
            //returns number of rows affected
            var dbResult = _context.SaveChanges();
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
